using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPayPalOrderService" in both code and config file together.
    [ServiceContract]
    public interface IPayPalOrderService
    {
        [OperationContract]
        void createPayPalOrder(DateTime orderDate, string userName, string firstName, string lastName, string address, string city, string county, string postcode, string country, string mobile, string email, decimal total, string paymentTransactionID, bool hasbeenShipped);
        [OperationContract]
        PayPalOrder retrievePayPalOrder(int payPalOrderID);
        [OperationContract]
        List<PayPalOrder> retrieveAllPayPalOrders();
        [OperationContract]
        void updatePayPalOrder(int orderID, DateTime orderDate, string userName, string firstName, string lastName, string address, string city, string county, string postcode, string country, string mobile, string email, decimal total, string paymentTransactionID, bool hasbeenShipped);
        [OperationContract]
        void deletePayPalOrder(int payPalOrderID);
    }
}
