<%@ Page Title="" Language="C#" MasterPageFile="~/OurMPG.Master" AutoEventWireup="true" CodeBehind="FuelPurchase.aspx.cs" Inherits="OurMPG.FuelPurchase" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
     <div class="container">
        <h3 class="text-left">Record your Fuel Purchase</h3>
       
            <div class="form-group">
                <label class="col-md-4 control-label">Vehicle</label>
                <select id="selectVehicle" runat="server" name="D1" required="required" style="width:500px"> </select>            
            </div>        
            <div class="form-group">
                <label class="col-md-4 control-label">Date of Purchase</label>
                <input type="date" id="dateofpurchase" runat="server" name="D99"/>
            <label class="control-label text-danger">
            <asp:RequiredFieldValidator ID="rfvdateofpurchase" 
               runat="server" ControlToValidate="dateofpurchase"
               ErrorMessage="Please select the date of purchase" 
                >
            </asp:RequiredFieldValidator>
                </label>
            </div>          
            <div class="form-group">
                <label class="col-md-4 control-label">Time of Purchase</label>
                <input type="time" id="timeofpurchase" runat="server" name="D100" />
                  <label class="control-label text-danger">
                   <asp:RequiredFieldValidator ID="rfvtimeofpurchase" 
                  runat="server" ControlToValidate="timeofpurchase"
               ErrorMessage="Please select the time of purchase" 
                >
            </asp:RequiredFieldValidator>
                </label>
            </div>
            <div class="form-group">
                <label class="col-md-4 control-label">Location of Purchase</label>
                 <select id="selectState" runat="server" name="D2" onchange="javascript:form1.submit()" onserverchange="selectState_ServerChange1" required="required">
            
            </select>
                  <select id="selectCity" runat="server" name="D3" onchange="javascript:form1.submit()" onserverchange="selectCity_ServerChange" required="required">
                    
            </select>
             
                <select id="selectZipcode" runat="server" onchange="javascript:form1.submit()" onserverchange="selectZipcode_ServerChange" required="required">
                      
            </select>
                   <select id="selectStreetAddress" runat="server" onchange="javascript:form1.submit()" onserverchange="selectStreetAddress_ServerChange" required="required" style="width:200px">
                      
            </select>
                   <select id="selectGasStation" runat="server" name="D4"  onchange="javascript:form1.submit()" onserverchange="selectGasStation_ServerChange" required="required">
                      
            </select>
            </div>
            
         <div class="form-group">
                <label class="col-md-4 control-label">Odometer Reading</label>
                <input type="text" runat="server" id="odometer"/><asp:Label ID="Label3" runat="server"></asp:Label>
            &nbsp;<label class="control-label text-danger">
                 <asp:RequiredFieldValidator ID="rfvodometer" 
               runat="server" ControlToValidate="odometer"
               ErrorMessage="Please enter the odometer reading" 
                >
            </asp:RequiredFieldValidator>
                <asp:RangeValidator id="Rangeodometer"
           ControlToValidate="odometer"
           MinimumValue="1"
           MaximumValue="2147483647"
           Type="Integer"
           Text="Please enter a valid number greater than zero" runat="server" >
                        </asp:RangeValidator>
                </label>
                </div>

        <div class="form-group">
                <label class="col-md-4 control-label">Choose the Fuel Type</label>
                    <select id="selectFuelType" runat="server" name="D4" required="required">      
            </select>
            </div>
        
             <div class="form-group">
                <label class="col-md-4 control-label">Total Gallons of Fuel Purchased</label>
                <input type="text" runat="server" id="totGallonsofFulPurchased"/>  
                   <label class="control-label text-danger">   
            <asp:RequiredFieldValidator ID="rfvtotGallonsofFulPurchased" 
               runat="server" ControlToValidate="totGallonsofFulPurchased"
               ErrorMessage="Please enter the Gallons of Fuel Purchased" 
                >
            </asp:RequiredFieldValidator>    
                 <asp:RangeValidator id="RangeGallonsPurchased"
           ControlToValidate="totGallonsofFulPurchased"
           MinimumValue="0.00001"
           Type="Double"
           MaximumValue="2147483647"
           Text="Please enter a valid number greater than zero" runat="server" >
                     </asp:RangeValidator>
                </label>
            </div>
        <div class="form-group">
                <label class="col-md-4 control-label">Highway Driving %</label>
                <input id="HighWayDriving" type="text" runat="server" name="D7" required="required"/>
                <label class="control-label text-danger">
                <asp:RequiredFieldValidator ID="rfvHighWayDriving" 
                runat="server" ControlToValidate="HighWayDriving"
                ErrorMessage="Please enter the Highway Driving percentage" 
                >
            </asp:RequiredFieldValidator>
                </label>
            </div>
        <div class="form-group">
                <label class="col-md-4 control-label">City Driving %</label>
                 <input id="CityDriving" type="text" runat="server" name="D8"/>
                <label class="control-label text-danger">
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="rfvCityDriving" 
                runat="server" ControlToValidate="CityDriving"
                ErrorMessage="Please enter the City Driving percentage" 
                >
            </asp:RequiredFieldValidator>
                </label>
            </div>
            <div class="form-group">
                <label class="col-md-4 control-label">Notes</label>    
                <div class="col-md-4" style="padding-left:0px;"> <textarea class="form-control" id="notes" runat="server" name="textarea" placeholder="Enter any notes about the purchase"></textarea></div>                           
            </div>
        <div class="form-group" style="padding-top:70px;">
            <div class="col-md-4 col-md-offset-4">
        <div class="btn-toolbar">
                    <button type="button" id="btnSubmit" class="btn btn-primary btn-sm" onserverclick="btnSubmit_Click" runat="server">Submit</button>
            <div id="confirmDialog" class="modal fade" tabindex="-1">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h4 class="modal-title">Confirmation</h4>
        </div>
        <div class="modal-body">
        <p>Your request has been submitted successfully.</p>
        </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button>
        </div>
    </div>
    </div>
</div>
  
<script type="text/javascript">
    function Confirm () {
        $('#confirmDialog').modal('show'); 
        return true;
    };
</script>                 
             </div>
                </div>
            </div>      
    </div>         
        </form>
</asp:Content>
