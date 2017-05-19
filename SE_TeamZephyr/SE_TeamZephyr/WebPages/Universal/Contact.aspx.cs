using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Models;
using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.IO;
using System.Net;
using System.Xml;
using SE_TeamZephyr.Services;
//using static SE_TeamZephyr.Helpers.Preferences;

namespace SE_TeamZephyr
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendMail()
        {
            // Gmail Address from where you send the mail
            var fromAddress = "qubse16@gmail.com";
            // any address where the email will be sending
            var toAddress = UserEmail.Text.ToString();
            //Password of your gmail address
            const string fromPassword = "TeamZephyr1";
            // Passing the values and make a email formate to display
            string subject = "Contact Form Enquiry - Autom8";
            string text1 = "This is an automated response from AUTOM8" + "\n";
            string text2 = "This email is to notify you that we have received your contact form. " + "\n";
            string text3 = "You will recieve a reply within 48 hours. Many thanks - The Autom8 Team " + "\n" + "\n";
            string text4 = "Your enquiry is shown below: " + "\n" + "\n";
            string body = text1 + text2 + text3 + text4;
            string content = "Contact form submitted by: " + UserName.Text + " " + UserEmail.Text + "\n";
            body += "Subject: " + "\n" + UserSubject.Text + "\n";
            body += "Comments : " + "\n" + UserComment.Text;


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
            smtp.Send(fromAddress, toAddress, subject, body);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //add values from form to the database
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\SE_TeamZephyr.Models.Autom8AppDBContext.mdf;Integrated Security=True";

            Autom8DBAppContext11 _db = new Autom8DBAppContext11();

            if (UserName.Text == null || UserEmail.Text == "" || UserSubject.Text == "" ||
            UserComment.Text == "")
            {
                FormError.Text = "Please fill out all the required fields.";
            }
            else
            {
                SendMail();
                //string query = "INSERT INTO Journeys (AreaID, JourneyName, Description, JourneyPrice, SeatsAvailable) VALUES(@area, @journeyName, @journeyDescription, @journeyPrice, @seatsAvailable)";

                //SqlCommand myCommand = new SqlCommand(query, myConnection);

                ContactFormService cfs = new ContactFormService();

                cfs.createContactForm(UserName.Text, UserEmail.Text, UserSubject.Text, UserComment.Text, "Unassigned");

                UserName.Text = "";
                UserEmail.Text = "";
                UserSubject.Text = "";
                UserComment.Text = "";
            }
        }
    }
}






