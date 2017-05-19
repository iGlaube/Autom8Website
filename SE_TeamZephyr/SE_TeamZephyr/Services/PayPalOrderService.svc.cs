using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PayPalOrderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PayPalOrderService.svc or PayPalOrderService.svc.cs at the Solution Explorer and start debugging.
    public class PayPalOrderService : IPayPalOrderService
    {
        public void createPayPalOrder(DateTime orderDate, string userName, string firstName, string lastName, string address, string city, string county, string postcode, string country, string mobile, string email, decimal total, string paymentTransactionID, bool hasbeenShipped)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                PayPalOrder payPalOrder = new PayPalOrder()
                {
                    OrderDate = orderDate,
                    Username = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    City = city,
                    County = county,
                    PostalCode = postcode,
                    Country = country,
                    Mobile = mobile,
                    Email = email,
                    Total = total,
                    PaymentTransactionId = paymentTransactionID,
                    HasBeenShipped = hasbeenShipped
                };
                DBContext.Orders.Add(payPalOrder);
                DBContext.SaveChanges();
            }
        }

        public PayPalOrder retrievePayPalOrder(int payPalOrderID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var payPalOrder = DBContext.Orders.Where(a => a.OrderId == payPalOrderID).FirstOrDefault();
                if (payPalOrder == new PayPalOrder())
                {
                    throw new Exception();
                }
                return payPalOrder;
            }
        }

        public List<PayPalOrder> retrieveAllPayPalOrders()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var payPalOrders = DBContext.Orders.ToList();
                if (payPalOrders.Count > 0)
                {
                    return payPalOrders;
                }
                return new List<PayPalOrder>();
            }
        }

        public void updatePayPalOrder(int orderID, DateTime orderDate, string userName, string firstName, string lastName, string address, string city, string county, string postcode, string country, string mobile, string email, decimal total, string paymentTransactionID, bool hasbeenShipped)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingPayPalOrder = DBContext.Orders.Single(p => p.OrderId == orderID);
                existingPayPalOrder.OrderId = orderID;
                existingPayPalOrder.OrderDate = orderDate;
                existingPayPalOrder.Username = userName;
                existingPayPalOrder.FirstName = firstName;
                existingPayPalOrder.LastName = lastName;
                existingPayPalOrder.Address = address;
                existingPayPalOrder.City = city;
                existingPayPalOrder.County = county;
                existingPayPalOrder.PostalCode = postcode;
                existingPayPalOrder.Country = country;
                existingPayPalOrder.Mobile = mobile;
                existingPayPalOrder.Email = email;
                existingPayPalOrder.Total = total;
                existingPayPalOrder.PaymentTransactionId = paymentTransactionID;
                existingPayPalOrder.HasBeenShipped = hasbeenShipped;
                DBContext.SaveChanges();
            }
        }

        public void deletePayPalOrder(int payPalOrderID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.Orders.Remove(DBContext.Orders.Where(a => a.OrderId == payPalOrderID).First());
                DBContext.SaveChanges();
            }
        }
    }
}
