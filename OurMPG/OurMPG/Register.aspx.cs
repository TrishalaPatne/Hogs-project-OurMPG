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
using System.Diagnostics;

namespace OurMPG
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Hide the Address and Garage Panel on first load*/

            addressPanel.Visible = false;
            myGaragePanel.Visible = false;

            /*Bind dropdown on every load*/

            if (!this.IsPostBack)
            {
                bindMakeDropdown();
            }
        }

        /*Used to create the User Account with unique username and encrypted password*/
         
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            String selectQuery = "SELECT userId, userName, password FROM userInfo WHERE userName = @checkUserName";
            SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
            selectCommand.Parameters.Add("@checkUserName", SqlDbType.VarChar).Value = txtNewUserName.Text;
            SqlDataReader Dr;
            sqlConnection.Open();
            Dr = selectCommand.ExecuteReader();
            if (Dr.HasRows)
            {
                lblMsg1.Text = "This User Name already exists";
                sqlConnection.Close();
            }
            else if (txtNewPwd.Text == txtNewValidatePwd.Text)
            {
                sqlConnection.Close();
                var md5 = new MD5CryptoServiceProvider();
                byte[] md5Pwd = md5.ComputeHash(Encoding.UTF8.GetBytes(txtNewPwd.Text));
                string passwordString = System.Text.Encoding.UTF8.GetString(md5Pwd);
                DateTime currentDate = DateTime.Now;
                int sessionUserId = 0;
                string sessionUserName = txtNewUserName.Text;

                String insertQuery = "INSERT INTO userInfo(roleId, userName, password, fullName, eMail, dob, gender, incomeBracket, homeOwner, householdSize, createdBy, createdDate) output INSERTED.userId VALUES (1, @UserName, @Password, @FullName, @Email, @Dob, @Gender, @IncomeBracket, @HomeOwner, @HouseholdSize, @UserName, @currentDate)";
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

                try
                {
                    sqlConnection.Open();
                    sessionUserId = (int)insertCommand.ExecuteScalar();
                    lblMsg1.Text = String.Empty;
                    lblMsg2.Text = String.Empty;

                    Session["UserId"] = sessionUserId;
                    Session["UserName"] = sessionUserName;

                    if (sessionUserId > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "showConfirmDialog();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "showErrorDialog();", true);
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
            else
            {
                lblMsg2.Text = "Passwords did not match";
                sqlConnection.Close();
            }
        }

        
        /* Shows the Address Panel on click from the dialog box*/
        protected void btnContinueAddress_Click(object sender, EventArgs e)
        {
            addressPanel.Visible = true;
        }

        /*Stores the work and home location for the user*/
        protected void btnAddAddress_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            try { 
            
            String insertHomeQuery = "INSERT INTO location(zipCode, streetAddress, latitude, longtitude, city, state, sourceIndicator, createdBy, createdDate) output INSERTED.locationId VALUES (@ZipCode, @StreetAddress, @Latitude, @Longtitude, @City, @State, 1, @UserName, @currentDate)";
            SqlCommand insertHomeCommand = new SqlCommand(insertHomeQuery, sqlConnection);
            insertHomeCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = txtHomeZip.Text;
            insertHomeCommand.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = txtHomeStreetAddress.Text;
            insertHomeCommand.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = txtHomeLat.Text;
            insertHomeCommand.Parameters.Add("@Longtitude", SqlDbType.VarChar).Value = txtHomeLong.Text;
            insertHomeCommand.Parameters.Add("@City", SqlDbType.VarChar).Value = txtHomeCity.Text;
            insertHomeCommand.Parameters.Add("@State", SqlDbType.VarChar).Value = txtHomeState.Text;
            insertHomeCommand.Parameters.Add("@currentDate", SqlDbType.Date).Value = currentDate;
            insertHomeCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtNewUserName.Text;

            
                sqlConnection.Open();
                int idHome = (int)insertHomeCommand.ExecuteScalar();

                String updateHomeQuery = "UPDATE userInfo SET locationIdHome = @locationIdHome WHERE userName = @userName";
                SqlCommand updateHomeCommand = new SqlCommand(updateHomeQuery, sqlConnection);
                updateHomeCommand.Parameters.Add("@locationIdHome", SqlDbType.VarChar).Value = idHome;
                updateHomeCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = txtNewUserName.Text;

                updateHomeCommand.ExecuteNonQuery();

                String insertWorkQuery = "INSERT INTO location(zipCode, streetAddress, latitude, longtitude, city, state, sourceIndicator, createdBy, createdDate) output INSERTED.locationId VALUES (@ZipCode, @StreetAddress, @Latitude, @Longtitude, @City, @State, 2, @UserName, @currentDate)";
                SqlCommand insertWorkCommand = new SqlCommand(insertWorkQuery, sqlConnection);
                insertWorkCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = txtWorkZip.Text;
                insertWorkCommand.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = txtWorkStreetAddress.Text;
                insertWorkCommand.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = txtWorkLat.Text;
                insertWorkCommand.Parameters.Add("@Longtitude", SqlDbType.VarChar).Value = txtWorkLong.Text;
                insertWorkCommand.Parameters.Add("@City", SqlDbType.VarChar).Value = txtWorkCity.Text;
                insertWorkCommand.Parameters.Add("@State", SqlDbType.VarChar).Value = txtWorkState.Text;
                insertWorkCommand.Parameters.Add("@currentDate", SqlDbType.Date).Value = currentDate;
                insertWorkCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtNewUserName.Text;

                int idWork = (int)insertWorkCommand.ExecuteScalar();

                String updateWorkQuery = "UPDATE userInfo SET locationIdWork = @locationIdWork WHERE userName = @userName";
                SqlCommand updateWorkCommand = new SqlCommand(updateWorkQuery, sqlConnection);
                updateWorkCommand.Parameters.Add("@locationIdWork", SqlDbType.VarChar).Value = idWork;
                updateWorkCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = txtNewUserName.Text;

                updateWorkCommand.ExecuteNonQuery();
            

                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "showNextDialog();", true);
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

        /*Shows address and car panel for the user to enter car details*/

        protected void btnContinueGarage_Click(object sender, EventArgs e)
        {
            addressPanel.Visible = true;
            myGaragePanel.Visible = true;
        }

        /*Renders Make dropdown on Page Load*/

        protected void bindMakeDropdown()
        {
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                    sqlConnection.Open();
                    SqlCommand drpCommand = new SqlCommand("SELECT DISTINCT make FROM vehicle", sqlConnection);
                    SqlDataAdapter drpAdapter = new SqlDataAdapter(drpCommand);
                    DataSet drpDS = new DataSet();
                    drpAdapter.Fill(drpDS);
                    sqlConnection.Close();
                   
                    drpMake.DataSource = drpDS;
                    drpMake.DataTextField = "make";
                    drpMake.DataValueField = "make";
                    drpMake.DataBind();

                    drpMake.Items.Insert(0, "--Select--");
                    
            /*catch (Exception ex)
            {
                // Handle the error
                Debug.WriteLine(ex.Message);
            }*/
        }

        /*Based on the Make, the Model dropdown values are rendered*/

        protected void drpMakeSelected_selectedIndexChanged(object sender, EventArgs e)
        {
            addressPanel.Visible = true;
            myGaragePanel.Visible = true;
            
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand drpCommand = new SqlCommand("SELECT DISTINCT model FROM vehicle WHERE make = @make", sqlConnection);
                SqlDataAdapter drpAdapter = new SqlDataAdapter(drpCommand);

                drpCommand.Parameters.Add("@make", SqlDbType.VarChar).Value = Convert.ToString(drpMake.SelectedValue);
                DataSet drpDS = new DataSet();

                drpAdapter.Fill(drpDS);
                sqlConnection.Close();

                drpModel.DataSource = drpDS;
                drpModel.DataTextField = "model";
                drpModel.DataValueField = "model";

                drpModel.DataBind();
                drpModel.Items.Insert(0, "--Select--");
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

        /*Renders the year based on the make and model*/

        protected void drpModelSelected_selectedIndexChanged(object sender, EventArgs e)
        {
            addressPanel.Visible = true;
            myGaragePanel.Visible = true;
            
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand drpCommand = new SqlCommand("SELECT DISTINCT year FROM vehicle WHERE make = @make and model = @model", sqlConnection);
                SqlDataAdapter drpAdapter = new SqlDataAdapter(drpCommand);
                DataSet drpDS = new DataSet();
                drpCommand.Parameters.Add("@make", SqlDbType.VarChar).Value = Convert.ToString(drpMake.SelectedValue); ;
                drpCommand.Parameters.Add("@model", SqlDbType.VarChar).Value = Convert.ToString(drpModel.SelectedValue);


                drpAdapter.Fill(drpDS);
                sqlConnection.Close();

                drpYear.DataSource = drpDS;
                drpYear.DataTextField = "year";
                drpYear.DataValueField = "year";
                drpYear.DataBind();

                drpYear.Items.Insert(0, "--Select--");
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

        /*Renders the car specifications based on the year, make and model*/

        protected void drpYearSelected_selectedIndexChanged(object sender, EventArgs e)
        {
            addressPanel.Visible = true;
            myGaragePanel.Visible = true;
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand drpCommand = new SqlCommand("SELECT DISTINCT vehicleid, CONCAT(transmission, ' ',Displ, ' ',Cyl, ' ',driveStyle, ' ', vehicleClass) AS specs FROM vehicle WHERE make = @make and model = @model and year = @year", sqlConnection);
                SqlDataAdapter drpAdapter = new SqlDataAdapter(drpCommand);
                DataSet drpDS = new DataSet();
                drpCommand.Parameters.Add("@make", SqlDbType.VarChar).Value = Convert.ToString(drpMake.SelectedValue); ;
                drpCommand.Parameters.Add("@model", SqlDbType.VarChar).Value = Convert.ToString(drpModel.SelectedValue);
                drpCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = Convert.ToString(drpYear.SelectedValue);


                drpAdapter.Fill(drpDS);
                sqlConnection.Close();

                drpSpecs.DataSource = drpDS;
                drpSpecs.DataTextField = "specs";
                drpSpecs.DataValueField = "vehicleId";
                drpSpecs.DataBind();

                drpSpecs.Items.Insert(0, "--Select--");
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

       /*Keeps the address and car panel visible on the page*/

        protected void drpSpecsSelected_selectedIndexChanged(object sender, EventArgs e)
        {
            addressPanel.Visible = true;
            myGaragePanel.Visible = true;
        }

        /*Keeps the address and car panel visible on the page*/
        protected void drpOwnerSelected_selectedIndexChanged(object sender, EventArgs e)
        {
            addressPanel.Visible = true;
            myGaragePanel.Visible = true;
        }

        /*Maps the car to the user*/

        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            addressPanel.Visible = true;
            myGaragePanel.Visible = true;
            DateTime currentDate = DateTime.Now;
            int userid = (int)Session["userId"];
            string vehicleId = drpSpecs.SelectedValue;
            int rowsaffected = 0;

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            String insertVehicleQuery = "INSERT INTO userVehicle(userId, vehicleId, vehicleName, color, ownershipStatus, createdBy, createdDate) VALUES (@userId, @vehicleId, @vehicleName, @color, @ownershipStatus, @userName, @currentDate)";
            SqlCommand insertVehicleCommand = new SqlCommand(insertVehicleQuery, sqlConnection);
            insertVehicleCommand.Parameters.Add("@userId", SqlDbType.VarChar).Value = userid;
            insertVehicleCommand.Parameters.Add("@vehicleId", SqlDbType.VarChar).Value = vehicleId;
            insertVehicleCommand.Parameters.Add("@vehicleName", SqlDbType.VarChar).Value = txtCarName.Text;
            insertVehicleCommand.Parameters.Add("@color", SqlDbType.VarChar).Value = txtColor.Text;
            insertVehicleCommand.Parameters.Add("@ownershipStatus", SqlDbType.VarChar).Value = drpOwner.Text;
            insertVehicleCommand.Parameters.Add("@currentDate", SqlDbType.Date).Value = currentDate;
            insertVehicleCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = (string)Session["UserName"];

            try
            {
                sqlConnection.Open();

                rowsaffected = insertVehicleCommand.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "showNextCarDialog();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "showErrorDialog();", true);
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

        /*Clears the selection if user owns another car*/
        protected void btnNextCarYes_Click(object sender, EventArgs e)
        {
            addressPanel.Visible = true;
            myGaragePanel.Visible = true;
            drpMake.SelectedIndex = 0;
            drpModel.SelectedIndex = 0;
            drpYear.SelectedIndex = 0;
            drpSpecs.SelectedIndex = 0;
            drpOwner.SelectedIndex = 0;
            txtColor.Text = String.Empty;
            txtCarName.Text = String.Empty;
        }

        /*Redirects user to Home if he does not own another car thus by completing Registration*/

        protected void btnNextCarNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}