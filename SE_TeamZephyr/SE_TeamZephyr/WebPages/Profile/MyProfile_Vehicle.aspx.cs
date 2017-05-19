using SE_TeamZephyr.Models;
using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE_TeamZephyr.Helpers;
using SE_TeamZephyr.Helpers.VehicleJson;

namespace SE_TeamZephyr.Profile
{
    public partial class MyProfile_Vehicle : System.Web.UI.Page
    {
        // Bool check if user already had a Vehicle, assuming false
        public bool vehicleExists = false;
        VehicleService vs = new VehicleService();
        VehicleActions va = new VehicleActions();
        Vehicle vehicle;

        protected void Page_Load(object sender, EventArgs e)
        {
            vehicle = vs.retrieveVehicleForUser(Context.User.Identity.GetUserId());

            if (vehicle != null)
            {
                vehicleExists = true;
            }

            if (!IsPostBack)
            {
                if (vehicleExists)
                {
                    Label_VehicleMake.Text = vehicle.Make;
                    Label_VehicleModel.Text = vehicle.Model;
                    Label_VehiclePlate.Text = vehicle.Vrm;
                    Label_VehicleColour.Text = vehicle.Colour;
                    Label_VehicleSeats.Text = vehicle.NumberOfSeats.ToString();
                    Label_VehicleFuelType.Text = vehicle.FuelType;
                    Label_VehicleCO2Emissions.Text = vehicle.Co2EmissionsPerGallon.ToString();
                    Label_VehicleLitresPerKilometer.Text = vehicle.LitresPerKilometer.ToString();
                }
            }
        }

        protected void Save_Button_Click(object sender, EventArgs e)
        {

            if (TxtBox_PlateNumber.Text == "")
            {
                VehicleError.Text = "Please enter a Plate Number!";
            }
            else if (TxtBox_PlateNumber.Text.Length != 7 && TxtBox_PlateNumber.Text.Length != 8)
            {
                VehicleError.Text = "Please enter a UK number plate!";
            }
            else if (!TxtBox_PlateNumber.Text.Replace(" ", String.Empty).All(Char.IsLetterOrDigit))
            {
                VehicleError.Text = "Plate number can only contain Alpha Numeric Characters";
            }
            else if (vehicleExists)
            {
                vehicle = vs.retrieveVehicleForUser(Context.User.Identity.GetUserId());
                var v = va.getVehicleData(TxtBox_PlateNumber.Text);
                if (v.Response == null)
                {
                    VehicleError.Text = "That data related to that license plate is malformed in some way, please check the plate, or contact our team.";
                }
                else if (v.Response.StatusCode == "Success")
                {
                    vs.updateVehicle(vehicle.VehicleID, Context.User.Identity.GetUserId(), v.Response.DataItems.VehicleRegistration.Colour, v.Response.DataItems.VehicleRegistration.Model, v.Response.DataItems.VehicleRegistration.Make, v.Response.DataItems.VehicleRegistration.Vrm, v.Response.DataItems.VehicleRegistration.FuelType, v.Response.DataItems.TechnicalDetails.Performance.Co2, v.Response.DataItems.TechnicalDetails.Consumption.Combined.Lkm, v.Response.DataItems.TechnicalDetails.Dimensions.NumberOfSeats - 1);
                }
                else
                {
                    VehicleError.Text = "Something went wrong there : " + v.Response.StatusInformation.Lookup.StatusMessage;
                }
            }
            else
            {
                var v = va.getVehicleData(TxtBox_PlateNumber.Text.Replace(" ", string.Empty));
                if (v.Response == null)
                {
                    VehicleError.Text = "Something is wrong with the external API. Try again later.";
                }
                else if(v.Response.StatusCode != "Success")
                {
                    VehicleError.Text = "Something went wrong there : " + v.Response.StatusInformation.Lookup.StatusMessage;
                }
                else
                {
                    vs.createVehicle(Context.User.Identity.GetUserId(), v.Response.DataItems.VehicleRegistration.Colour, v.Response.DataItems.VehicleRegistration.Model, v.Response.DataItems.VehicleRegistration.Make, v.Response.DataItems.VehicleRegistration.Vrm, v.Response.DataItems.VehicleRegistration.FuelType, v.Response.DataItems.TechnicalDetails.Performance.Co2, v.Response.DataItems.TechnicalDetails.Consumption.Combined.Lkm, v.Response.DataItems.TechnicalDetails.Dimensions.NumberOfSeats - 1);
                }
            }
        }
    }
}