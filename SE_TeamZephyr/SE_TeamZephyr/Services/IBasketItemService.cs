using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBasketItemService" in both code and config file together.
    [ServiceContract]
    public interface IBasketItemService
    {
        [OperationContract]
        void createBasketItem(string itemID, int journeyID, int seats, DateTime dateCreated);
        [OperationContract]
        BasketItem retrieveBasketItem(int basketItemID);
        [OperationContract]
        List<BasketItem> retrieveAllBasketItems();
        [OperationContract]
        void updateBasketItem(string basketItemID, string itemID, int journeyID, int seats, DateTime dateCreated);
        [OperationContract]
        void deleteBasketItem(int basketItemID);
    }
}
