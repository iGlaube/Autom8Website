using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPayPalOrderDetailsService" in both code and config file together.
    [ServiceContract]
    public interface IPayPalOrderDetailsService
    {
        [OperationContract]
        void createPayPalOrderDetails(int orderID, string userName, int journeyID, int seats, double unitPrice);
        [OperationContract]
        PayPalOrderDetails retrievePayPalOrderDetails(int payPalOrderDetailsID);
        [OperationContract]
        List<PayPalOrderDetails> retrieveAllPayPalOrderDetailss();
        [OperationContract]
        void updatePayPalOrderDetails(int orderDetailId, int orderID, string userName, int journeyID, int seats, double unitPrice);
        [OperationContract]
        void deletePayPalOrderDetails(int payPalOrderDetailsID);
    }
}
