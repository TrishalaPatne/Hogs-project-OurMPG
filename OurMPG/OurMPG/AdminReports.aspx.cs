using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace OurMPG
{
    public partial class AdminReports : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //select fuelType dropdown
                selectFuel.DataTextField = "fuelType";
                selectFuel.DataValueField = "fuelType";
                selectFuel.DataSource = getData("selectFuelType", null);
                selectFuel.DataBind();
                selectFuel.Items.Insert(0, new ListItem("Select Fuel", "-1"));
                //select Location dropdown
                selectLocation.DataTextField = "city";
                selectLocation.DataValueField = "city";
                selectLocation.DataSource = getData("selectLocation", null);
                selectLocation.DataBind();
                selectLocation.Items.Insert(0, new ListItem("Select Location", "-1"));
                //select make dropdown
                selectMake.DataTextField = "make";
                selectMake.DataValueField = "make";
                selectMake.DataSource =  getData("Vehiclemake",null);
                selectMake.DataBind();
                selectMake.Items.Insert(0, new ListItem("Select Make", "-1"));
            }

        }

        //fuel purchase menu
        protected void btnGenerate_click(object sender, EventArgs e)
        {
            label6.Visible = false;
            GridView1.Visible = false;


          DataTable tb  = fuelPurchasedata(selectFuel.Value.ToString(), selectLocation.Value.ToString(), date3.Value.ToString(), date4.Value.ToString());
            if (tb.Rows.Count==0)
            {
                label6.Visible = true;
                label6.InnerText = "No records Found";
            }
            else
            {
                GridView1.Visible = true;
                GridView1.DataSource = tb;
                GridView1.DataBind();
            }
            
        }
        //compare EPA menu
        protected void selectMake_Changed(object sender, EventArgs e)
        {
            label1.Visible = false;
            selectModel.DataTextField = "model";
            selectModel.DataValueField = "model";
            selectModel.DataSource = getVehicleModel(selectMake.Value.ToString());
            selectModel.DataBind();
            selectModel.Items.Insert(0, new ListItem("Select Model", "-1"));

        }
        protected void selectModel_Changed(object sender, EventArgs e)
        {
        
            selectYear.DataTextField = "year";
            selectYear.DataValueField = "year";
            selectYear.DataSource = getVehicleYear(selectModel.Value.ToString());
            selectYear.DataBind();
            selectYear.Items.Insert(0, new ListItem("Select Year", "-1"));

        }
        protected void btnSubmit_click(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            label1.Visible = false;
            DataTable db=comapareEPA(selectMake.Value.ToString(), selectModel.Value.ToString(), selectYear.Value.ToString());
            if (db.Rows.Count==0)
            {
                label1.Visible = true;
                label1.InnerText = "No records found";
            }
            else {
                GridView2.Visible = true;
                GridView2.DataSource = db;
                GridView2.DataBind();
            }
            
        }
        private DataTable fuelPurchasedata(string fuel, string loc, string d1, string d2)
        {

            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("fuelPurchaseAdmin", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@fueltype", fuel));
            da.SelectCommand.Parameters.Add(new SqlParameter("@location", loc));
            da.SelectCommand.Parameters.Add(new SqlParameter("@date1", d1));
            da.SelectCommand.Parameters.Add(new SqlParameter("@date2", d2));
            DataTable dataTable = new DataTable();
         
            da.Fill(dataTable);
            return dataTable;
        }
        private DataTable comapareEPA(string mk, string mod, string yr)
        {

            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("compareEPA", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@make", mk));
            da.SelectCommand.Parameters.Add(new SqlParameter("@model", mod));
            da.SelectCommand.Parameters.Add(new SqlParameter("@year", yr));
           
            DataTable dataTable = new DataTable();
        
            da.Fill(dataTable);
          
            return dataTable;
        }
  
        private DataTable getVehicleModel(string vmake)
        {
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spvehiclemodel", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@spmake", vmake));
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        private DataTable getVehicleYear(string mo)
        {
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("Vehicleyear", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@spmodel", mo));
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
 
        private DataTable getData(string SPName, SqlParameter SPParameter)
        {
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter(SPName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (SPParameter != null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        
        
    }
}