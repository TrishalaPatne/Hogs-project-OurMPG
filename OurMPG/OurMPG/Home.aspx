<%@ Page Title="" Language="C#" MasterPageFile="~/OurMPG.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OurMPG.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" id="ourmpg-carousel">
      <h2 class="text-center">Welcome to OurMPG Portal</h2>
      
      <div class="row">
        
        <div class="col-xs-18 col-sm-6 col-md-4 col-md-offset-1">
          <div class="thumbnail">
            <img src="images/FuelPurchase.jpg" alt="" />
              <div class="caption">
                <h4>Record Fuel Purchase</h4>
                <p>Keep track of your fuel purchases and estimate your car's efficiency</p>
                <p><a href="#" class="btn btn-info btn-xs" role="button">Record Now</a></p>
            </div>
          </div>
        </div>

        <div class="col-xs-18 col-sm-6 col-md-4 col-md-offset-1">
          <div class="thumbnail">
            <img src="images/reports.jpeg" alt="" />
              <div class="caption">
                <h4>View Reports</h4>
                <p>Compare your vehicle's ratings and performance with other vehicles.</p>
                <p><a href="#" class="btn btn-info btn-xs" role="button">Check Reports</a></p>
            </div>
          </div>
        </div>
        
      </div><!-- End row -->
      
    </div><!-- End container -->

    <footer>
        <div class="container">
        <div class="form-group col-xs-8"></div>
        <div class="form-group col-xs-8"></div>
        <p class="text-muted col-sm-12"> Designed and built by MIS Project Group 5 - For any inquiries please contact nkulshre@uark.edu, rs018@uark.edu, sa030@uark.edu, sk049@uark.edu, tpatne@uark.edu</p>
        </div>
    </footer>

</asp:Content>
