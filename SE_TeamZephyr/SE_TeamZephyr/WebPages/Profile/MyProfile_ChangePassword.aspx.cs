using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_TeamZephyr.Profile
{
    public partial class MyProfile_ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                verification_label.Text = "";
                verification_label.Visible = false;
            }

        }

        protected void Save_Button_Click(object sender, EventArgs e)
        {

            

            // Strings set as password text box values
            string oldPass = TxtBox_OldPass.Text;
            string newPass = TxtBox_NewPass.Text;
            string confirmNewPass = TxtBox_ConfirmNewPass.Text;

            // Fire up a database identity context, get the current user
            var context = new IdentityDBContext();
            string currentUserID = Context.User.Identity.GetUserId();
            ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == currentUserID);

            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);

            // Compare the old password entered in the field to the stored password

            bool passwordCheck = UserManager.CheckPassword(currentUser, oldPass);

            // If the new passwords match, and the old password is correct
            if(newPass.Equals(confirmNewPass) && passwordCheck)
            {
                // Hash the new password
                String hashedNewPassword = UserManager.PasswordHasher.HashPassword(newPass);

                // Set the user's password hash field to the new password hash and save
                currentUser.PasswordHash = hashedNewPassword;
                context.SaveChanges();

                // Update the label
                verification_label.Text = "Password successfully changed!";
                verification_label.Visible = true;

                TxtBox_NewPass.Style.Add("border", "solid 1px green");
                TxtBox_ConfirmNewPass.Style.Add("border", "solid 1px green");
                TxtBox_OldPass.Style.Add("border", "solid 1px rgba(0, 0, 0, 0.23)");

            }
            else if (!passwordCheck)
            {

                verification_label.Text = "That is not your old password!";
                verification_label.Visible = true;

                TxtBox_OldPass.Style.Add("border", "solid 1px red");
                TxtBox_NewPass.Style.Add("border", "solid 1px solid 1px rgba(0, 0, 0, 0.23)");
                TxtBox_ConfirmNewPass.Style.Add("border", "solid 1px rgba(0, 0, 0, 0.23)");

            }
            else if (!newPass.Equals(confirmNewPass))
            {

                verification_label.Text = "The new passwords do not match!";
                verification_label.Visible = true;

                TxtBox_OldPass.Style.Add("border", "solid 1px rgba(0, 0, 0, 0.23)");
                TxtBox_NewPass.Style.Add("border", "solid 1px red");
                TxtBox_ConfirmNewPass.Style.Add("border", "solid 1px red");

            }
            if (!passwordCheck && !newPass.Equals(confirmNewPass))
            {

                verification_label.Text = "Your old password is incorrect, and the new ones don't match!";
                verification_label.Visible = true;

                TxtBox_OldPass.Style.Add("border", "solid 1px red");
                TxtBox_NewPass.Style.Add("border", "solid 1px red");
                TxtBox_ConfirmNewPass.Style.Add("border", "solid 1px red");

            }

        }

    }
}