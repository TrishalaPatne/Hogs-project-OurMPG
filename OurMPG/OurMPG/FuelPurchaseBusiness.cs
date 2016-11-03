/*Author: Niharika Kavuri
Object Name: FuelPurchaseBusiness in OurMPG Namespace
Purpose: A class that facilitates business rule implementation.
Constructor: Takes in <Optional Params>
Date Created:10/8/2016.
Modified By:
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace OurMPG
{
   public class FuelPurchaseBusiness
    {
        public FuelPurchaseBusiness()
        {
            oDAL = new FuelPurchaseDAL();
        }
        FuelPurchaseDAL oDAL;
        //Function that passes the credentials to retrieve the load values 
        public DataSet RetrieveVehicleNames(string sUserId)
        {
            DataSet oReturnSet = new DataSet();
            oReturnSet = oDAL.RetrieveVehicleNames(sUserId);
            return oReturnSet;
        }

        public DataSet RetrieveStateNames()
        {
            DataSet oReturnSet = new DataSet();
            oReturnSet = oDAL.RetrieveStateNames();
            return oReturnSet;
        }

        public DataSet RetrieveCityNames(string sState)
        {
            DataSet oReturnSet = new DataSet();
            oReturnSet = oDAL.RetrieveCityNames(sState);
            return oReturnSet;
        }
        public DataSet RetrieveZipCode(string sState, string sCity)
        {
            DataSet oReturnSet = new DataSet();
            oReturnSet = oDAL.RetrieveZipCode (sState, sCity);
            return oReturnSet;
        }
        public DataSet RetrieveLocationAddress(string sZipCode)
        {
            DataSet oReturnSet = new DataSet();
            oReturnSet = oDAL.RetrieveLocationAddress(sZipCode);
            return oReturnSet;
        }

        public DataSet RetrieveFuelTypes(string sGasStationName, string sZipCode, string sStreetAddress)
        {
            DataSet oReturnSet = new DataSet();
            oReturnSet = oDAL.RetrieveFuelTypes(sGasStationName, sZipCode, sStreetAddress);
            return oReturnSet;
        }
        public DataSet RetrieveGasStationName(string sZipCode, string sStreetAddress)
        {
            DataSet oReturnSet = new DataSet();
            oReturnSet = oDAL.RetrieveGasStationName(sZipCode, sStreetAddress);
            return oReturnSet;
        }

        public int InsertFuelPurchase(string VehicleName, string sUserId, string gasStationName, string transactionDate, string OdometerReading,
 string ZipCode,string StreetAddress,  int totalGallons, string transactiontime, int cityDrivePer, int hwyDrivePer, string notes, string createdBy, string createdDate,
 string lastupdatedBy, string lastUpdatedDate,string fuelType)
        {

            return oDAL.InsertFuelPurchase(VehicleName, sUserId, gasStationName, transactionDate, OdometerReading, ZipCode, StreetAddress, totalGallons, transactiontime, cityDrivePer, hwyDrivePer, notes, createdBy, createdDate, lastupdatedBy, lastUpdatedDate,fuelType);

        }
    }
}

