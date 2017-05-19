using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Models;
using SE_TeamZephyr.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_TeamZephyr
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        if(!IsPostBack) {

                // Code for filling the age drop down list
                AgeList.Items.Add(" ");
                for (int i = 16; AgeList.Items.Count < 99; i++)
                {

                    var currentYear = DateTime.Today.Year;
                    currentYear = currentYear - i;
                    AgeList.Items.Add(currentYear.ToString());

                }


                // Fill areas, only do it if it's the first time loading the page
                // Check if it's postback so values don't get reset on the save button click

                AspNetUserService userService = new AspNetUserService();

                var currentUserID = Context.User.Identity.GetUserId();
                var currentUser = userService.retrieveUser(currentUserID);


                    TxtBox_Email.Text = currentUser.Email;
                    TxtBox_Title.Text = currentUser.Title;
                    TxtBox_FirstName.Text = currentUser.FirstName;
                    TxtBox_Surname.Text = currentUser.LastName;
                    AgeList.SelectedValue = currentUser.YearOfBirth;
                    TxtBox_HomePhone.Text = currentUser.HomeNumber;
                    TxtBox_MobilePhone.Text = currentUser.MobileNumber;
                    TxtBox_Add1.Text = currentUser.AddressLine1;
                    TxtBox_Add2.Text = currentUser.AddressLine2;
                    TxtBox_Citown.Text = currentUser.CityTown;
                    TxtBox_Postcode.Text = currentUser.PostCode;
            }

        }

        // This button will send all of the field data into the user table to update
        protected void Save_Button_Click(object sender, EventArgs e)
        {

            string test = TxtBox_FirstName.Text;

            AspNetUserService userService = new AspNetUserService();

            var currentUserID = Context.User.Identity.GetUserId();
            var currentUser = userService.retrieveUser(currentUserID);

            // Fill all of the user data with the appropriate information
            userService.updateUserBasicInfo(currentUserID, TxtBox_FirstName.Text, TxtBox_Surname.Text, TxtBox_Title.Text, AgeList.SelectedValue.ToString(),
                TxtBox_HomePhone.Text, TxtBox_MobilePhone.Text, TxtBox_Add1.Text, TxtBox_Add2.Text,
                TxtBox_Citown.Text, TxtBox_Postcode.Text, BioMessage.Value, TxtBox_Email.Text);
        }
    }
}