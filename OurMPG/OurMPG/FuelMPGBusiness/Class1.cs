using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelMPGDAL;

namespace OurMPGBusiness
{
    public class Class1
    {
        FuelMPGDAL.Class1 objDALClass;
        public Class1()
            {
            objDALClass = new FuelMPGDAL.Class1();
            }
        public bool SaveData(string sValue)
        {
            //if (sValue.IndexOf('%') > 1)
            //{
            //    return false;
            //}
            //else
            //{
                return objDALClass.SaveData(sValue);

            //}
        }
    }
}
