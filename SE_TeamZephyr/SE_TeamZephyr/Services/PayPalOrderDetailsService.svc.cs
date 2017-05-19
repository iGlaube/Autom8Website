using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PayPalOrderDetailsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PayPalOrderDetailsService.svc or PayPalOrderDetailsService.svc.cs at the Solution Explorer and start debugging.
    public class PayPalOrderDetailsService : IPayPalOrderDetailsService
    {
        public void createPayPalOrderDetails(int orderID, string userName, int journeyID, int seats, double unitPrice)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                PayPalOrderDetails payPalOrderDetails = new PayPalOrderDetails()
                {
                    OrderId = orderID,
                    Username = userName,
                    JourneyID = journeyID,
                    NoOfSeats = seats,
                    UnitPrice = unitPrice
                };
                DBContext.OrderDetails.Add(payPalOrderDetails);
                DBContext.SaveChanges();
            }
        }

        public PayPalOrderDetails retrievePayPalOrderDetails(int payPalOrderDetailsID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var payPalOrderDetails = DBContext.OrderDetails.Where(a => a.OrderDetailId == payPalOrderDetailsID).FirstOrDefault();
                if (payPalOrderDetails == new PayPalOrderDetails())
                {
                    throw new Exception();
                }
                return payPalOrderDetails;
            }
        }

        public List<PayPalOrderDetails> retrieveAllPayPalOrderDetailss()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var payPalOrderDetails = DBContext.OrderDetails.ToList();
                if (payPalOrderDetails.Count > 0)
                {
                    return payPalOrderDetails;
                }
                return new List<PayPalOrderDetails>();
            }
        }

        public void updatePayPalOrderDetails(int orderDetailId, int orderID, string userName, int journeyID, int seats, double unitPrice)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingPayPalOrderDetails = DBContext.OrderDetails.Single(o => o.OrderDetailId == orderDetailId);
                existingPayPalOrderDetails.OrderDetailId = orderDetailId;
                existingPayPalOrderDetails.OrderId = orderID;
                existingPayPalOrderDetails.Username = userName;
                existingPayPalOrderDetails.JourneyID = journeyID;
                existingPayPalOrderDetails.NoOfSeats = seats;
                existingPayPalOrderDetails.UnitPrice = unitPrice;
                DBContext.SaveChanges();
            }
        }

        public void deletePayPalOrderDetails(int payPalOrderDetailsID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.OrderDetails.Remove(DBContext.OrderDetails.Where(a => a.OrderDetailId == payPalOrderDetailsID).First());
                DBContext.SaveChanges();
            }
        }
    }
}
