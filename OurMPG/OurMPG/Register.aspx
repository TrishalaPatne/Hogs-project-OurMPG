<%@ Page Title="" Language="C#" MasterPageFile="~/OurMPG.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OurMPG.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form runat="server">
        <div class="panel panel-default col-lg-4">
        <div class="panel-heading h4 text-primary text-center">New User - Create Account</div>
        <div class="form-group col-sm-8">
            <label for="txtUsername">Choose User Name</label>
            <asp:textbox type="text" class="form-control" id="txtNewUserName" placeholder="User Name" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-8">
            <label for="txtPwd">Choose Password</label>
            <asp:textbox type="password" class="form-control" id="txtNewPwd" placeholder="Password" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-8">
            <label for="txtPwd">Confirm Password</label>
            <asp:textbox type="password" class="form-control" id="txtNewValidatePwd" placeholder="Password" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-8">
            <label for="txtName">Name</label>
            <asp:textbox type="text" class="form-control" id="txtName" placeholder="e.g. John Smith" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-8">
            <label for="txtEmail">Email</label>
            <asp:textbox type="email" class="form-control" id="txtEmail" placeholder="e.g. johnsmith@gmail.com" runat="server"></asp:textbox>
        </div>
        <div class="form-group col-sm-8">
            <label for="txtDob">Date</label>
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
        <div class="dropdown col-sm-6">
            <label for="txtHouseholdSize">Household Size</label>
            <asp:textbox type="text" class="form-control" id="txtHouseholdSize" placeholder="e.g. 1" runat="server"></asp:textbox>
        </div>
        </div>
        <div class="form-group col-sm-8">
            <asp:button cssclass="btn btn-primary" id="btnCreateAccount" onclick="btnCreateAccount_Click" runat="server" text="Create Account"></asp:button>
        </div>
        <div class="form-group col-sm-8">
            <asp:label cssclass="label label-danger" id="lblMsg2" runat="server"></asp:label>
    </div>
    </div>
    </form>
</asp:Content>
