<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileNestedMasterPage.master" AutoEventWireup="true" CodeBehind="Formulario web1.aspx.cs" Inherits="Web.History" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderProfile" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="row">
            <asp:Label ID="Label_Title" runat="server" Text="Explore your lasts rents" Font-Size="XX-Large"></asp:Label>
            <br /><br />
        </div>

        <asp:DataList ID="DataListBookings" runat="server" DataKeyField="code" DataSourceID="SqlDataSourceBookings">

            <ItemTemplate>
                <asp:Label Text='<%# Eval("usr") %>' runat="server" ID="Label_User" Visible="false"/><br />
                <asp:Panel ID="PanelItem" runat="server" Visible="false" Wrap="true" style="margin:0;padding:0">  
                    <!-- History Booking -->
                    <div class="panel" style="margin:0;padding:0">
                        <div class="panel-body">
                            <div class="row">
                                    <div class="col-xs-6">
                                        <!-- Dates -->     
                                        <div class="row">
                                            <div class="col-xs-2">
                                                <asp:Label ID="Label_BookingCode" runat="server" Text='<%# Eval("code") %>' Font-Bold="true" Wrap="true"></asp:Label>
                                            </div>
                                            <div class="col-xs-5">
                                                <asp:Label ID="Label_PickUp" type="date" runat="server" Text='<%# Eval("startDate") %>' Wrap="true"></asp:Label>
                                            </div>
                                            <div class="col-xs-5">
                                                <asp:Label ID="Label_DropOff" type="date" runat="server" Text='<%# Eval("finishDate") %>' Wrap="true"></asp:Label>
                                            </div>
                                        </div>                                                       
                                    </div>
                                    <div class="col-xs-6">
                                        <!-- Rent -->
                                        <div class="row">
                                            <div class="col-xs-3">
                                                <label for="">Cost:&nbsp;</label>
                                            </div>
                                            <div class="col-xs-3">
                                                <asp:Label ID="Label_TotalPrice" runat="server" Text='<%# Eval("totPrice") %>' Font-Size="Medium" Font-Bold="true"></asp:Label>
                                            </div>
                                            <div class="col-xs-6">
                                                <asp:Button ID="Button_SeeMore" class="btn btn-info" runat="server" Text="See more" Width="100%"/>
                                            </div>
                                        </div>                            
                                    </div>
                                </div>
                            <asp:Panel ID="Panel_Details" runat="server" Height="0" style="margin:0;padding:0;">
                                <br />
                                <div class="row" style="margin:0;padding-left:7%;padding-top:2%;padding-bottom:2%;background-color:azure;border-radius:5px">  
                                    <div class="col-xs-4">
                                        <asp:Image ID="Image_Driver" runat="server" ImageUrl="assets/img/Delete-15.png"/> 
                                        Chauffeur
                                        <br />
                                        <asp:Image ID="Image_satNav" runat="server" ImageUrl="assets/img/Delete-15.png"/>
                                        GPS
                                        <br />
                                    </div>
                                    <div class="col-xs-4">
                                        
                                        <asp:Image ID="Image_Baca" runat="server" ImageUrl="assets/img/Delete-15.png"/>
                                        Roof rack
                                        <br />
                                        <asp:Image ID="Image_Insurance" runat="server" ImageUrl="assets/img/Delete-15.png"/>
                                        Insurance
                                        <br />
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Image ID="Image_BabyChair" runat="server" ImageUrl="assets/img/Delete-15.png"/>
                                        Baby seat
                                        <br />
                                        <asp:Image ID="Image_ChildChair" runat="server" ImageUrl="assets/img/Delete-15.png"/>
                                        Child seat
                                        <br />
                                        
                                    </div>
                                </div>
                            </asp:Panel>             
                        </div>
                    </div>
                    <!-- End History Booking -->    
                </asp:Panel>                          
                <br />    
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender_Details" runat="server" Enabled="true"
                    TargetControlID="Panel_Details" ExpandControlID="Button_SeeMore" CollapseControlID="Button_SeeMore"
                    Collapsed="true" 
                    SuppressPostBack="false" />            
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource runat="server" ID="SqlDataSourceBookings" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT [usr], [code], [startDate], [finishDate], [totPrice], [driver], [satNav], [babyChair], [childChair], [baca], [insurance] FROM [T_Booking]"></asp:SqlDataSource>
    </div>    
</asp:Content>