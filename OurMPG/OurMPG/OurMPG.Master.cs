using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace OurMPG
{
    public partial class OurMPG : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            String selectQuery = "SELECT DISTINCT roleId FROM userInfo WHERE userId = @userId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
            try
            {
                if (Session["UserId"] == null)
                {
                    listGasStation.Visible = false;
                    listVehicle.Visible = false;
                    listFuelPurchase.Visible = false;
                    listAdminReports.Visible = false;
                    listUserReports.Visible = false;
                    listLogout.Visible = false;
                }
                else
                {
                    int userid = Convert.ToInt32(Session["UserId"]);
                    selectCommand.Parameters.Add("@userId", SqlDbType.VarChar).Value = userid;
                    listLogin.Visible = false;
                    listRegister.Visible = false;
                    sqlConnection.Open();
                    int roleId = (int)selectCommand.ExecuteScalar();
                    // role 1 is user, admin screens is hidden
                    if (roleId == 1)
                    {
               
                        listGasStation.Visible = false;
                        listVehicle.Visible = false;
                        listAdminReports.Visible = false;
                        listFuelPurchase.Visible = true;
                        listUserReports.Visible = true;
                        listLogout.Visible = true;
                    }
                    else if (roleId == 2)
                    {
                        listGasStation.Visible = true;
                        listVehicle.Visible = true;
                        listAdminReports.Visible = true;
                        listUserReports.Visible = true;
                        listFuelPurchase.Visible = true;
                        listLogout.Visible = true;
                    }
                }
            }
            catch
            {
                Response.Redirect("Error.aspx");
            }
            finally
            {
                sqlConnection.Close();
            }
    }
    }
}