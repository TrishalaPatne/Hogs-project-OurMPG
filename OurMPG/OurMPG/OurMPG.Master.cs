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
            if (Session["UserId"] == null)
            {
                listGasStation.Visible = false;
                listVehicle.Visible = false;
                listAdminReports.Visible = false;
            }
            else
            {
                int userid = Convert.ToInt32(Session["UserId"]);
                selectCommand.Parameters.Add("@userId", SqlDbType.VarChar).Value = userid;

                sqlConnection.Open();
                int roleId = (int)selectCommand.ExecuteScalar();
                //role 1 user, so we hide admin screens
                if(roleId == 1)
                {
                    listLogin.Visible = false;
                    listRegister.Visible = false;
                    listUserReports.Visible = true;
                    listGasStation.Visible = false;
                    listVehicle.Visible = false;
                    listAdminReports.Visible = false;
                }
                // role 2 admin
                else if (roleId == 2)
                {
                    listGasStation.Visible = true;
                    listVehicle.Visible = true;
                    listUserReports.Visible = true;
                    listAdminReports.Visible = true;
                }
            }
    }
    }
}