<%@ Page Title="" Language="C#" MasterPageFile="~/OurMPG.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OurMPG.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" id="ourmpg-carousel">
      
      <div class="row">
        
        <div class="col-xs-18 col-sm-6 col-md-4">
          <div class="thumbnail">
            <img src="images/FuelPurchase.jpg" alt="" />
              <div class="caption">
                <h4>Record Fuel Purchase</h4>
                <p>Keep track of your fuel purchases and estimate your car's efficiency</p>
                <p><a href="FuelPurchase.aspx" class="btn btn-info btn-xs" role="button">Record Now</a></p>
            </div>
          </div>
        </div>

        <div class="col-xs-18 col-sm-6 col-md-4">
          <div class="thumbnail">
            <img src="images/reports.jpeg" alt="" />
              <div class="caption">
                <h4>View Reports</h4>
                <p>Compare your vehicle's ratings and performance with other vehicles.</p>
                <p><a href="UserReports.aspx" class="btn btn-info btn-xs" role="button">Check Reports</a></p>
            </div>
          </div>
        </div>
        
      </div><!-- End row -->
      
    </div><!-- End container -->

</asp:Content>
