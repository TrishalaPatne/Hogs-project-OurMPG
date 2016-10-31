<%@ Page Title="" Language="C#" MasterPageFile="~/OurMPG.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OurMPG.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form runat="server">
        <div class="panel panel-default col-md-offset-1 col-md-3 pull-left" id="accountPanel" runat="server">
        <div class="panel-heading h4 text-primary text-center">New User - Create Account</div>
        <div class="form-group col-sm-10">
            <label for="txtUsername">Choose User Name</label>
            <asp:textbox type="text" class="form-control" id="txtNewUserName" placeholder="User Name" runat="server"></asp:textbox>
            <asp:label cssclass="label label-danger" id="lblMsg1" runat="server"></asp:label>
        </div>
        <div class="form-group col-sm-10">
            <label for="txtPwd">Choose Password</label>
            <asp:textbox type="password" class="form-control" id="txtNewPwd" placeholder="Password" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-10">
            <label for="txtPwd">Confirm Password</label>
            <asp:textbox type="password" class="form-control" id="txtNewValidatePwd" placeholder="Password" runat="server"></asp:textbox>
            <asp:label cssclass="label label-danger" id="lblMsg2" runat="server"></asp:label>
        </div>
        <div class="form-group col-sm-10">
            <label for="txtName">Name</label>
            <asp:textbox type="text" class="form-control" id="txtName" placeholder="e.g. John Smith" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-10">
            <label for="txtEmail">Email</label>
            <asp:textbox type="email" class="form-control" id="txtEmail" placeholder="e.g. johnsmith@gmail.com" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-10">
            <label for="txtDob">Date of Birth</label>
            <asp:textbox type="date" class="form-control" id="txtDob" placeholder="e.g. 01/20/1990" runat="server"></asp:textbox>
        </div>
        <div class="row col-sm-12">
        <div class="dropdown col-sm-6">
            <label for="drpGender">Gender</label>
            <asp:DropDownList runat="server" cssclass="form-control" id="drpGender">
            <asp:ListItem Text="Male"></asp:ListItem>
            <asp:ListItem Text="Female" ></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="dropdown col-sm-6">
            <label for="drpIncomeBracket">Income Bracket</label>
            <asp:DropDownList runat="server" cssclass="form-control" id="drpIncomeBracket">
            <asp:ListItem Text="<10,000"></asp:ListItem>
            <asp:ListItem Text="10,000-20,000" ></asp:ListItem>
            <asp:ListItem Text="20,000-50,000" ></asp:ListItem>
            <asp:ListItem Text="50,000-100,000" ></asp:ListItem>
            <asp:ListItem Text=">100,000" ></asp:ListItem>
            </asp:DropDownList>
        </div>
        </div>
        <div class="form-group col-xs-8"></div>
        <div class="row col-sm-12">
        <div class="dropdown col-sm-6">
            <label for="drpHomeOwner">Home Owner</label>
            <asp:DropDownList runat="server" cssclass="form-control" id="drpHomeOwner">
            <asp:ListItem Text="Yes"></asp:ListItem>
            <asp:ListItem Text="No" ></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group col-sm-6">
            <label for="txtHouseholdSize">Household Size</label>
            <asp:textbox type="text" class="form-control" id="txtHouseholdSize" placeholder="e.g. 1" runat="server"></asp:textbox>
        </div>
        </div>
        <div class="form-group col-xs-8"></div>
        <div class="form-group col-xs-8"></div>
        <div class="form-group col-sm-10">
            <asp:button cssclass="btn btn-primary" id="btnCreateAccount" data-target="#confirmDialog" onclick="btnCreateAccount_Click" runat="server" text="Create Account"></asp:button>
        </div>
        </div>
        <div id="confirmDialog" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
        <div class="modal-content">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
            <h4 class="modal-title text-success">Confirmation</h4>
        </div>
        <div class="modal-body text-success">
            <p>Profile has been created successfully. Please add your address details to continue.</p>
        </div>
        <div class="modal-footer">
            <asp:button type="button" class="btn btn-primary" id="btnContinueAddress" onclick="btnContinueAddress_Click" usesubmitbehavior="false" data-dismiss="modal" runat="server" text="Continue"></asp:button>
        </div>
        </div>
        </div>
        </div>
        <div id="errorDialog" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
        <div class="modal-content">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
            <h4 class="modal-title text-danger">Error Occured</h4>
        </div>
        <div class="modal-body text-danger">
            <p>Error Occured. Please try after sometime. </p>
        </div>
        <div class="modal-footer">
            <asp:button type="button" class="btn btn-danger" data-dismiss="modal" UseSubmitBehavior="false" runat="server" text="Ok"></asp:button>
        </div>
        </div>
        </div>
        </div>
        <div class="panel panel-default col-md-offset-1 col-md-3 pull-center" id="addressPanel" runat="server">
        <div class="panel-heading h4 text-primary text-center">Enter Address details</div>
        <div class="row col-sm-12">
            <label class="col-sm-10">Home</label>
        </div>
        <div class="row col-sm-12">
        <div class="form-group col-sm-12">
            <label for="txtHomeStreetAddress">Street Address</label>
            <asp:textbox type="text" class="form-control" id="txtHomeStreetAddress" runat="server"></asp:textbox>
        </div>
        </div>
        <div class="row col-sm-12">
        <div class="form-group col-sm-6">
            <label for="txtHomeCity">City</label>
            <asp:textbox type="text" class="form-control" id="txtHomeCity" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-6">
            <label for="txtHomeState">State</label>
            <asp:textbox type="text" class="form-control" id="txtHomeState" runat="server"></asp:textbox>
        </div>
        </div>
        <div class="row col-sm-12">
        <div class="form-group col-sm-6">
            <label for="txtHomeZip">Zip Code</label>
            <asp:textbox type="text" class="form-control" id="txtHomeZip" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-3">
            <label for="txtHomeLat">Latitude</label>
            <asp:textbox type="text" class="form-control" id="txtHomeLat" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-3">
            <label for="txtHomeLong">Longtitude</label>
            <asp:textbox type="text" class="form-control" id="txtHomeLong" runat="server"></asp:textbox>
        </div>
        </div>
        <div class="row col-sm-12">
            <label class="col-sm-12">Work</label>
        </div>
        <div class="row col-sm-12">
        <div class="form-group col-sm-12">
            <label for="txtWorkStreetAddress">Street Address</label>
            <asp:textbox type="text" class="form-control" id="txtWorkStreetAddress" runat="server"></asp:textbox>
        </div>
        </div>
        <div class="row col-sm-12">
        <div class="form-group col-sm-6">
            <label for="txtWorkCity">City</label>
            <asp:textbox type="text" class="form-control" id="txtWorkCity" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-6">
            <label for="txtWorkState">State</label>
            <asp:textbox type="text" class="form-control" id="txtWorkState" runat="server"></asp:textbox>
        </div>
        </div>
        <div class="row col-sm-12">
        <div class="form-group col-sm-6">
            <label for="txtWorkZip">Zip Code</label>
            <asp:textbox type="text" class="form-control" id="txtWorkZip" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-3">
            <label for="txtWorkLat">Latitude</label>
            <asp:textbox type="text" class="form-control" id="txtWorkLat" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-3">
            <label for="txtWorkLong">Longtitude</label>
            <asp:textbox type="text" class="form-control" id="txtWorkLong" runat="server"></asp:textbox>
        </div>
        </div>
        <div class="form-group col-xs-8"></div>
        <div class="form-group col-xs-8"></div>
        <div class="form-group col-sm-10">
            <asp:button cssclass="btn btn-primary" id="btnAddAddress" onclick="btnAddAddress_Click" runat="server" text="Add Address"></asp:button>
        </div>
        </div>
        <div id="nextDialog" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
        <div class="modal-content">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
            <h4 class="modal-title text-success">Confirmation</h4>
        </div>
        <div class="modal-body text-success">
            <p>Address has been added successfully. Please add your car details to finish registration.</p>
        </div>
        <div class="modal-footer">
            <asp:button type="button" class="btn btn-primary" id="btnContinueGarage" onclick="btnContinueGarage_Click" usesubmitbehavior="false" data-dismiss="modal" runat="server" text="Continue"></asp:button>
        </div>
        </div>
        </div>
        </div>
        <div class="panel panel-default col-md-offset-1 col-md-3 pull-center" id="myGaragePanel" runat="server">
        <div class="panel-heading h4 text-primary text-center">My Garage</div>
        <div class="form-group dropdown col-sm-10">
            <label for="drpMake">Make</label>
            <asp:DropDownList cssclass="form-control" id="drpMake" AppendDataBoundItems="true" autopostback="true" onselectedindexchanged="drpMakeSelected_selectedIndexChanged" runat="server">
                <asp:ListItem Text="--Select--"></asp:ListItem>
            </asp:DropDownList>
            <label for="drpModel">Model</label>
            <asp:DropDownList cssclass="form-control" id="drpModel" AppendDataBoundItems="true" autopostback="true" onselectedindexchanged="drpModelSelected_selectedIndexChanged" runat="server">
                <asp:ListItem Text="--Select--"></asp:ListItem>
            </asp:DropDownList>
            <label for="drpYear">Year</label>
            <asp:DropDownList cssclass="form-control" id="drpYear" AppendDataBoundItems="true" autopostback="true" onselectedindexchanged="drpYearSelected_selectedIndexChanged" runat="server">
                <asp:ListItem Text="--Select--"></asp:ListItem>
            </asp:DropDownList>
            <label for="drpSpecs">Specification</label>
            <asp:DropDownList cssclass="form-control" id="drpSpecs" AppendDataBoundItems="true" autopostback="true" onselectedindexchanged="drpSpecsSelected_selectedIndexChanged" runat="server">
                <asp:ListItem Text="--Select--"></asp:ListItem>
            </asp:DropDownList>
            <label for="drpOwner">Ownership Status</label>
            <asp:DropDownList runat="server" cssclass="form-control" id="drpOwner" AutoPostBack="true" onselectedindexchanged="drpOwnerSelected_selectedIndexChanged">
            <asp:ListItem Text="--Select--"></asp:ListItem>
            <asp:ListItem Text="Own"></asp:ListItem>
            <asp:ListItem Text="Lease" ></asp:ListItem>
            <asp:ListItem Text="Rent" ></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group col-sm-10">
            <label for="txtColor">Color</label>
            <asp:textbox type="text" class="form-control" id="txtColor" runat="server"></asp:textbox>
            <label for="txtCarName">Car Name</label>
            <asp:textbox type="text" class="form-control" id="txtCarName" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-10">
            <asp:button cssclass="btn btn-primary" id="btnAddCar" onclick="btnAddCar_Click" runat="server" text="Add Car"></asp:button>
        </div>
        </div>
        <div id="nextCarDialog" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
        <div class="modal-content">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
            <h4 class="modal-title text-success">Confirmation</h4>
        </div>
        <div class="modal-body text-success">
            <p>Your vehicle has been added successfully. Do you own another vehicle?</p>
        </div>
        <div class="modal-footer">
            <asp:button type="button" class="btn btn-primary" id="btnNextCarYes" onclick="btnNextCarYes_Click" usesubmitbehavior="false" data-dismiss="modal" runat="server" text="Yes"></asp:button>
            <asp:button type="button" class="btn btn-primary" id="btnNextCarNo" onclick="btnNextCarNo_Click" usesubmitbehavior="false" data-dismiss="modal" runat="server" text="No"></asp:button>
        </div>
        </div>
        </div>
        </div>
        <script type="text/javascript">
            function showConfirmDialog() {
                $('#confirmDialog').modal('show');
                return true;
            };
            function showErrorDialog() {
                $('#errorDialog').modal('show');
            };
            function showNextDialog() {
                $('#nextDialog').modal('show');
                return true;
            };
            function showNextCarDialog() {
                $('#nextCarDialog').modal('show');
                return true;
            };
        </script>
    </form>
</asp:Content>
