using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace OurMPG
{
    public partial class Location : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void clearForm()
        {
            brand.Value = "";
            fuelprice.Value = "";
            fueltype.Value = "";
            zipcode.Value = "";
            streetaddr.Value = "";
            latitude.Value = "";
            longtitude.Value = "";
            city.Value = "";
            state.Value = "";
        }
        protected void getLocationID()
        {
            string sConnectionString = "Data Source=essql1.walton.uark.edu;Initial Catalog=MISGroup25;" + "Integrated Security = True";
            int locationId = 0;
            
            using (SqlConnection conn = new SqlConnection(sConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "Select locationId from location where state = @state and city = @city and zipCode = @zipCode and streetAddress = @streetAddr";
                    command.Parameters.AddWithValue("@state", state.Value);
                    command.Parameters.AddWithValue("@city", city.Value);
                    command.Parameters.AddWithValue("@zipCode", zipcode.Value);
                    command.Parameters.AddWithValue("@streetAddr", streetaddr.Value);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if(reader.HasRows)
                        {
                            if(reader.Read())
                            {
                                string loc = reader["locationId"].ToString();
                                locationId = Convert.ToInt32(loc);
                            }
                            
                        }
                        saveGasStation(locationId);
                        reader.Close();
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
           
        }
        protected void saveGasStation(int locationID)
        {
            string sConnectionString = "Data Source=essql1.walton.uark.edu;Initial Catalog=MISGroup25;" + "Integrated Security = True";
            int rowsaffected = 0;
            DateTime now = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "INSERT INTO gasStation (locationId,brandName,fuelType,fuelPrice,createdBy,createdDate) VALUES (@locationId, @brandName, @fuelType, @fuelPrice,@createdBy, @createdDate)";
                    command.Parameters.AddWithValue("@locationId", locationID);
                    command.Parameters.AddWithValue("@brandName", brand.Value);
                    command.Parameters.AddWithValue("@fuelType", fueltype.Value);
                    command.Parameters.AddWithValue("@fuelPrice", fuelprice.Value);
                    command.Parameters.AddWithValue("@createdBy", "admin");
                    command.Parameters.AddWithValue("@createdDate", now.ToString());
                    
                    try
                    {
                        connection.Open();
                        rowsaffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            if (rowsaffected > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                clearForm();
            }
            else
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "showErrorDialog();", true);
            }

        }

        protected void saveLocation(object sender, EventArgs e)
        {
            
            string sConnectionString = "Data Source=essql1.walton.uark.edu;Initial Catalog=MISGroup25;" + "Integrated Security = True";
            int rowsaffected = 0;
            DateTime now = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "INSERT INTO location (zipCode,streetAddress,latitude,longtitude,city,state,createdBy,createdDate) VALUES (@zipCode, @streetAddress, @latitude, @longtitude, @city, @state,@createdBy,@createdDate)";
                    command.Parameters.AddWithValue("@zipCode", zipcode.Value);
                    command.Parameters.AddWithValue("@streetAddress", streetaddr.Value);
                    command.Parameters.AddWithValue("@latitude", latitude.Value);
                    command.Parameters.AddWithValue("@longtitude", longtitude.Value);
                    command.Parameters.AddWithValue("@city", city.Value);
                    command.Parameters.AddWithValue("@state", state.Value);
                    command.Parameters.AddWithValue("@createdBy", "admin");
                    command.Parameters.AddWithValue("@createdDate", now.ToString());
                    try
                    {
                        connection.Open();
                        rowsaffected = command.ExecuteNonQuery();
                        
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    } 
                }
            } 
            
            if (rowsaffected >0)
            {
                getLocationID();
            }
            else
            {
                
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "showErrorDialog();", true);
            }
            
        }
    }
}