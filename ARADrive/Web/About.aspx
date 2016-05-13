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
         <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript">
        var markers = [
         {
             "title": 'Madrid centro',
             "lat": '40.41715556',
             "lng": '-3.68891716',
            "description": 'Parque del retiro n2.'
        },
        {
            "title": 'Alicante renfe',
            "lat": '38.34502207',
            "lng": '-0.49395561',
            "description": 'Av de la estación, n1.'
        },
         {
             "title": 'Barcelona',
             "lat": '41.39458206',
             "lng": '2.16876984',
             "description": 'Av. Sagrada Familia, n214'
         },
         {
             "title": 'Valencia ciudad',
             "lat": '39.47105272',
             "lng": '-0.37851334',
             "description": 'Calle del río, n5'
         },
         {
             "title": 'Murcia',
             "lat": '37.98432489',
             "lng": '-1.12421036',
             "description": 'Avenida de la estación n4'
         },
          {
              "title": 'Málaga centro',
              "lat": '36.72736225',
              "lng": '-4.41431522',
              "description": 'Av General Odonell s/n'
          },
           {
               "title": 'Sevilla',
               "lat": '37.39048169',
               "lng": '-5.97793579',
               "description": 'C/ Masatusa n3'
           },
           {
               "title": 'Granada renfe',
               "lat": '37.18274928',
               "lng": '-3.60368729',
               "description": 'C/ Estacion s/n'
           },
           {
               "title": 'Albacete renfe',
               "lat": '38.99837495',
               "lng": '-1.849823',
               "description": 'Av. del ferrocarril, n5'
           },
           {
               "title": 'Cuenca',
               "lat": '40.06743126',
               "lng": '-2.13600397',
               "description": 'Av. Colgante, n4'
           },
           {
               "title": 'Segovia',
               "lat": '40.93501089',
               "lng": '-4.11416531',
               "description": 'Av. Acueducto n3'
           },
           {
               "title": 'Teruel centro',
               "lat": '40.33159509',
               "lng": '-1.08906269',
               "description": 'Calle de los olvidados s/n'
           },
           {
               "title": 'Zaragoza',
               "lat": '41.65187983',
               "lng": '-0.8795929',
               "description": 'Calle de España, n7'
           },
           {
               "title": 'Valladolid',
               "lat": '41.64225925',
               "lng": '-4.72798347',
               "description": 'Av. Ilustración, n10'
           },
           {
               "title": 'Burgos centro',
               "lat": '42.34084613',
               "lng": '-3.70247841',
               "description": 'C/ Gastronomía, n12'
           },
           {
               "title": 'Mérida',
               "lat": '38.92085525',
               "lng": '-6.34408951',
               "description": 'C/ Melinda, n1'
           },
           {
               "title": 'Tarragona',
               "lat": '41.11550805',
               "lng": '1.25244141',
               "description": 'C/ Portaventura n3'
           },
           {
               "title": 'Mallorca Aeropuerto',
               "lat": '39.55488306',
               "lng": '2.72014618',
               "description": 'C/ Azafato Santos, n5'
           },
           {
               "title": 'Ibiza Aeropuerto',
               "lat": '38.88328296',
               "lng": '1.37578011',
               "description": 'Aeropuerto de Ibiza'
           },
           {
               "title": 'Gran Canaria',
               "lat": '28.12089288',
               "lng": '-15.43622017',
               "description": 'Centro, n2'
           },
           {
               "title": 'Tenerife',
               "lat": '28.46791791',
               "lng": '-16.24691248',
               "description": 'Av. del Teide, s/n'
           },
           {
               "title": 'Santiago de Compostela',
               "lat": '42.87039728',
               "lng": '-8.54598999',
               "description": 'C/ Gallega, n53'
           },
           {
               "title": 'Oviedo estación',
               "lat": '43.36755921',
               "lng": '-5.85468292',
               "description": 'C/ Ferrovial, n13'
           },
           {
               "title": 'Bilbao',
               "lat": '43.29944722',
               "lng": '-2.9271698   ',
               "description": 'Av. Ezgaberri, n32'
           },
           {
               "title": 'San Sebastián',
               "lat": '43.32324203',
               "lng": '-1.98389053',
               "description": 'C/ Agarreni'
           },
           {
               "title": 'Pamplona',
               "lat": '42.8241449',
               "lng": '-1.66125298',
               "description": 'C/ Bocallena, n4'
           },
           {
               "title": 'Ceuta',
               "lat": '35.89099706',
               "lng": '-5.30656815',
               "description": 'Av. Estrecho, n11'
           },
           {
               "title": 'Antartida',
               "lat": '-70.379115',
               "lng": '29.165757',
               "description": 'Penguin splash'
           },
        {
            "title": 'Pamplona',
            "lat": '42.8241449',
            "lng": '-1.66125298',
            "description": 'C/ Bocallena, n4.'
        },
        
        ];
        window.onload = function () {
            LoadMap();
        }
        function LoadMap() {
            var mapOptions = {
                center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
                zoom: 5,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("map"), mapOptions);
 
            //Create and open InfoWindow.
            var infoWindow = new google.maps.InfoWindow();
 
            for (var i = 0; i < markers.length; i++) {
                var data = markers[i];
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title
                });
 
                //Attach click event to the marker.
                (function (marker, data) {
                    google.maps.event.addListener(marker, "click", function (e) {
                        //Wrap the content inside an HTML DIV in order to set height and width of InfoWindow.
                        infoWindow.setContent("<div style = 'width:200px;min-height:40px'>" + data.description + "</div>");
                        infoWindow.open(map, marker);
                    });
                })(marker, data);
            }
        }
    </script>
</asp:Content>

