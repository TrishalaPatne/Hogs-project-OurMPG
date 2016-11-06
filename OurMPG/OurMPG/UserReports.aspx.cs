using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;


namespace OurMPG
{
    public partial class UserReports : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Session["userName"].ToString();
            if (!Page.IsPostBack)
            {
                //average mpg tab select make
                selectMake.DataTextField = "make";
                selectMake.DataValueField = "make";
                selectMake.DataSource = getData("Vehiclemake", null);
                selectMake.DataBind();
                selectMake.Items.Insert(0, new ListItem("Select Make", "-1"));
                //compare select make
                sMake.DataTextField = "make";
                sMake.DataValueField = "make";
                sMake.DataSource = getData("Vehiclemake", null);
                sMake.DataBind();
                sMake.Items.Insert(0, new ListItem("Select Make", "-1"));
                //fuel purchase summury select make
                stMake.DataTextField = "make";
                stMake.DataValueField = "make";
                stMake.DataSource =  getVehicleMake(user);
                stMake.DataBind();
                stMake.Items.Insert(0, new ListItem("Select Make", "-1"));
            }

        }
        protected void selectMake_Changed(object sender, EventArgs e)
        {
            label1.Visible = false;
            selectModel.DataTextField = "model";
            selectModel.DataValueField = "model";
            selectModel.DataSource = getVehicleModel(selectMake.Value.ToString());
            selectModel.DataBind();
            selectModel.Items.Insert(0, new ListItem("Select Model", "-1"));

        }
        //fuel history menu
        protected void btnGenerate_click(object sender, EventArgs e)
        {
            string user = Session["userName"].ToString();
            GridView1.DataSource = fuelPurchasedata(user);
            GridView1.DataBind();
        }
        // average MPG menu
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

            

            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("averageMPG", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@make", selectMake.Value.ToString());
                cmd.Parameters.AddWithValue("@model", selectModel.Value.ToString());
                cmd.Parameters.AddWithValue("@year", selectYear.Value.ToString());
                SqlParameter output = new SqlParameter();
                output.ParameterName = "@MPG";
                output.SqlDbType = System.Data.SqlDbType.Int;
                output.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(output);
                con.Open();

                cmd.ExecuteNonQuery();
                String s = output.Value.ToString();
                label1.Visible = true;
                if (string.IsNullOrEmpty(s))
                {
                    label1.InnerText = "No Records Found";
                }
                else
                {
                    
                    label1.InnerText = "Average MPG =" + output.Value.ToString();
                }
            }
        }
        //compare menu
        protected void sMake_Changed(object sender, EventArgs e)
        {
            
            sModel.DataTextField = "model";
            sModel.DataValueField = "model";
            sModel.DataSource = getVehicleModel(sMake.Value.ToString());
            sModel.DataBind();
            sModel.Items.Insert(0, new ListItem("Select Model", "-1"));

        }
        protected void sModel_Changed(object sender, EventArgs e)
        {

            sYear.DataTextField = "year";
            sYear.DataValueField = "year";
            sYear.DataSource = getVehicleYear(sModel.Value.ToString());
            sYear.DataBind();
            sYear.Items.Insert(0, new ListItem("Select Year", "-1"));

        }
        protected void sYear_Changed(object sender, EventArgs e)
        {

            selectEPA.DataTextField = "epaCmbMPG";
            selectEPA.DataValueField = "epaCmbMPG";
            selectEPA.DataSource = getEPA(sMake.Value.ToString(), sModel.Value.ToString(), sYear.Value.ToString());
            selectEPA.DataBind();
            selectEPA.Items.Insert(0, new ListItem("Select EPA", "-1"));

        }
        protected void btnSubmitm4_click(object sender, EventArgs e)
        {
            GridView3.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            string user = Session["userName"].ToString();
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("useraverageMPG", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@make", sMake.Value.ToString());
                cmd.Parameters.AddWithValue("@model", sModel.Value.ToString());
                cmd.Parameters.AddWithValue("@year", sYear.Value.ToString());
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@epa", selectEPA.Value.ToString());
                SqlParameter output = new SqlParameter();
                output.ParameterName = "@MPG";
                output.SqlDbType = System.Data.SqlDbType.Int;
                output.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(output);
                con.Open();

                cmd.ExecuteNonQuery();

                if (string.IsNullOrEmpty(output.Value.ToString()))
                {
                    label2.Visible = true;
                    label2.InnerText = "No Records Found for your vehicle";

                }
                else
                {
                    label2.Visible = true;
                    label2.InnerText = "Your Average MPG =" + output.Value.ToString();
                }
                DataTable cmp= compare(sMake.Value.ToString(), sModel.Value.ToString(), sYear.Value.ToString(),selectEPA.Value.ToString());
                if (cmp.Rows.Count==0)
                {
                    label3.Visible = true;
                    label3.InnerText = "No records found for other vehicle";
                }
               else
                {
                    label3.Visible = true;
                    GridView3.Visible = true;
                    label3.InnerText = "Other user's MPG Records";
                    GridView3.DataSource = cmp;
                    GridView3.DataBind();
                }
               
            }
        }


        private DataTable fuelPurchasedata(string username)
        {
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("fuelPurchaseHist", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@Username", username));
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        private DataTable getVehicleMake (string user)
         {
             string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
             SqlConnection con = new SqlConnection(CS);
             SqlDataAdapter da = new SqlDataAdapter("uservehiclemake", con);
            da.SelectCommand.Parameters.Add(new SqlParameter("@user", user));
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
             DataTable dataTable = new DataTable();
             da.Fill(dataTable);
             return dataTable;
         }
        private DataTable getVehicleModel(string vmake)
        {
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("Vehicleyear", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@spmodel", mo));
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        private DataTable getEPA(string m, string md, string y)
        {
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("SpEPA", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@m", m));
            da.SelectCommand.Parameters.Add(new SqlParameter("@md", md));
            da.SelectCommand.Parameters.Add(new SqlParameter("@y", y));

            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        private DataTable getData(string SPName, SqlParameter SPParameter)
        {
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
        
        protected DataTable compare(string m, string md, string y,string e)
        {
            string user = Session["userName"].ToString();
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("compare", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@user",user));
            da.SelectCommand.Parameters.Add(new SqlParameter("@make", m));
            da.SelectCommand.Parameters.Add(new SqlParameter("@model", md));
            da.SelectCommand.Parameters.Add(new SqlParameter("@year", y));
            da.SelectCommand.Parameters.Add(new SqlParameter("@epa", e));

            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        //fuel pruchase summery menu
        protected void btnrep_click(object sender, EventArgs e)
        {
            string user = Session["userName"].ToString();
            label5.Visible = false;
            GridView2.Visible = false;
            if (rdbtn1.Checked == true)
            {
                GridView2.Visible = true;
                GridView2.DataSource = fuelPurchaseauto(user, stMake.Value.ToString(), stModel.Value.ToString(), stYear.Value.ToString());
                GridView2.DataBind();
            }
            else if (rdbtn2.Checked== true)
            {
                DataTable tb= fuelPurchasetime(user, date1.Value.ToString(), date2.Value.ToString());
                label5.Visible = false;
                GridView2.Visible = true;
                    GridView2.DataSource = tb;
                    GridView2.DataBind();
               
                    if (tb.Rows.Count!=0)
                    {
                    label5.Visible = false;
                    }
                    else
                    {
                        label5.Visible = true;
                        label5.InnerText = "No records found";
                    }
            }
            else
            {
                label4.InnerText = "Select valied choice from above";
            }
        }
        protected void stMake_Changed(object sender, EventArgs e)
        {
            label5.Visible = false;
            GridView2.Visible = false;
            stModel.DataTextField = "model";
            stModel.DataValueField = "model";
            stModel.DataSource = userVehicleModel(stMake.Value.ToString());
            stModel.DataBind();
            stModel.Items.Insert(0, new ListItem("Select Model", "-1"));

        }
        private DataTable userVehicleModel(string make)
        {
            string user = Session["userName"].ToString();
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("uservehiclemodel", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@user", user));
            da.SelectCommand.Parameters.Add(new SqlParameter("@make", make));
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        protected void stModel_Changed(object sender, EventArgs e)
        {

            stYear.DataTextField = "year";
            stYear.DataValueField = "year";
            stYear.DataSource = userVehicleYear(stMake.Value.ToString(),stModel.Value.ToString());
            stYear.DataBind();
            stYear.Items.Insert(0, new ListItem("Select Year", "-1"));

        }
        private DataTable userVehicleYear(string make,string model)
        {
            string user = Session["userName"].ToString();
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("uservehicleyear", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@user", user));
            da.SelectCommand.Parameters.Add(new SqlParameter("@make", make));
            da.SelectCommand.Parameters.Add(new SqlParameter("@model", model));
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        protected DataTable fuelPurchaseauto(string u,string m, string md, string y)
        {
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("autoFuelPurchase", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@username", u));
            da.SelectCommand.Parameters.Add(new SqlParameter("@make", m));
            da.SelectCommand.Parameters.Add(new SqlParameter("@model", md));
            da.SelectCommand.Parameters.Add(new SqlParameter("@year", y));

            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        protected DataTable fuelPurchasetime(string u, string d1, string d2)
        {
            string CS = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("timeFuelPurchase", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@username", u));
            da.SelectCommand.Parameters.Add(new SqlParameter("@date1", d1));
            da.SelectCommand.Parameters.Add(new SqlParameter("@date2", d2));
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

    }
}