<%@ Page Title="" Language="C#" MasterPageFile="~/OurMPG.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OurMPG.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div class="panel panel-default col-lg-offset-1 col-lg-5 pull-left">
    <div class="panel-heading h4 text-primary text-center">Registered User - Please Login</div>
    <div class="form-group col-xs-8">
        <label for="txtUsername">User Name</label>
        <asp:textbox type="text" class="form-control" id="txtUserName" placeholder="User Name" runat="server"></asp:textbox>
    </div>
    <div class="form-group col-xs-8">
        <label for="txtPwd">Password</label>
        <asp:textbox type="password" class="form-control" id="txtPwd" placeholder="Password" runat="server"></asp:textbox>
    </div>
    <div class="form-group col-xs-8">
    <asp:button cssclass="btn btn-primary" id="btnLogin" onclick="btnLogin_Click" runat="server" text="Login"></asp:button>
    </div>
    <div class="form-group col-xs-8">
     <asp:label cssclass="label label-danger" id="lblMsg1" runat="server"></asp:label>
    </div>
    <div class="form-group col-xs-12 h5 text-default">Forgot Username or Password!
        <a href="Register.aspx">You'll need to create a new account.</a>
    </div>
    </div>
    <div class="panel panel-default col-lg-5 pull-right">
    <div class="panel-heading h4 text-primary text-left">New to OurMPG?</div>
    <div class="h5 text-default">Create an OurMPG Account today to...</div>
        <ul><li>Record your Fuel Purchases.</li>
            <li>Compare your MPG with standard EPA ratings.</li>
            <li>Check your car's performance over a period.</li>
            <li>Find Gas Stations in your area.</li>
            <li>Record all the vehicles you own.</li>
            <li>And many more exciting features.</li>
        </ul>
    <div class="form-group col-xs-8">
    <asp:button cssclass="btn btn-primary" id="Button1" onclick="btnSignUp_Click" runat="server" text="Sign Up"></asp:button>
    </div>
    <div class="form-group col-xs-8"></div>
    <div class="form-group col-xs-8"></div>
    <div class="form-group col-xs-8"></div>
    </div>
    </form>
</asp:Content>
