using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Web.Configuration;

namespace OurMPG
{
    public partial class Vehicle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void clearform()
        {
            make.Value = "";
            model.Value = "";
            year.Value = "";
            transmission.Value = "";
            displ.Value = "";
            cyl.Value = "";
            drivingstyle.Value = "";
            vclass.Value = "";
            citympg.Value = "";
            highwaympg.Value = "";
            combmpg.Value = "";
        }
        //saves vehicle record
        protected void saveVehicle(object sender, EventArgs e)
        {
            
            int rowsaffected = 0;
            DateTime now = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "INSERT INTO vehicle (make,model,year,transmission,Displ,Cyl,driveStyle,VehicleClass,epaCityMPG,epaHwyMPG,epaCmbMPG,createdBy,createdDate) VALUES (@make, @model, @year, @transmission, @disp, @cyl, @drivestyle, @vclass, @citympg, @hwympg, @cmbmpg, @createdBy, @createdDate)";
                    command.Parameters.AddWithValue("@make", make.Value);
                    command.Parameters.AddWithValue("@year", year.Value);
                    command.Parameters.AddWithValue("@model", model.Value);
                    command.Parameters.AddWithValue("@transmission", transmission.Value);
                    command.Parameters.AddWithValue("@disp", displ.Value);
                    command.Parameters.AddWithValue("@cyl", cyl.Value);
                    command.Parameters.AddWithValue("@drivestyle", drivingstyle.Value);
                    command.Parameters.AddWithValue("@vclass", vclass.Value);
                    command.Parameters.AddWithValue("@citympg", citympg.Value);
                    command.Parameters.AddWithValue("@hwympg", highwaympg.Value);
                    command.Parameters.AddWithValue("@cmbmpg", combmpg.Value);
                    command.Parameters.AddWithValue("@createdBy", "admin");
                    command.Parameters.AddWithValue("@createdDate", now.ToString());

                    try
                    {
                        connection.Open();
                        rowsaffected = command.ExecuteNonQuery();
                        
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Error.aspx");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            if (rowsaffected > 0)
            {
                //shows success pop up
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                clearform();
            }
            else
            {
                //shows error dialog
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "showErrorDialog();", true);
            }  
        }
    }
}