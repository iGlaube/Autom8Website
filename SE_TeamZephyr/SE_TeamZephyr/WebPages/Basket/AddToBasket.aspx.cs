using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using SE_TeamZephyr.Logic;

namespace SE_TeamZephyr
{
    public partial class AddToBasket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["JourneyID"];
            int journeyId;
            if (Request.IsAuthenticated)
            {

                if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out journeyId))
                {
                    using (JourneyBasketActions usersShoppingCart = new
                   JourneyBasketActions())
                    {
                        usersShoppingCart.EmptyCart();
                        usersShoppingCart.AddToBasket(Convert.ToInt16(rawId));
                    }
                }
                else
                {
                    Debug.Fail("ERROR : We should never get to AddToBasket.aspx without a JourneyId.");
                    throw new Exception("ERROR : It is illegal to load AddToBasket.aspx without setting a ProductId.");
                }
                Response.Redirect("JourneyBasket.aspx");
            }
            else
            {
                Response.Redirect("Account/Login.aspx");
            }
        }
    }
}