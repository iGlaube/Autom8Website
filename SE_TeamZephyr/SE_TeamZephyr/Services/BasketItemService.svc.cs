using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BasketItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BasketItemService.svc or BasketItemService.svc.cs at the Solution Explorer and start debugging.
    public class BasketItemService : IBasketItemService
    {
        public void createBasketItem(string itemID, int journeyID, int seats, DateTime dateCreated)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                BasketItem basketItem = new BasketItem()
                {
                    ItemId = itemID,
                    JourneyId = journeyID,
                    Seats = seats, 
                    DateCreated = dateCreated
                };
                DBContext.BasketItems.Add(basketItem);
                DBContext.SaveChanges();
            }
        }

        public BasketItem retrieveBasketItem(int basketItemID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var basketItem = DBContext.BasketItems.Where(a => a.BasketId.Equals(basketItemID)).FirstOrDefault();
                if (basketItem == new BasketItem())
                {
                    throw new Exception();
                }
                return basketItem;
            }
        }

        public List<BasketItem> retrieveAllBasketItems()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var basketItems = DBContext.BasketItems.ToList();
                if (basketItems.Count > 0)
                {
                    return basketItems;
                }
                return new List<BasketItem>();
            }
        }

        public void updateBasketItem(string basketItemID, string itemID, int journeyID, int seats, DateTime dateCreated)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingBasketItem = DBContext.BasketItems.Single(b => b.BasketId == basketItemID);
                existingBasketItem.BasketId = basketItemID;
                existingBasketItem.ItemId = itemID;
                existingBasketItem.JourneyId = journeyID;
                existingBasketItem.Seats = seats;
                existingBasketItem.DateCreated = dateCreated;
                DBContext.SaveChanges();
            }
        }

        public void deleteBasketItem(int basketItemID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.BasketItems.Remove(DBContext.BasketItems.Where(a => a.BasketId.Equals(basketItemID)).First());
                DBContext.SaveChanges();
            }
        }
    }
}
