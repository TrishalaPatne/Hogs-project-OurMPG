<%@ Page Title="" Language="C#" MasterPageFile="~/OurMPG.Master" AutoEventWireup="true" CodeBehind="Vehicle.aspx.cs" Inherits="OurMPG.Vehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <h3 class="text-left">Add Vehicle Record</h3>
       
           <div class="form-group">
                <label class="col-md-4 control-label">Make:</label>
                <input type="text" runat="server" id="make"/>
               <label class="control-label text-danger">
                   <asp:RequiredFieldValidator ControlToValidate="make" ID="rfvmake" runat="server" ErrorMessage="Please enter the make of the vehicle"></asp:RequiredFieldValidator>
               </label>
            </div>
            <div class="form-group">
                <label class="col-md-4 control-label">Model:</label>
                <input type="text" runat="server" id="model"/>
                <label class="control-label text-danger">
                   <asp:RequiredFieldValidator ControlToValidate="model" ID="rfvmodel" runat="server" ErrorMessage="Please enter the model of the vehicle"></asp:RequiredFieldValidator>
               </label>
            </div>
         <div class="form-group">
                <label class="col-md-4 control-label">Year:</label>
             <input type="text" runat="server" id="year"/>
             <label class="control-label text-danger">
                   <asp:RequiredFieldValidator ControlToValidate="year" ID="rfvyear" runat="server" ErrorMessage="Please enter the manufactured year of the vehicle"></asp:RequiredFieldValidator>
               </label>
            </div>
         <div class="form-group">
                <label class="col-md-4 control-label">Transmission:</label>
             <input type="text" runat="server" id="transmission" />
             <label class="control-label text-danger">
                 <asp:RequiredFieldValidator ControlToValidate="transmission" ID="rfvtrans" runat="server" ErrorMessage="Please enter the transmission of the vehicle"></asp:RequiredFieldValidator>
             </label>
            </div>
         <div class="form-group">
                <label class="col-md-4 control-label">Displacement:</label>
             <input type="text" runat="server" id="displ"/>
             <label class="control-label text-danger">
                 <asp:RequiredFieldValidator ControlToValidate="displ" ID="rfvdis" runat="server" ErrorMessage="Please enter the displacement"></asp:RequiredFieldValidator>
             </label>
            </div>
         <div class="form-group">
                <label class="col-md-4 control-label">Cylinder:</label>
             <input type="text" runat="server" id="cyl"/>
              <label class="control-label text-danger">
                 <asp:RequiredFieldValidator ControlToValidate="cyl" ID="rfvcyl" runat="server" ErrorMessage="Please enter the cylinder specification"></asp:RequiredFieldValidator>
             </label>
            </div>
        
          <div class="form-group">
                <label class="col-md-4 control-label">Driving Style:</label>
             <input type="text" runat="server" id="drivingstyle"/>
               <label class="control-label text-danger">
                 <asp:RequiredFieldValidator ControlToValidate="drivingstyle" ID="rfvdstyle" runat="server" ErrorMessage="Please enter the driving style of the vehicle"></asp:RequiredFieldValidator>
             </label>
            </div>
         <div class="form-group">
                <label class="col-md-4 control-label">Vehicle Class:</label>
             <input type="text" runat="server" id="vclass"/>
              <label class="control-label text-danger">
                 <asp:RequiredFieldValidator ControlToValidate="vclass" ID="rfvclass" runat="server" ErrorMessage="Please enter the vehicle class"></asp:RequiredFieldValidator>
             </label>
            </div>
         <div class="form-group">
             <label class="col-md-4 control-label">EPA City MPG</label>
             <input type="text" runat="server" id="citympg" />
              <label class="control-label text-danger">
                 <asp:RequiredFieldValidator ControlToValidate="citympg" ID="rfvcmpg" runat="server" ErrorMessage="Please enter the city MPG"></asp:RequiredFieldValidator>
             </label>
         </div>
         <div class="form-group">
             <label class="col-md-4 control-label">EPA Highway MPG</label>
             <input type="text" runat="server" id="highwaympg" />
              <label class="control-label text-danger">
                 <asp:RequiredFieldValidator ControlToValidate="highwaympg" ID="rfvhmpg" runat="server" ErrorMessage="Please enter the high MPG"></asp:RequiredFieldValidator>
             </label>
         </div>
         <div class="form-group">
             <label class="col-md-4 control-label">Combined MPG</label>
             <input type="text" runat="server" id="combmpg" />
              <label class="control-label text-danger">
                 <asp:RequiredFieldValidator ControlToValidate="combmpg" ID="rfvcombmpg" runat="server" ErrorMessage="Please enter the combined MPG"></asp:RequiredFieldValidator>
             </label>
         </div>
        <div class="form-group">
            <div class="col-md-4 col-md-offset-4">
        <div class="btn-toolbar">
                    <button type="button" id="btnSubmit" runat="server"  data-target="#confirmDialog" onserverclick="saveVehicle" class="btn btn-primary btn-sm">Submit</button>
                    <button type="button" id="btnCancel" class="btn btn-default btn-sm">Cancel</button>
             </div>
                </div>
            </div>
       
    </div>
    <div id="confirmDialog" class="modal fade" tabindex="-1">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h4 class="modal-title text-success">Confirmation</h4>
        </div>
        <div class="modal-body text-success">
        <p>Record has been saved successfully.</p>
        </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button>
        </div>
    </div>
    </div>
</div>
     <div id="errorDialog" class="modal fade" tabindex="-1">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h4 class="modal-title text-danger">Error Occured</h4>
        </div>
        <div class="modal-body text-danger">
        <p>Error Occured. Please try after sometime. </p>
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

</asp:Content>
