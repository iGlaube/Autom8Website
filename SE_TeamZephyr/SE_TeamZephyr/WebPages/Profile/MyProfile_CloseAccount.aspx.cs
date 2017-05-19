using SE_TeamZephyr.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_TeamZephyr.Profile
{
    public partial class MyProfile_CloseAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Add all of the reasons for leaving to the reason dropdown list
            Dropdown_Reason.Items.Add("");
            Dropdown_Reason.Items.Add("I found an alternative method of car sharing.");
            Dropdown_Reason.Items.Add("I moved and don't car share anymore.");
            Dropdown_Reason.Items.Add("The app wasn't what I expected.");
            Dropdown_Reason.Items.Add("I got it to try but it's not for me.");
            Dropdown_Reason.Items.Add("I found a regular car share and have no need of the site anymore.");
            Dropdown_Reason.Items.Add("I have another account and want to close this one.");
            Dropdown_Reason.Items.Add("No one contacted me about the ride I offered.");
            Dropdown_Reason.Items.Add("I have encountered a technical issue.");
            Dropdown_Reason.Items.Add("Other.");


            // Add yes or no to the recommend dropdown
            Dropdown_Recommend.Items.Add("");
            Dropdown_Recommend.Items.Add("Yes");
            Dropdown_Recommend.Items.Add("No");

            if(!IsPostBack)
            {
                
            }

        }

        protected void Close_Button_Click(object sender, EventArgs e)
        {
            string reason = Dropdown_Reason.SelectedItem.Text;
            string recommend = Dropdown_Recommend.SelectedItem.Text;
            string improvements = ImproveMessage.InnerText;

            // Get current user ID
            var identityContext = new IdentityDBContext();
            var currentUserID = Context.User.Identity.GetUserId();
            ApplicationUser currentUser = identityContext.Users.FirstOrDefault(x => x.Id == currentUserID);

            using (var context = new SE_TeamZephyr.Models.Autom8DBAppContext11())
            {

                // Testing the current context
                // Create instance of UserFeedback
               var userFeedback = new UserFeedback();

                userFeedback.UserID = currentUserID;
                userFeedback.FeedbackReason = reason;
                userFeedback.FeedbackRecommend = recommend;
                userFeedback.FeedbackImprovements = improvements;


                // Add the new userFeedback object as a row and save the changes to the context
                context.UserFeedback.Add(userFeedback);
                context.SaveChanges();

            }

        }
    }
}