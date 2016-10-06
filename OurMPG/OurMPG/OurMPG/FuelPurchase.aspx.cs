using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OurMPGBusiness;

namespace OurMPG
{
    public partial class FuelPurchase : System.Web.UI.Page
    {
        OurMPGBusiness.Class1 oClassBusiness;
    public FuelPurchase()
        {
            oClassBusiness = new Class1();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            //Checking  for length of 0 for vehicle id to ensure
            //user does not enter blank values in to my database
            if (txtVehicleId.Text.Length == 0)
            {

                lblErrorMessage.Text = "Please Enter your Vehicle ID";

            }
                   
            else
            {

                if (oClassBusiness.SaveData(txtVehicleId.Text) == false)
                {
                    lblErrorMessage.Text = "Check your data for correctness";
                }
                else
                {
                    lblErrorMessage.Text = "Record Successfully Entered";
                }
               
            }
        }

        protected void txtVehicleId_TextChanged(object sender, EventArgs e)
        {

        }

        //text box behavior here

    }
}