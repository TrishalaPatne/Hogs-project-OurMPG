

<%@ Page Title="" Language="C#" MasterPageFile="~/OurMPG.Master" AutoEventWireup="true" CodeBehind="UserReports.aspx.cs" Inherits="OurMPG.UserReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="userReportsForm" runat="server">
    <div class="container">
        <h2>Reports</h2>
        <ul class="nav nav-tabs" id="reportstab">
            
            <li><a data-toggle="tab" href="#menu1">Fuel Purchase History</a></li>
            <li><a data-toggle="tab" href="#menu2">Average MPG</a></li>
            <li><a data-toggle="tab" href="#menu3">Fuel Purchase Summary</a></li>
            <li><a data-toggle="tab" href="#menu4">Compare</a></li>
        </ul>

        <div class="tab-content">
            <div id="menu1" class="tab-pane fade">
                </br>
        <p>Please click Generate to see your fuel history</p>
                <div class="btn-toolbar">
                    <button type="button" id="btnSubmit" class="btn btn-primary btn-sm" onserverclick="btnGenerate_click" runat="server">Generate</button>
                </div>

                </br>

                <asp:GridView ID="GridView1"   runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns >
                        
                        <asp:BoundField DataField="make" HeaderText="Make" />
                        <asp:BoundField DataField="model" HeaderText="Model" />
                        <asp:BoundField DataField="year" HeaderText="Year" />
                        <asp:BoundField DataField="brandName" HeaderText="Gas Station" />
                        <asp:BoundField DataField="fuelType" HeaderText="Fuel Type" />
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

            <div id="menu2" class="tab-pane fade">
                <p>Please Enter Automobile data to see average MPG of other user's vehicle</p>
                <div class="form-group">
                    <label class="col-md-4 control-label">Make</label>
                    <select id="selectMake" runat="server" onchange="javascript:userReportsForm.submit()" onserverchange="selectMake_Changed" >
                        <option value="type1">Select</option>
                    </select>



                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label">Model</label>
                    <select id="selectModel" runat="server" onchange="javascript:userReportsForm.submit()" onserverchange="selectModel_Changed">
                        <option value="type1">Select</option>
                    </select>

                </div>
                <div class="form-group" >
                    <label class="col-md-4 control-label">Year</label>
                    <select id="selectYear" runat="server" onchange="javascript:userReportsForm.submit()" >
                        <option value="type1">Select</option>
                    </select>
                    <%--  --%>
                     

                </div>
                <div class="btn-toolbar">
                    <button type="button" id="Button1" class="btn btn-primary btn-sm" onserverclick="btnSubmit_click" runat="server">Submit</button>
                </div>
                </br >
                </br>
                <label type = "label" id = "label1" class="col-md-4 control-label" runat="server"> </label>
            </div>
            <div id="menu3" class="tab-pane fade">
                <p>Select anyone of following to view Fuel Purchase Summary</p>
                <div class="radio"  >
                    <div class="col-md-4">
                        <label>
                            <input type="radio" id="rdbtn1" runat="server" name="optradio"  />Automobile </label>
                    </div>
                    </br>
                    </br>
                    <div class="form-group">
                    <label class="col-md-4 control-label">Make</label>
                    <select id="stMake" runat="server" onchange="javascript:userReportsForm.submit()" onserverchange="stMake_Changed" >
                        <option value="type1">Select</option>
                    </select>



                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label">Model</label>
                    <select id="stModel" runat="server" onchange="javascript:userReportsForm.submit()" onserverchange="stModel_Changed">
                        <option value="type1">Select</option>
                    </select>

                </div>
                <div class="form-group" >
                    <label class="col-md-4 control-label">Year</label>
                    <select id="stYear" runat="server" onchange="javascript:userReportsForm.submit()" >
                        <option value="type1">Select</option>
                    </select>
                </div>
                </div>
                </br>
          
        <div class="radio">
            <div class="col-md-4">
                <label> <input type="radio" id="rdbtn2" name="optradio"  runat="server" />Month</label>
            </div>

            </br>

            </br>
            <%--</br>--%>
            <div class="form-group">
                <label class="col-md-4 control-label">From Date</label>
                <input type="date" id="date1" runat="server" onchange="javascript:userReportsForm.submit()"/>
            </div>
        <div class="form-group">
                <label class="col-md-4 control-label">To Date</label>
                <input type="date" id="date2" runat="server" onchange="javascript:userReportsForm.submit()" />
            </div>
            <%--  --%>
                </br>
          </br>
          <div class="col-md-4">
              <div class="btn-toolbar">
                  <button type="button" id="Button2" class="btn btn-primary btn-sm" onserverclick="btnrep_click" runat="server">Submit</button>
              </div>
          </div>
                            <label type = "label" id = "label4" class="col-md-4 control-label" runat="server"> </label>
            </br>
             <label type = "label" id = "label5" class="col-md-4 control-label" runat="server"> </label>
          
                </div>
                
                <asp:GridView ID="GridView2"   runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns >
                        
                        <asp:BoundField DataField="make" HeaderText="Make" />
                        <asp:BoundField DataField="model" HeaderText="Model" />
                        <asp:BoundField DataField="year" HeaderText="Year" />
                        <asp:BoundField DataField="brandName" HeaderText="Gas Station" />
                        <asp:BoundField DataField="fuelType" HeaderText="Fuel Type" />
                        <asp:BoundField DataField="streetAddress" HeaderText="Adress" />
                        <asp:BoundField DataField="city" HeaderText="city" />
                        <asp:BoundField DataField="totalGallons" HeaderText="Gallons" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                        <asp:BoundField DataField="odometerReading" HeaderText="Odometer Reading" />
                        <asp:BoundField DataField="transactionDate" HeaderText="Date" />
                        <asp:BoundField DataField="transactionTime" HeaderText="Time" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                </div>
            <div id="menu4" class="tab-pane fade">

                <p>Please Enter Automobile data for comparision with your vehicle</p>
                <div class="form-group">
                    <label class="col-md-4 control-label">Make</label>
                    <select id="sMake" runat="server" onchange="javascript:userReportsForm.submit()" onserverchange="sMake_Changed">
                        <option value="type1">Select</option>
                    </select>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label">Model</label>
                    <select id="sModel" runat="server" onchange="javascript:userReportsForm.submit()" onserverchange="sModel_Changed">
                        <option value="type1">Select</option>
                    </select>

                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label">Year</label>
                    <select id="sYear" runat="server" onchange="javascript:userReportsForm.submit()" onserverchange="sYear_Changed">
                        <option value="type1">Select</option>
                    </select>
                </div>
                 <div class="form-group">
                    <label class="col-md-4 control-label">EPA Rating</label>
                    <select id="selectEPA" runat="server">
                        <option value="type1">Select</option>
                    </select>

                </div>
              
                <div class="btn-toolbar">
                    <button type="button" id="Button3" class="btn btn-primary btn-sm" onserverclick="btnSubmitm4_click" runat="server">Submit</button>
                </div>

                <label type = "label" id = "label2" class="col-md-4 control-label" runat="server"> </label>
                </br>
                </br>
                <label type = "label" id = "label3" class="col-md-4 control-label" runat="server"> </label>
                </br>
                </br>
                <asp:GridView ID="GridView3"   runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns >
                        
                        <asp:BoundField DataField="TotalKM" HeaderText="TotalKM" />
                        <asp:BoundField DataField="MPG" HeaderText="MPG" />
                        
                        
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>

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


