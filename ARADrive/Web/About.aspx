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
                    <asp:ListView ID="ListView_Offices" runat="server" DataSourceID="SqlDataSourceOffices">
                        <ItemTemplate>
                            <address>
                              <strong><asp:Label Text='<%# Eval("name") %>' runat="server" ID="Label_OfficeName" /></strong><br/>
                              <asp:Label Text='<%# Eval("address") %>' runat="server" ID="Label_OfficeAddress" /><br/>
                              <asp:Label Text='<%# Eval("city") %>' runat="server" ID="Label_City" /><br/>
                              <!-- Office telephone
                                  <abbr title="Phone">P:</abbr> (123) 456-7890
                                -->
                            </address>
                        </ItemTemplate>
                    </asp:ListView>
                    <!-- SQL Sentence to obtain AllOffices -->
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
</asp:Content>
