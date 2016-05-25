<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Rent.aspx.cs" Inherits="Web.Rent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server" Height="75px"> </asp:Panel>
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="page-header" style="margin-left:20%;margin-right:20%">
                <h1>Rent your car</h1>
            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

            

                <div class="row">
                    <div class="col-xs-3"></div>
                    <div class="col-xs-6">
                        <!-- Total Price Card -->
                        <div class="panel panel-default" style="padding:30px">
                            <div class="row">                        
                                <div class="col-xs-6">
                                    <!-- Rent -->
                                    <div class="row">
                                        <div class="col-xs-5">

                                        </div>
                                        <div class="col-xs-3">
                                            <label for="" style="margin-top:10%">Total Price:&nbsp;</label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:Label ID="Label_TotalPrice" runat="server" Text="$ 156" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>                          
                                </div>
                                <div class="col-xs-6">
                                    <asp:Button ID="Button_Rent" CssClass="btn btn-success" style="margin-left:20%" runat="server" Text="RENT" Font-Size="Medium" Width="40%"
                                         OnClick="Button_Rent_Click"/>
                                </div>
                            </div>
                        </div>
                        <!-- END Total Price Card -->
                        <!-- Features Card -->
                        <div class="panel panel-default">
                            <div class="row">
                                <!-- Columna 1 -->
                                <div class="col-xs-6">
                                    <div class="row" style="margin:5% 10%">
                                        <div class="col-xs-6">
                                            <label>Description</label>
                                        </div>
                                        <div class="col-xs-3">
                                            <label>Price</label>
                                        </div>
                                        <div class="col-xs-3"></div>
                                    </div>
                                    <div class="row" style="margin:5% 10%">
                                        <div class="col-xs-6">
                                            Chauffeur
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Label ID="Label_DriverPrice" runat="server" Text="20"></asp:Label>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Button ID="Button_Driver" CssClass="btn" runat="server" Text="Select" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin:5% 10%">
                                        <div class="col-xs-6">
                                            GPS
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Label ID="Label_GPSPrice" runat="server" Text="30"></asp:Label>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Button ID="Button_GPS" CssClass="btn" runat="server" Text="Select" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin:5% 10%">
                                        <div class="col-xs-6">
                                            Roof rack
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Label ID="Label_BacaPrice" runat="server" Text="9"></asp:Label>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Button ID="Button_Baca" CssClass="btn" runat="server" Text="Select" />
                                        </div>
                                    </div>     
                                </div>
                                <!-- Columna 2 -->
                                <div class="col-xs-6">
                                    <div class="row" style="margin:5% 10%">
                                        <div class="col-xs-6">
                                            <label>Description</label>
                                        </div>
                                        <div class="col-xs-3">
                                            <label>Price</label>
                                        </div>
                                        <div class="col-xs-3"></div>
                                    </div>
                                    <div class="row" style="margin:5% 10%">
                                        <div class="col-xs-6">
                                            Baby seat
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Label ID="Label_BabyChairPrice" runat="server" Text="5"></asp:Label>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Button ID="Button_BabyChair" CssClass="btn" runat="server" Text="Select" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin:5% 10%">
                                        <div class="col-xs-6">
                                            Child seat
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Label ID="Label_ChildChairPrice" runat="server" Text="7"></asp:Label>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Button ID="Button_ChildChair" CssClass="btn" runat="server" Text="Select" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin:5% 10%">
                                        <div class="col-xs-6">
                                            Insurance
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Label ID="Label_InsurancePrice" runat="server" Text="15"></asp:Label>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Button ID="Button_Insurance" CssClass="btn" runat="server" Text="Select" />
                                        </div>
                                    </div>   
                                </div>
                            </div>
                        </div>
                        <!-- END Features Card -->
                        <br />
                    </div>
                    <div class="col-xs-3"></div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
