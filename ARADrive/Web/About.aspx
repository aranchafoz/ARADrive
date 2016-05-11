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
                        Lorem ipsum dolor sit amet, consectetuer adipiscing elit.
                         Aenean commodo ligula eget dolor. Aenean massa. Cum sociis
                         natoque penatibus et magnis dis parturient montes, nascetur
                         ridiculus mus. Donec quam felis, ultricies nec, pellentesque
                         eu, pretium quis, sem. Nulla consequat massa quis enim. Donec
                         pede justo, fringilla vel, aliquet nec, vulputate eget, arcu.
                         In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo.
                         Nullam dictum felis eu pede mollis pretium. Integer tincidunt.
                    </p>                
                </div>
        </div> 
        <!-- Google Map -->
        <div class="col-xs-4" style="padding:0 10px;margin:0 10px">
            <div id="map"></div>
        </div> 
        <div class="col-xs-2"><br /><br /></div> 
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
        </div>
    <asp:Panel ID="Panel2" runat="server" Height="100px"> </asp:Panel>
</asp:Content>
