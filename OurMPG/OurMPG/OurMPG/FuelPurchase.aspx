<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FuelPurchase.aspx.cs" Inherits="OurMPG.FuelPurchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      
    <div>
    
        <asp:Label ID="Label13" runat="server" Text="Login as " Width="165px"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="28px" Width="111px">
        <asp:ListItem Text="Select User" Value="-1"></asp:ListItem>
        <asp:ListItem Text="Admin User" Value="-1"></asp:ListItem>
        <asp:ListItem Text="Non-Admin User" Value="-1"></asp:ListItem>
        </asp:DropDownList>
     
        <br />
     
        <br />
     
        <asp:Panel ID="Panel1" runat="server" BackColor="Silver">
            <asp:Label ID="Label1" runat="server" Text="VehicleID" Width="165px"></asp:Label>
            <asp:TextBox ID="txtVehicleId" runat="server" OnTextChanged="txtVehicleId_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Odometer Reading" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="txtVehicleId_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Gas Station Name" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Purchase Location" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Date of Purchase" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Time of Purchase" Width="165px"></asp:Label>
            <asp:TextBox ID="Textbox6" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Fuel Type" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Total Gallons" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Total Cost" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Highway Driving %" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label11" runat="server" Text="City Driving %" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label12" runat="server" Text="MPG" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Data" Width="268px" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="#FF3300"></asp:Label>
            <br />

        </asp:Panel>
    </div>
          </form>
        </body>
</html>
