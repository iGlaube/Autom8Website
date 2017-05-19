using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserFeedbackService" in both code and config file together.
    [ServiceContract]
    public interface IUserFeedbackService
    {
        [OperationContract]
        void createUserFeedback(

            string userID,
            string feedbackReason,
            string feedbackRecommend,
            string feedbackImprovements
            );

        [OperationContract]
        UserFeedback retrieveUserFeedback(

            int userFeedbackID
            );

        [OperationContract]
        List<UserFeedback> retrieveAllUserFeedback();

        [OperationContract]
        void deleteUserFeedback(int userFeedbackID);
    
    }
}
