using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE_TeamZephyr.Services;
using Microsoft.AspNet.Identity;
using System.Net;

namespace SE_TeamZephyr.Checkout
{
    public partial class CheckoutComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verify user has completed the checkout process.
                if ((string)Session["userCheckoutCompleted"] != "true")
                {
                    Session["userCheckoutCompleted"] = string.Empty;
                    Response.Redirect("CheckoutError.aspx?" + "Desc=Unvalidated%20Checkout.");
                }

                NVPAPICaller payPalCaller = new NVPAPICaller();

                string retMsg = "";
                string token = "";
                string finalPaymentAmount = "";
                string PayerID = "";
                NVPCodec decoder = new NVPCodec();

                token = Session["token"].ToString();
                PayerID = Session["payerId"].ToString();
                finalPaymentAmount = Session["payment_amt"].ToString();

                bool ret = payPalCaller.DoCheckoutPayment(finalPaymentAmount, token, PayerID, ref decoder, ref retMsg);
                if (ret)
                {
                    // Retrieve PayPal confirmation value.
                    string PaymentConfirmation = decoder["PAYMENTINFO_0_TRANSACTIONID"].ToString();
                    TransactionId.Text = PaymentConfirmation;
                    Autom8DBAppContext11 _db = new Autom8DBAppContext11();
                    // Get the current order id.
                    int currentOrderId = -1;
                    if (Session["currentOrderId"].ToString() != string.Empty)
                    {
                        currentOrderId = Convert.ToInt32(Session["currentOrderID"]);
                    }
                    PayPalOrder myCurrentOrder;
                    if (currentOrderId >= 0)
                    {
                        // Get the order based on order id.
                        myCurrentOrder = _db.Orders.Single(o => o.OrderId == currentOrderId);
                        // Update the order to reflect payment has been completed.
                        myCurrentOrder.PaymentTransactionId = PaymentConfirmation;
                        // Save to DB.
                        _db.SaveChanges();
                    }

                    // Clear shopping cart.
                    using (SE_TeamZephyr.Logic.JourneyBasketActions userShoppingCart = new SE_TeamZephyr.Logic.JourneyBasketActions())
                    {
                        userShoppingCart.EmptyCart();
                    }

                    // Clear order id.
                    Session["currentOrderId"] = string.Empty;
                }
                else
                {
                    Response.Redirect("CheckoutError.aspx?" + retMsg);
                }
            }
        }

        protected void Continue_Click(object sender, EventArgs e)
        {
            AspNetUserService us = new AspNetUserService();
            
            var user = us.retrieveUser(Context.User.Identity.GetUserId());

            var username= user.UserName;
            SendMail(username);
            Response.Redirect("~/Webpages/Default.aspx");
        }

        protected void SendMail(string username)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "qubse16@gmail.com";
            //Password of your gmail address
            const string fromPassword = "TeamZephyr1";
            // Passing the values and make a email formate to display
            string subject = "Payment Successfully- Autom8";
            string text1 = "You have successfully paid for your journey with autom8" + "\n";

            string text2 = "Please log in to view more info - Thanks, The Autom8 Team " + "\n" + "\n";

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
            smtp.Send(fromAddress, username, subject, body);
        }

    }
}
