using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace OurMPG
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Goto OurMPG Home if User is Authenticated
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            String SQLQuery = "SELECT userId, userName, password FROM userInfo WHERE userName = @userName AND password = @password";
            SqlCommand command = new SqlCommand(SQLQuery, sqlConnection);

            var md5 = new MD5CryptoServiceProvider();
            byte[] md5Pwd = md5.ComputeHash(Encoding.UTF8.GetBytes(txtPwd.Text));
            string passwordString = System.Text.Encoding.UTF8.GetString(md5Pwd);

            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUserName.Text;
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = passwordString;

            SqlDataReader Dr;
            sqlConnection.Open();
            Dr = command.ExecuteReader();
            
            if (Dr.HasRows)
            {
                while (Dr.Read())
                {
                    Session["userId"] = Dr["userId"].ToString();

                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                lblMsg1.Text = "Please enter a valid Username and Password.";
            }
            Dr.Close();
            sqlConnection.Close();
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
    }
