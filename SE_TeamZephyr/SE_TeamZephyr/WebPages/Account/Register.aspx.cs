using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SE_TeamZephyr.Models;
using System.Net;

namespace SE_TeamZephyr.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text, FirstName = FirstName.Text, LastName = LastName.Text};
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                SendMail(Email.Text);
                Response.Redirect("~/WebPages/Account/Login.aspx");
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
               
                Response.Redirect("~/WebPages/Account/Login.aspx");
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void SendMail(string Email)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "qubse16@gmail.com";
            //Password of your gmail address
            const string fromPassword = "TeamZephyr1";
            // Passing the values and make a email formate to display
            string subject = "Account Creation- Autom8";
            string text1 = "You have successfully been registered to autom8" + "\n";

            string text2 = "Please log in to start using our services. - Thanks, The Autom8 Team " + "\n" + "\n";

            string body = text1 + text2;
            string content = body;

            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, Email, subject, body);
        }

    }
}