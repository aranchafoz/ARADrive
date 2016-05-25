<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Web.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <asp:Panel ID="Panel1" runat="server" Height="75px"> </asp:Panel>
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="page-header" style="margin-left:20%;margin-right:20%">
                <h1>Rent your car</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-3"></div>
            <div class="col-xs-6">
                <!-- Car Card -->
                <div class="panel panel-default">
                    <div class="row">
                        <div class="col-xs-6">
                            <!-- Foto -->
                            <asp:Image ID="CarImage" CssClass="img-responsive" style="crop:inherit" ImageUrl="~/assets/img/carPics/polo.png" runat="server" />  
                            <!--<img id="CarImage" class="img-responsive" style="crop:inherit" src="assets/img/carPics/polo.png" />-->                                                              
                        </div>
                        <div class="col-xs-6">
                            <div class="page-header">
                                <asp:Label ID="Label_CarName" runat="server" Text='Volkswagen Polo' Font-Size="Large"></asp:Label>
                            </div>
                            <!-- Price -->
                            <div class="row">
                                <div class="col-xs-3">
                                    <label for="">Price:&nbsp;</label>
                                </div>
                                <div class="col-xs-9">
                                    <asp:Label ID="Label_CarPrice" runat="server" Text="$ 16"></asp:Label>
                                </div>
                            </div>
                            <!-- Category -->
                            <div class="row">
                                <div class="col-xs-3">
                                    <label for="">Category:&nbsp;</label>
                                </div>
                                <div class="col-xs-9">
                                    <asp:Label ID="Label_CarCategory" runat="server" Text="Small"></asp:Label>
                                </div>
                            </div>
                            <!-- Description -->
                            <div class="row">
                                <div class="col-xs-3">
                                    <label for="">Description:&nbsp;</label>
                                </div>
                                <div class="col-xs-9">
                                    <asp:Label ID="Label_CarDescription" runat="server" Text="Good for you. Just what you need."></asp:Label>
                                </div>
                            </div>
                            <br />
                            <br />
                            <!-- automatic Transmission -->
                            <div class="row">
                                <div class="col-xs-3">
                                    <label for="">Automatic transmission:&nbsp;</label>
                                </div>
                                <div class="col-xs-9">
                                    <br />
                                    <asp:Label ID="Label_CarTransmission" runat="server" Text="False"></asp:Label>
                                </div>
                            </div>
                            <!-- Doors -->
                            <div class="row">
                                <div class="col-xs-3">
                                    <label for="">Doors:&nbsp;</label>
                                </div>
                                <div class="col-xs-9">
                                    <asp:Label ID="Label_CarDoors" runat="server" Text="4"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END Car Card -->
                <br />
                <!-- Dates Card -->
                <div class="panel panel-default" style="padding:30px">
                    <div class="row">
                        <div class="col-xs-10">
                            <!-- Fechas -->     
                            <div class="row">
                                <div class="col-xs-2">
                                    <label for="" style="margin-top:3px">Pick up date&nbsp;</label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox ID="Text_PickUp" class="form-control" runat="server" TextMode="Date"   
                                        BorderStyle="None" BackColor="Transparent" Wrap="true"
                                        type="date"></asp:TextBox>
                                </div>
                                <div class="col-xs-2">
                                    <label for="" style="margin-top:3px">Drop off date&nbsp;</label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox ID="Text_DropOff" class="form-control" runat="server" TextMode="Date"
                                        BorderStyle="None" BackColor="Transparent" Wrap="true"
                                        type="date"></asp:TextBox>
                                </div>
                            </div>                                                       
                        </div>
                        <div class="col-xs-2">
                            <!-- Rent -->
                            <!--<div class="row">
                                <div class="col-xs-3">
                                    <label for="">Total Price:&nbsp;</label>
                                </div>
                                <div class="col-xs-5">
                                    <asp:Label ID="Label_TotalPrice" runat="server" Text="$ 156" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                                </div>-->
                                <!--<div class="col-xs-4">-->
                                    <asp:Button ID="Button_Rent" class="btn btn-primary" runat="server" Text="Next" Width="90%" Font-Bold="true"/>
                                <!--</div>-->
                            <!--</div>-->                           
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-xs-3"></div>
        </div>
    </div>
</asp:Content>
