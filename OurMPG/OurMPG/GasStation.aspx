<%@ Page Title="" Language="C#" MasterPageFile="~/OurMPG.Master" AutoEventWireup="true" CodeBehind="GasStation.aspx.cs" Inherits="OurMPG.Location" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

    <div class="container">
        <h3 class="text-left">Add Gas Station record </h3>
       
             <div class="form-group">
                <label class="col-md-4 control-label">Gas Station Brand:</label>
                <input type="text" runat="server" id="brand"/> 
                 <label class="control-label text-danger">
                    <asp:RequiredFieldValidator ID="rfvbrand" 
               runat="server" ControlToValidate="brand"
               ErrorMessage="Please enter the brand name or gas station name" 
                >
            </asp:RequiredFieldValidator>
                </label>
            </div>
           
         <div class="form-group">
             <label class="col-md-4 control-label">Fuel Type:</label>   
             <input type="text" runat="server" id="fueltype" />
             <label class="control-label text-danger">
                    <asp:RequiredFieldValidator ID="rfvfueltype" 
               runat="server" ControlToValidate="fueltype"
               ErrorMessage="Please enter the fuel type" 
                >
            </asp:RequiredFieldValidator>
                </label>
         </div>
       <div class="form-group">
             <label class="col-md-4 control-label">Fuel Price:</label>   
             <input type="text" runat="server" id="fuelprice" />
             <label class="control-label text-danger">
                    <asp:RequiredFieldValidator ID="rfvfuelprice" 
               runat="server" ControlToValidate="fuelprice"
               ErrorMessage="Please enter the fuel price" 
                >
            </asp:RequiredFieldValidator>
                </label>
         </div>
           <div class="form-group">
                <label class="col-md-4 control-label">State:</label>
                <input type="text" runat="server" id="state"/>
                <label class="control-label text-danger">
                    <asp:RequiredFieldValidator ID="rfvstate" 
               runat="server" ControlToValidate="state"
               ErrorMessage="Please enter a state name. Eg; AR for Arkansas" 
                >
            </asp:RequiredFieldValidator>
                </label>
            </div>
            <div class="form-group">
                <label class="col-md-4 control-label">City:</label>
                <input type="text" runat="server" id="city"/>
                 <label class="control-label text-danger">
                    <asp:RequiredFieldValidator ID="rfvcity" 
               runat="server" ControlToValidate="city"
               ErrorMessage="Please enter a city name. Eg: Fayetteville" 
                >
            </asp:RequiredFieldValidator>
                </label>
            </div>
          <div class="form-group">
                <label class="col-md-4 control-label">Latitude:</label>
             <input type="text" runat="server" id="latitude"/>
            </div>
         <div class="form-group">
                <label class="col-md-4 control-label">Longtitude:</label>
             <input type="text" runat="server" id="longtitude"/>
            </div>
         <div class="form-group">
                <label class="col-md-4 control-label">Street Address:</label>
             <input type="text" runat="server" id="streetaddr"/>
              <label class="control-label text-danger">
                    <asp:RequiredFieldValidator ID="rfvstaddr" 
               runat="server" ControlToValidate="streetaddr"
               ErrorMessage="Please enter a street address" 
                >
            </asp:RequiredFieldValidator>
                </label>
            </div>
        <div class="form-group">
                <label class="col-md-4 control-label">Zip Code:</label>
             <input type="text" runat="server" id="zipcode"/>
             <label class="control-label text-danger">
                    <asp:RequiredFieldValidator ID="rfvzip" 
               runat="server" ControlToValidate="zipcode"
               ErrorMessage="Please enter a valid zipcode" 
                >
            </asp:RequiredFieldValidator>
                </label>
            </div>
           
        <div class="form-group">
            <div class="col-md-4 col-md-offset-4">
        <div class="btn-toolbar">
                    <button type="button" id="btnSubmit" onserverclick="saveLocation"  data-target="#confirmDialog" class="btn btn-primary btn-sm" runat="server">Submit</button>
                    <button type="button" id="btnCancel" class="btn btn-default btn-sm">Cancel</button>
             </div>
                </div>
            </div>
       
    </div>
         <!-- success message dialog -->
    <div id="confirmDialog" class="modal fade" tabindex="-1">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h4 class="modal-title">Confirmation</h4>
        </div>
        <div class="modal-body">
        <p>Record has been saved successfully.</p>
        </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button>
        </div>
    </div>
    </div>
        </div>
        <!-- error message dialog -->
     <div id="errorDialog" class="modal fade" tabindex="-1">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h4 class="modal-title text-danger">Error Occured</h4>
        </div>
        <div class="modal-body text-danger">
        <p>Error Occured. Please try after sometime </p>
        </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Ok</button>
        </div>
    </div>
    </div>
        </div>
        <script type="text/javascript">
    function Confirm () {
        $('#confirmDialog').modal('show'); 
        return true;
    };
    function showErrorDialog() {
        $('#errorDialog').modal('show');
    }
    </script>
        </form>

</asp:Content>
