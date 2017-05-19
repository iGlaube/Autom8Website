using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SE_TeamZephyr.Models;


namespace SE_TeamZephyr.Logic
{
    public class JourneyBasketActions : IDisposable
    {
        public string JourneyBasketId { get; set; }
        private Autom8DBAppContext11 _db = new Autom8DBAppContext11();
        public const string BasketSessionKey = "BasketId";
        public void AddToBasket(int id)
        {
            // Retrieve the product from the database.
            JourneyBasketId = GetBasketId();
            var basketItem = _db.BasketItems.SingleOrDefault(
            c => c.BasketId == JourneyBasketId
            && c.JourneyId == id);
            if (basketItem == null)
            {
                // Create a new cart item if no cart item exists.
                basketItem = new BasketItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    JourneyId = id,
                    BasketId = JourneyBasketId,
                    Journey = _db.Journeys.SingleOrDefault(p => p.JourneyID == id),
                    Seats = 1,
                    DateCreated = DateTime.Now
                };
                _db.BasketItems.Add(basketItem);
            }
            else
            {
                // If the item does exist in the cart,
                // then add one to the seats.
                basketItem.Seats++;
            }
            _db.SaveChanges();
        }
        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }
        public string GetBasketId()
        {
            if (HttpContext.Current.Session[BasketSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[BasketSessionKey] =
                   HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.
                    Guid tempBasketId = Guid.NewGuid();
                    HttpContext.Current.Session[BasketSessionKey] = tempBasketId.ToString();
                }
            }
            return HttpContext.Current.Session[BasketSessionKey].ToString();
        }
        public List<BasketItem> GetBasketItems()
        {
            JourneyBasketId = GetBasketId();
            return _db.BasketItems.Where(
            c => c.BasketId == JourneyBasketId).ToList();
        }


        public decimal GetTotal()
        {
            JourneyBasketId = GetBasketId();
            // Multiply journey price by seats of that journey to get
            // the current price for each of those journeys in the cart.
            // Sum all journey price totals to get the basket total.

            decimal? total = decimal.Zero;
            total = (decimal?)(from basketItems in _db.BasketItems
                               where basketItems.BasketId == JourneyBasketId
                               select (double?)basketItems.Journey.JourneyPrice).Sum();
            return total ?? decimal.Zero;
        }


        public JourneyBasketActions GetBasket(HttpContext context)
        {
            using (var basket = new JourneyBasketActions())
            {
                basket.JourneyBasketId = basket.GetBasketId();
                return basket;
            }
        }
        public void UpdateJourneyBasketDatabase(String basketId, JourneyBasketUpdates[]
       BasketItemUpdates)
        {
            using (var db = new SE_TeamZephyr.Models.Autom8DBAppContext11())
            {
                try
                {
                    int BasketItemCount = BasketItemUpdates.Count();
                    List<BasketItem> myBasket = GetBasketItems();
                    foreach (var basketItem in myBasket)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < BasketItemCount; i++)
                        {
                            if (basketItem.Journey.JourneyID == BasketItemUpdates[i].JourneyId)
                            {
                                if (BasketItemUpdates[i].PurchaseSeats < 1 ||
                               BasketItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(basketId, basketItem.JourneyId);
                                }
                                else
                                {
                                    UpdateItem(basketId, basketItem.JourneyId,
                                   BasketItemUpdates[i].PurchaseSeats);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " +
                   exp.Message.ToString(), exp);
                }
            }
        }
        public void RemoveItem(string removeBasketID, int removeJourneyID)
        {
            using (var _db = new SE_TeamZephyr.Models.Autom8DBAppContext11())
            {
                try
                {
                    var myItem = (from c in _db.BasketItems
                                  where c.BasketId == removeBasketID && c.Journey.JourneyID == removeJourneyID
                                  select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _db.BasketItems.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " +
                   exp.Message.ToString(), exp);
                }
            }
        }
        public void UpdateItem(string updateBasketID, int updateJourneyID, int seats)
        {
            using (var _db = new SE_TeamZephyr.Models.Autom8DBAppContext11())
            {
                try
                {
                    var myItem = (from c in _db.BasketItems
                                  where c.BasketId == updateBasketID && c.Journey.JourneyID == updateJourneyID
                                  select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Seats = seats;
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " +
                   exp.Message.ToString(), exp);
                }
            }
        }
        public void EmptyCart()
        {
            JourneyBasketId = GetBasketId();
            var basketItems = _db.BasketItems.Where(
            c => c.BasketId == JourneyBasketId);
            foreach (var basketItem in basketItems)
            {
                _db.BasketItems.Remove(basketItem);
            }
            // Save changes.
            _db.SaveChanges();
        }
        public int GetCount()
        {
            JourneyBasketId = GetBasketId();
            // Get the count of each item in the cart and sum them up
            int? count = (from basketItems in _db.BasketItems
                          where basketItems.BasketId == JourneyBasketId
                          select (int?)basketItems.Seats).Sum();
            // Return 0 if all entries are null
            Console.Write(count);
            return 1;
        }
        public struct JourneyBasketUpdates
        {
            public int JourneyId;
            public int PurchaseSeats;
            public bool RemoveItem;
        }



        public void MigrateCart(string userBasketId, string userName)
        {
            var userCart = _db.BasketItems.Where(c => c.BasketId == userBasketId);
            foreach (BasketItem item in userCart)
            {
                item.BasketId = userName;
            }
            HttpContext.Current.Session[BasketSessionKey] = userName;
            _db.SaveChanges();
        }

    }
}

