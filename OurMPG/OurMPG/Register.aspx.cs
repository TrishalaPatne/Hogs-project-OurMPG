using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Data;

namespace OurMPG
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            String selectQuery = "SELECT userId, userName, password FROM userInfo WHERE userName = '" + txtNewUserName.Text + "'";
            SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
            SqlDataReader Dr;
            sqlConnection.Open();
            Dr = selectCommand.ExecuteReader();
            if (Dr.HasRows)
            {
                lblMsg2.Text = "This User Name already exists";
                sqlConnection.Close();
            }
            else if (txtNewPwd.Text == txtNewValidatePwd.Text)
            {
                sqlConnection.Close();
                var md5 = new MD5CryptoServiceProvider();
                byte[] md5Pwd = md5.ComputeHash(Encoding.UTF8.GetBytes(txtNewPwd.Text));
                string passwordString = System.Text.Encoding.UTF8.GetString(md5Pwd);
                DateTime currentDate = DateTime.Now;

                String insertQuery = "INSERT INTO userInfo(roleId, userName, password, fullName, eMail, dob, gender, incomeBracket, homeOwner, householdSize, createdBy, createdDate) VALUES (1, @UserName, @Password, @FullName, @Email, @Dob, @Gender, @IncomeBracket, @HomeOwner, @HouseholdSize, 'ADMIN', @currentDate)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtNewUserName.Text;
                insertCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = passwordString;
                insertCommand.Parameters.Add("@FullName", SqlDbType.VarChar).Value = txtName.Text;
                insertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                insertCommand.Parameters.Add("@Dob", SqlDbType.Date).Value = txtDob.Text;
                insertCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = drpGender.Text;
                insertCommand.Parameters.Add("@IncomeBracket", SqlDbType.VarChar).Value = drpIncomeBracket.Text;
                insertCommand.Parameters.Add("@HomeOwner", SqlDbType.VarChar).Value = drpHomeOwner.Text;
                insertCommand.Parameters.Add("@HouseholdSize", SqlDbType.Int).Value = txtHouseholdSize.Text;
                insertCommand.Parameters.Add("@currentDate", SqlDbType.Date).Value = currentDate;

                sqlConnection.Open();
                insertCommand.ExecuteNonQuery();

                /*Session["userId"] = Dr["userId"].ToString();*/

                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMsg2.Text = "Passwords did not match";
                sqlConnection.Close();
            }
        }
    }
}