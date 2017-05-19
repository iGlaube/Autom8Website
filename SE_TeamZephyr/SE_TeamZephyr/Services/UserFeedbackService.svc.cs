using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserFeedbackService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserFeedbackService.svc or UserFeedbackService.svc.cs at the Solution Explorer and start debugging.
    public class UserFeedbackService : IUserFeedbackService
    {
        public void createUserFeedback(

             string userID,
             string feedbackReason,
             string feedbackRecommend,
             string feedbackImprovements
             )
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                UserFeedback userFeedback = new UserFeedback()
                {
                    UserID = userID,
                    FeedbackReason = feedbackReason,
                    FeedbackRecommend = feedbackRecommend,
                    FeedbackImprovements = feedbackImprovements

                };

                DBContext.UserFeedback.Add(userFeedback);
                DBContext.SaveChanges();
            }
        }

        public UserFeedback retrieveUserFeedback(int userFeedbackID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var userFeedback = DBContext.UserFeedback.Where(f => f.UserFeedBackID == userFeedbackID).FirstOrDefault();
                if(userFeedback == new UserFeedback())
                {
                    throw new Exception();
                }

                return userFeedback;
            }
        }

        public List<UserFeedback> retrieveAllUserFeedback()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var userFeedbacks = DBContext.UserFeedback.ToList();
                if(userFeedbacks.Count > 0)
                {
                    return userFeedbacks;
                }
                return new List<UserFeedback>();
            }
        }

        public void deleteUserFeedback(int userFeedbackID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.UserFeedback.Remove(DBContext.UserFeedback.Where(f => f.UserFeedBackID == userFeedbackID).First());
                DBContext.SaveChanges();
            }
        }


    }
}
