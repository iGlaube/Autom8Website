using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE_TeamZephyr.Models;
using SE_TeamZephyr.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;
using System.Net;
using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Services;

namespace SE_TeamZephyr
{
    public partial class JourneyBasket : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            // Fill areas, only do it if it's the first time loading the page
            // Check if it's postback so values don't get reset on the save button click
            if (!IsPostBack)
            {
                using (JourneyBasketActions usersShoppingCart = new JourneyBasketActions())
                {
                    decimal basketTotal = 0;
                    basketTotal = usersShoppingCart.GetTotal();
                    if (basketTotal > 0)
                    {
                        // Display Total.
                        lblTotal.Text = String.Format("{0:c}", basketTotal);
                    }
                    else
                    {
                        LabelTotalText.Text = "";
                        lblTotal.Text = "";
                        ShoppingCartTitle.InnerText = "You have not added any journeys";
                        //UpdateBtn.Visible = false;
                        CheckoutImageBtn.Visible = false;

                    }
                }
            }
        }

        public List<BasketItem> GetJourneyBasketItems()
        {
            JourneyBasketActions actions = new JourneyBasketActions();
            return actions.GetBasketItems();
        }

        public List<BasketItem> UpdateBasketItems()
        {
            using (JourneyBasketActions usersShoppingCart = new JourneyBasketActions())
            {
                String basketId = usersShoppingCart.GetBasketId();
                JourneyBasketActions.JourneyBasketUpdates[] basketUpdates = new JourneyBasketActions.JourneyBasketUpdates[BasketList.Rows.Count];
                for (int i = 0; i < BasketList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(BasketList.Rows[i]);
                    basketUpdates[i].JourneyId = Convert.ToInt32(rowValues["JourneyID"]);
                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)BasketList.Rows[i].FindControl("Remove");
                    basketUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox seatsTextBox = new TextBox();
                    seatsTextBox = (TextBox)BasketList.Rows[i].FindControl("PurchaseSeats");
                    basketUpdates[i].PurchaseSeats = Convert.ToInt16(seatsTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateJourneyBasketDatabase(basketId, basketUpdates);
                BasketList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetBasketItems();
            }
        }

        public bool checkSeatCount(int journeyID, int requestedSeatCount)
        {
            using (Autom8DBAppContext11 _db = new Autom8DBAppContext11())
            {
                var currentJourneysSeatCount = _db.Journeys.Where(j => j.JourneyID == journeyID).FirstOrDefault().SeatsAvailable;
                if (requestedSeatCount > currentJourneysSeatCount)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell,
                   row.RowState, true);
                }
            }
            return values;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {

            using (JourneyBasketActions usersShoppingCart = new JourneyBasketActions())
            {
                String basketId = usersShoppingCart.GetBasketId();
                JourneyBasketActions.JourneyBasketUpdates[] basketUpdates = new JourneyBasketActions.JourneyBasketUpdates[BasketList.Rows.Count];
                for (int i = 0; i < BasketList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();

                    rowValues = GetValues(BasketList.Rows[i]);
                    basketUpdates[i].JourneyId = Convert.ToInt32(rowValues["JourneyID"]);

                    TextBox seatsTextBox = new TextBox();
                    seatsTextBox = (TextBox)BasketList.Rows[i].FindControl("PurchaseSeats");
                    basketUpdates[i].PurchaseSeats = Convert.ToInt16(seatsTextBox.Text.ToString());

                    if (checkSeatCount(basketUpdates[i].JourneyId, basketUpdates[i].PurchaseSeats))
                    {
                        //Do Nothing
                    }
                    else
                    {
                        JourneyBasketError.Text = "There are not enough seats available for your journey," + rowValues["JourneyName"]; ;
                        return;
                    }
                }
            }
            UpdateBasketItems();
        }

        public IQueryable<Journey> GetSeats([QueryString("seatsAvailable")] int?
       seatsAvailable)
        {
            var _db = new SE_TeamZephyr.Models.Autom8DBAppContext11();
            IQueryable<Journey> query = _db.Journeys;
            if (seatsAvailable.HasValue && seatsAvailable > 0)
            {
                query = query.Where(p => p.SeatsAvailable >= seatsAvailable);
            }
            else
            {
                query = null;
            }
            return query;
        }

        public ApplicationUser GetUser([QueryString("journeyID")] int? journeyId)
        {
            AspNetUserService us = new AspNetUserService();
            JourneyService js = new JourneyService();
            var journey = js.retrieveJourney(journeyId.Value);
            var user = us.retrieveUser(journey.UserID);
            return user;
        }

        protected void CheckoutBtn_Click(object sender, ImageClickEventArgs e)
        {

            using (SE_TeamZephyr.Logic.JourneyBasketActions usersShoppingCart = new SE_TeamZephyr.Logic.JourneyBasketActions())
            {
                Session["payment_amt"] = usersShoppingCart.GetTotal();
            }
            Response.Redirect("Checkout/CheckoutStart.aspx");
        }
    }
}
