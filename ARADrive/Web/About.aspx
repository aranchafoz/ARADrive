<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Web.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
      #map {
        width: 100%;
        height: 400px;
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="75px"> </asp:Panel>
    <div class="container-fluid" style="padding:20px">
        <div class="row">
            <div class="row-fluid">
                <div class="page-header" style="margin-left:20%;margin-right:20%">
                    <h1>About Us</h1>
                </div>
            </div>    
            <div class="col-xs-2"><br /><br /></div>  
            <div class="col-xs-4 well" style="padding:10px">
                    <div class="row" style="text-align:left;padding:0 15px;margin:0 15px">                    
                            <h3>Who are we?</h3>                 
                    </div>
                    <div class="row" style="text-align:left;padding:0 15px;margin:0 15px">
                        <br />
                        <p>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AraDrive is one of the world's best-known car rental brands.
                         Owned by 6 students of the University of Alicante, started 
                         up as an assignment but after the years it became true.
                         <br />
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AraDrive, was founded in 2016 as a car rental company
                         for the butget minded  renter. Despite the little experience
                         today AraDrive has already rented over 10.000 cars becoming 
                         one of the industry leaders in Spain .
                        </p>                
                    </div>
            </div> 
            <!-- Google Map -->
            <div class="col-xs-4" style="padding:0 10px;margin:0 10px">
                <div id="map"></div>
            </div> 
            <div class="col-xs-2"><br /><br /></div> 
        </div>
        <!-- Offices -->
        <div class="row" style="padding:10px 0">
            <div class="row-fluid">
                <div class="page-header" style="margin-left:20%;margin-right:20%">
                    <h2>Offices</h2>
                </div>
                <div class="col-xs-2"></div>
                <div class="col-xs-8" style="margin-left:35%">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceOffices" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                            <asp:BoundField DataField="address" HeaderText="Address" SortExpression="Address"></asp:BoundField>
                            <asp:BoundField DataField="city" HeaderText="City" SortExpression="City"></asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                        <RowStyle BackColor="#EFF3FB"></RowStyle>

                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                        <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                        <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                        <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                        <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSourceOffices" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT [name], [address], [city] FROM [T_Office]"></asp:SqlDataSource>
            
                </div>
                <div class="col-xs-2"></div>
            </div>  
        </div>
    </div>
    <!-- Scripts -->
        <script>
          function initMap() {
            var mapDiv = document.getElementById('map');
            var map = new google.maps.Map(mapDiv, {
              center: { lat: 38.344444, lng: -0.494972 },
              zoom: 15
            });
          }
        </script>
        <script src="https://maps.googleapis.com/maps/api/js?callback=initMap"
            async defer></script> 
    <asp:Panel ID="Panel2" runat="server" Height="230px"> </asp:Panel>
</asp:Content>
