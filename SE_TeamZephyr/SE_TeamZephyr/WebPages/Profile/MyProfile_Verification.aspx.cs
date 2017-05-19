using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_TeamZephyr.Profile
{
    public partial class MyProfile_Verification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                using (var context = new IdentityDBContext())
                {
                    var currentUserID = Context.User.Identity.GetUserId();

                    ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == currentUserID);

                    p_email.InnerText = "Your email address: " + currentUser.Email;
                    p_number.InnerText = "Your mobile number: " + currentUser.MobileNumber;
                }
            }

        }
    }
  }