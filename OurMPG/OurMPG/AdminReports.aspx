

<%@ Page Title="" Language="C#" MasterPageFile="~/OurMPG.Master" AutoEventWireup="true" CodeBehind="AdminReports.aspx.cs" Inherits="OurMPG.AdminReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="AdminReportForm" runat="server">
    <div class="container">
        <h2>Reports</h2>
        <ul class="nav nav-tabs" id="reportstab">
            
            <li ><a data-toggle="tab" href="#menu1">Fuel Purchases</a></li>
            <li><a data-toggle="tab" href="#menu2">Compare MPG</a></li>
            
        </ul>

        <div class="tab-content">
            <div id="menu1" class="tab-pane fade">
                <p>Please Enter data to view fuel purchases</p>
                <div class="form-group">
                    <label class="col-md-4 control-label">SelectFuel</label>
                    <select id="selectFuel" runat="server" onchange="javascript:AdminReportForm.submit()"  >
                        <option value="type1">Select</option>
                    </select>



                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label">Location</label>
                    <select id="selectLocation" runat="server" onchange="javascript:AdminReportForm.submit()" >
                        <option value="type1">Select</option>
                    </select>

                </div>
                <div class="form-group" >
                    <label class="col-md-4 control-label">Period</label>
                    </br>
                    </br>
                  <div class="form-group">
                <label class="col-md-4 control-label">From Date</label>
                <input type="date" id="date3" runat="server" onchange="javascript:AdminReportForm.submit()"/>
            </div>
        <div class="form-group">
                <label class="col-md-4 control-label">To Date</label>
                <input type="date" id="date4" runat="server" onchange="javascript:AdminReportForm.submit()" />
            </div>
                <div class="btn-toolbar">
                    <button type="button" id="Button4" class="btn btn-primary btn-sm" onserverclick="btnGenerate_click" runat="server">Submit</button>
                </div>
                </br >
                </br>
                <label type = "label" id = "label6" class="col-md-4 control-label" runat="server"> </label>
                </br>
      
                </br>

                <asp:GridView ID="GridView1"   runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns >
                        <asp:BoundField DataField="userName" HeaderText="User /Name" />
                        <asp:BoundField DataField="make" HeaderText="Make" />
                        <asp:BoundField DataField="model" HeaderText="Model" />
                        <asp:BoundField DataField="year" HeaderText="Year" />
                        <asp:BoundField DataField="brandName" HeaderText="Gas Station" />
                        <asp:BoundField DataField="streetAddress" HeaderText="Adress" />
                        <asp:BoundField DataField="city" HeaderText="city" />
                        <asp:BoundField DataField="totalGallons" HeaderText="Gallons" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount ($)" />
                        <asp:BoundField DataField="odometerReading" HeaderText="Odometer Reading" />
                        <asp:BoundField DataField="transactionDate" HeaderText="Date" />
                        <asp:BoundField DataField="transactionTime" HeaderText="Time" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Right" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>

            </div>
            </div>

            <div id="menu2" class="tab-pane fade">
                <p>Please Enter Automobile data</p>
                <div class="form-group">
                    <label class="col-md-4 control-label">Make</label>
                    <select id="selectMake" runat="server" onchange="javascript:AdminReportForm.submit()" onserverchange="selectMake_Changed" >
                        <option value="type1">Select</option>
                    </select>



                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label">Model</label>
                    <select id="selectModel" runat="server" onchange="javascript:AdminReportForm.submit()" onserverchange="selectModel_Changed">
                        <option value="type1">Select</option>
                    </select>

                </div>
                <div class="form-group" >
                    <label class="col-md-4 control-label">Year</label>
                    <select id="selectYear" runat="server" onchange="javascript:AdminReportForm.submit()" >
                        <option value="type1">Select</option>
                    </select>
                    <%--  --%>
                     

                </div>
                <div class="btn-toolbar">
                    <button type="button" id="Button1" class="btn btn-primary btn-sm" onserverclick="btnSubmit_click" runat="server">Submit</button>
                </div>
                </br >
                </br>
                
                <asp:GridView ID="GridView2"   runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns >
                        <asp:BoundField DataField="userName" HeaderText="User Name" />
                        <asp:BoundField DataField="MPG" HeaderText="MPG" />
                        <asp:BoundField DataField="EPA" HeaderText="EPA" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Right" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>

                </br>
                <label type = "label" id = "label1" class="col-md-4 control-label" runat="server"> </label>
            </div>
          </div>  
        </div>
  
    <script type="text/javascript">
            $(function () {
                // for bootstrap 3 use 'shown.bs.tab', for bootstrap 2 use 'shown' in the next line
                $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
                    // save the latest tab; use cookies if you like 'em better:
                    localStorage.setItem('lastTab', $(this).attr('href'));
                });

                // go to the latest tab, if it exists:
                var lastTab = localStorage.getItem('lastTab');
                if (lastTab) {
                    $('[href="' + lastTab + '"]').tab('show');
                }
            });
        </script>
    </form>
</asp:Content>


