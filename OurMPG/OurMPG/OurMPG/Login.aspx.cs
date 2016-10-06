using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace OurMPG
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Goto OurMPG Home if User is Authenticated

        }

        private bool OurMPGValidationFunction(string UserName, string Password)
        {
            bool boolReturnValue = false;

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            String SQLQuery = "SELECT UserName, UserPassword FROM UserLogin";
            SqlCommand command = new SqlCommand(SQLQuery, sqlConnection);
            SqlDataReader Dr;
            sqlConnection.Open();
            Dr = command.ExecuteReader();
            while (Dr.Read())
            {
                if ((UserName == Dr["UserName"].ToString()) & (Password == Dr["UserPassword"].ToString()))
                {
                    boolReturnValue = true;
                }
                Dr.Close();
                return boolReturnValue;
            }
            return boolReturnValue;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (OurMPGValidationFunction(Login1.UserName, Login1.Password))
            {
                // e.Authenticated = true;
                Login1.Visible = false;
                Response.Redirect("OurMPGHome.aspx");
            }
            else
            {
                e.Authenticated = false;
            }
        }
    
    }
}