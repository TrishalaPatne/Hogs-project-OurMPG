/*Author: Niharika Kavuri
Object Name: FuelPurchaseDAL in OurMPG Namespace
Purpose: A class that facilitates database access to SQL Server 2016.
Constructor: Takes in <Optional Params>
Date Created:10/8/2016.
*/

#region UsingStatements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
#endregion

namespace OurMPG
{
    public class FuelPurchaseDAL
    {
        //Function that passes the credentials to retrieve and load Vehicle values 
        public DataSet RetrieveVehicleNames(string sUserId)
        {
            //Declare a DataSet object for VehicleValues
            DataSet dsVehicleValues = new DataSet();
            try
            {
                string sQuery = "dbo.getVehicleNames";
                using (SqlConnection oConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand oCommand = new SqlCommand(sQuery, oConn))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oConn.Open();
                        oCommand.Parameters.AddWithValue("@UserId", sUserId);
                        using (SqlDataAdapter oDatapter = new SqlDataAdapter(oCommand))
                        {
                            oDatapter.Fill(dsVehicleValues);
                        }
                    }
                }
                return dsVehicleValues;
              }
        catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("Error.aspx");
                throw;
            }
        }

        //Function that loads State values 
        public DataSet RetrieveStateNames()
        {
            //Declare a DataSet object for Statevalues
            DataSet dsStateValues = new DataSet();
          try
          { 
            string sQuery = "Select  DISTINCT state as StateValue from  location";
            using (SqlConnection oConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using (SqlCommand oCommand = new SqlCommand(sQuery, oConn))
                {
                    oConn.Open();
                    using (SqlDataAdapter oDatapter = new SqlDataAdapter(oCommand))
                    {
                        oDatapter.Fill(dsStateValues);
                    }

                }
             }
            return dsStateValues;
           }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("Error.aspx");
                throw;
            }
        }

        //Function that retreives ,loads City values based on the state the user selected  
        public DataSet RetrieveCityNames(string sState)
        {
            //Declare a DataSet object for CityValues
            DataSet dsCityValues = new DataSet();
            try
            {
                string sQuery = "dbo.getcity";
                using (SqlConnection oConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand oCommand = new SqlCommand(sQuery, oConn))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oConn.Open();
                        oCommand.Parameters.AddWithValue("@State", sState);
                        using (SqlDataAdapter oDatapter = new SqlDataAdapter(oCommand))
                        {
                            oDatapter.Fill(dsCityValues);
                        }

                    }
                }
                return dsCityValues;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("Error.aspx");
                throw;
            }
        }

        //Function that retreives ,loads ZipCode values based on the state and city the user selected 
        public DataSet RetrieveZipCode(string sState, string sCity)
        {
            //Declare a DataSet object for LocationStreetAddress
            DataSet dsZipCode = new DataSet();
            try
            {
                string sQuery = "getZipCode";
                using (SqlConnection oConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand oCommand = new SqlCommand(sQuery, oConn))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;

                        oConn.Open();
                        oCommand.Parameters.AddWithValue("@State", sState);
                        oCommand.Parameters.AddWithValue("@City", sCity);
                        using (SqlDataAdapter oDatapter = new SqlDataAdapter(oCommand))
                        {
                            oDatapter.Fill(dsZipCode);
                        }
                    }
                }
                return dsZipCode;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("Error.aspx");
                throw;
            }
        }

        //Function that retreives ,loads Location Address values based on the ZipCode the user selected 
        public DataSet RetrieveLocationAddress(string sZipcode)
        {
            //Declare a DataSet object for LocationStreetAddress
            DataSet dsLocationAddress = new DataSet();
            try
            {
                string sQuery = "dbo.getLocationAddress";
                using (SqlConnection oConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand oCommand = new SqlCommand(sQuery, oConn))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oConn.Open();
                        oCommand.Parameters.AddWithValue("@ZipCode", sZipcode);

                        using (SqlDataAdapter oDatapter = new SqlDataAdapter(oCommand))
                        {
                            oDatapter.Fill(dsLocationAddress);
                        }
                    }
                }
                return dsLocationAddress;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("Error.aspx");
                throw;
            }
         }

        //Function that retreives , loads Gastation names based on the zipcode and street address , the user selected
        public DataSet RetrieveGasStationName(string sZipCode, string sStreetAddress)
        {
            //Read the user id and password for database access from web.config file
            //Declare a DataSet object for Statevalues
            DataSet dsGasStationNames = new DataSet();
            try
            {
                string sQuery = "dbo.getGasStationName";
                using (SqlConnection oConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand oCommand = new SqlCommand(sQuery, oConn))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oConn.Open();
                        oCommand.Parameters.AddWithValue("@ZipCode", sZipCode);
                        oCommand.Parameters.AddWithValue("@StreetAddress", sStreetAddress);
                        using (SqlDataAdapter oDatapter = new SqlDataAdapter(oCommand))
                        {
                            oDatapter.Fill(dsGasStationNames);
                        }
                    }
                }
                return dsGasStationNames;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("Error.aspx");
                throw;
            }
         }

        //Function that retreives , loads Fuel Types based on the Gastationname , Zipcode and Street Address the user selected 
        public DataSet RetrieveFuelTypes(string sGasStationName, string sZipCode, string sStreetAddress)
        {
            //Declare a DataSet object for Statevalues
            DataSet dsFuelTypes = new DataSet();
            try
            {
                string sQuery = "dbo.getFuelTypes";
                using (SqlConnection oConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand oCommand = new SqlCommand(sQuery, oConn))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oConn.Open();
                        oCommand.Parameters.AddWithValue("@gasStationName", sGasStationName);
                        oCommand.Parameters.AddWithValue("@ZipCode", sZipCode);
                        oCommand.Parameters.AddWithValue("@StreetAddress", sStreetAddress);
                        using (SqlDataAdapter oDatapter = new SqlDataAdapter(oCommand))
                        {
                            oDatapter.Fill(dsFuelTypes);
                        }
                    }
                }
                return dsFuelTypes;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("Error.aspx");
                throw;
            }
        }

        //Function that inserts the values, the user inputs in the front end 
        public int InsertFuelPurchase(string VehicleName, string sUserId, string gasStationName, string transactionDate, string OdometerReading,
        string Zipcode, string StreetAddress, int totalGallons, string transactiontime, int cityDrivePer, int hwyDrivePer, string notes, string createdBy, string createdDate,
        string lastupdatedBy, string lastUpdatedDate, string fuelType)
        {
            try
            {
                string sQuery = "dbo.insFuelPurchase";
                using (SqlConnection oConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand oCommand = new SqlCommand(sQuery, oConn))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oConn.Open();
                        oCommand.Parameters.AddWithValue("@VehicleYear", VehicleName.Split(' ')[0].ToString());
                        oCommand.Parameters.AddWithValue("@VehicleModel", VehicleName.Split(' ')[2].ToString());
                        oCommand.Parameters.AddWithValue("@VehicleMake", VehicleName.Split(' ')[1].ToString());
                        oCommand.Parameters.AddWithValue("@VehicleTrans", VehicleName.Split(' ')[4].ToString());
                        oCommand.Parameters.AddWithValue("@VehicleDispl", Convert.ToDecimal(VehicleName.Split(' ')[6].ToString().Substring(0, 3)));
                        oCommand.Parameters.AddWithValue("@Cyl", Convert.ToDecimal(VehicleName.Split(' ')[5].ToString().Substring(0, 3)));
                        oCommand.Parameters.AddWithValue("@driveStyle", VehicleName.Split(' ')[7].ToString());
                        oCommand.Parameters.AddWithValue("@vehicleClass", VehicleName.Split(' ')[8].ToString() + " " + VehicleName.Split(' ')[9].ToString());
                        oCommand.Parameters.AddWithValue("@uservehiclecolor", VehicleName.Split(' ')[3].ToString());
                        oCommand.Parameters.AddWithValue("@ZipCode", Zipcode);
                        oCommand.Parameters.AddWithValue("@fuelType", fuelType);
                        oCommand.Parameters.AddWithValue("@StreetAddress", StreetAddress);
                        oCommand.Parameters.AddWithValue("@gasStationName", gasStationName);
                        oCommand.Parameters.AddWithValue("@transactionDate", transactionDate);
                        oCommand.Parameters.AddWithValue("@OdometerReading", OdometerReading);
                        oCommand.Parameters.AddWithValue("@totalGallons", totalGallons);
                        oCommand.Parameters.AddWithValue("@transactiontime", transactiontime);
                        oCommand.Parameters.AddWithValue("@cityDrivePer", cityDrivePer);
                        oCommand.Parameters.AddWithValue("@hwyDrivePer", hwyDrivePer);
                        oCommand.Parameters.AddWithValue("@notes", notes);
                        oCommand.Parameters.AddWithValue("@createdBy", sUserId);
                        oCommand.Parameters.AddWithValue("@createdDate", System.DateTime.Now.Date.ToString("d"));
                        oCommand.Parameters.AddWithValue("@lastupdatedBy", sUserId);
                        oCommand.Parameters.AddWithValue("@lastUpdatedDate", System.DateTime.Now.Date.ToString("d"));
                        oCommand.Parameters.AddWithValue("@suserId", sUserId);
                        SqlParameter outputval = oCommand.Parameters.Add("@ctr", SqlDbType.Int);
                        outputval.Direction = ParameterDirection.Output;

                        oCommand.ExecuteNonQuery();
                        int outputvalue = (int)oCommand.Parameters["@ctr"].Value;
                        return outputvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("Error.aspx");
                throw;
            }
        }




    }
}
    
   

   
