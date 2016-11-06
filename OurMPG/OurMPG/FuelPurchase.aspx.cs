using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using System.Web.Configuration;
namespace OurMPG
{
    public partial class FuelPurchase : System.Web.UI.Page
    {
     
        FuelPurchaseBusiness m_oBusiness;
        FuelPurchaseDAL m_oDAL;
        DataSet oVehicleSet = new DataSet();
        DataSet oStateSet = new DataSet();
        DataSet oCitySet = new DataSet();
        DataSet oZipCodeSet = new DataSet();
        DataSet oAddressSet = new DataSet();
        DataSet oFuelTypeSet = new DataSet();
        DataSet oGasStationNames = new DataSet();
        public FuelPurchase()
        {
            m_oBusiness = new FuelPurchaseBusiness();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           //Check for postback. Autopostback on some controls not available to set to false.
            if (!Page.IsPostBack)
            //On Page Load Load the vehicle data based on the user id.
            PopulateControls();
        }
        public void btnSubmit_Click(object sender, EventArgs e)
        {
            //Validation of input data
            //Odometer meter reading.
            string sUserId = string.Empty;
            int RetVal;
           if (Convert.ToInt32(HighWayDriving.Value) + Convert.ToInt32(CityDriving.Value) > 100)
            {
                Label2.Text = "Percentage cannot be > 100";
            }
            else
            {
                if (Session["userId"] != null)
                    sUserId = Session["userId"].ToString();
                m_oBusiness = new FuelPurchaseBusiness();
                RetVal = m_oBusiness.InsertFuelPurchase(selectVehicle.Value.Trim(), sUserId, selectGasStation.Value.Trim(), dateofpurchase.Value, odometer.Value, selectZipcode.Value, selectStreetAddress.Value, Convert.ToInt32(totGallonsofFulPurchased.Value), timeofpurchase.Value, Convert.ToInt32(CityDriving.Value), Convert.ToInt32(HighWayDriving.Value), notes.Value, sUserId, System.DateTime.Now.Date.ToString(), sUserId, System.DateTime.Now.Date.ToString(), selectFuelType.Value);
                if (RetVal == 0)
                {
                    Label3.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                }
                else
                    Label3.Text = " Odometer Reading needs to be higher than previously entered value of: " + RetVal.ToString();
                //Clear Values
                selectVehicle.Value = "";
                dateofpurchase.Value = "";
                timeofpurchase.Value = "";
                selectState.Value = "";
                selectCity.Value = "";
                selectZipcode.Value = "";
                selectStreetAddress.Value = "";
                selectGasStation.Value = "";
                selectFuelType.Value = "";
                odometer.Value = "";
                totGallonsofFulPurchased.Value = "";
                HighWayDriving.Value = "";
                CityDriving.Value = "";
                notes.Value = "";
            }    
        }

        private void PopulateControls()
        {
            string sUserId = string.Empty;
            if (Session["userId"] != null)
                sUserId = Session["userId"].ToString();
            //Now retrieve state values
            try
            {
                //Now retrieve Vehicle values
                oVehicleSet = m_oBusiness.RetrieveVehicleNames(sUserId);                
                selectVehicle.DataSource = oVehicleSet;
                selectVehicle.DataTextField = "VehicleName";
                selectVehicle.DataValueField = "VehicleName";
                selectVehicle.DataBind();
                //Now retrieve state values
                oStateSet = m_oBusiness.RetrieveStateNames();
                selectState.DataSource = oStateSet;
                selectState.DataTextField = "StateValue";
                selectState.DataValueField = "StateValue";
                selectState.DataBind();
                //Now retrieve City values
                PopulateCity();
                //Now retrieve ZipCode values
                PopulateZip();
                //Now retrieve Address values
                PopulateAddress();
                //Now retrieve GasStation values
                PopulateGasStation();
                //Now retrieve FuelType values
                PopulateFuelType();
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
                throw;
            }
        }
        public void PopulateFuelType()
        {
            try
            {
                oFuelTypeSet = m_oBusiness.RetrieveFuelTypes(selectGasStation.Value.ToString().Trim(), selectZipcode.Value, selectStreetAddress.Value.ToString().Trim());
                selectFuelType.DataSource = oFuelTypeSet;
                selectFuelType.DataTextField = "FuelTypes";
                selectFuelType.DataValueField = "FuelTypes";
                selectFuelType.DataBind();
            }
           catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
                throw;
            }
        }
        public void PopulateCity()
        {
            try
            {
                oCitySet = m_oBusiness.RetrieveCityNames(selectState.Value.ToString().Trim());
                selectCity.DataSource = oCitySet;
                selectCity.DataTextField = "CityValue";
                selectCity.DataValueField = "CityValue";
                selectCity.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
                throw;
            }
        }
        public void PopulateZip()
        {
            try
            {
                //Retrieving zip codes by calling the business layer Retrievezipcode fucntion.
                //This takes two params as input values
                oZipCodeSet = m_oBusiness.RetrieveZipCode(selectState.Value.ToString().Trim(), selectCity.Value.ToString().Trim());
                // Assign the data source
                selectZipcode.DataSource = oZipCodeSet;
                //Code value being set to data text field and datavalue field
                selectZipcode.DataTextField = "ZipCodeValue";
                selectZipcode.DataValueField = "ZipCodeValue";
                //Finally call the databind function.
                selectZipcode.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
                throw;
            }

        }
        public void PopulateAddress()
        {
            try
            {
                //Now retrieve LocationAddress values
                oAddressSet = m_oBusiness.RetrieveLocationAddress(selectZipcode.Value.ToString().Trim());
                selectStreetAddress.DataSource = oAddressSet;
                selectStreetAddress.DataTextField = "AddressValue";
                selectStreetAddress.DataValueField = "AddressValue";
                selectStreetAddress.DataBind();
            }
          
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
                throw;
            }
        }
        public void PopulateGasStation()
        {
            try
            {
                oGasStationNames = m_oBusiness.RetrieveGasStationName(selectZipcode.Value.ToString().Trim(), selectStreetAddress.Value.ToString().Trim());
                selectGasStation.DataSource = oGasStationNames;
                selectGasStation.DataTextField = "gasStationName";
                selectGasStation.DataValueField = "gasStationName";
                selectGasStation.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
                throw;
            }
        }
       protected void selectState_ServerChange1(object sender, EventArgs e)
        {

            PopulateCity();
            PopulateZip();
            PopulateAddress();
            PopulateGasStation();
            PopulateFuelType();
        }
        protected void selectCity_ServerChange(object sender, EventArgs e)
        {
            PopulateZip();
            PopulateAddress();
            PopulateGasStation();
            PopulateFuelType();
        }

        protected void selectZipcode_ServerChange(object sender, EventArgs e)
        {
            PopulateAddress();
            PopulateGasStation();
            PopulateFuelType();
        }
        protected void selectStreetAddress_ServerChange(object sender, EventArgs e)
        {
            PopulateGasStation();
            PopulateFuelType();
        }
        protected void selectGasStation_ServerChange(object sender, EventArgs e)
        {
            PopulateFuelType();
        }
     
    }
}