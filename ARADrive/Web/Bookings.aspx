﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileNestedMasterPage.master" AutoEventWireup="true" CodeBehind="Bookings.aspx.cs" Inherits="Web.Bookings" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderProfile" runat="server">
    <div class="container-fluid">
        <div class="row">
            <asp:Label ID="Label_Title" runat="server" Text="Manage your bookings" Font-Size="XX-Large"></asp:Label>
            <br /><br />
        </div>

        
        <asp:DataList ID="DataListBookings" runat="server" DataKeyField="code" DataSourceID="SqlDataSourceBookings" OnItemCommand="DataListBookings_ItemCommand">

            <ItemTemplate>
                <asp:Label Text='<%# Eval("usr") %>' runat="server" ID="Label_User" Visible="false"/><br />
                <asp:Panel ID="PanelItem" runat="server" Visible="false" Wrap="true" style="margin:0;padding:0">  
                    <!-- Booking -->
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
                                        <div class="col-xs-4">
                                            <asp:Label ID="Label_TotalPrice" runat="server" Text='<%# Eval("totPrice") %>' Font-Size="Medium" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div class="col-xs-5">
                                            <asp:Button ID="Button_Delete" class="btn btn-danger" runat="server" Text="Delete" Width="90%" CommandName="ClickDelete"/>
                                        </div>
                                    </div>                            
                                </div>
                            </div>                
                        </div>
                    </div>
                    <!-- End Booking -->    
                </asp:Panel>                          
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource runat="server" ID="SqlDataSourceBookings" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT [usr], [code], [startDate], [finishDate], [totPrice] FROM [T_Booking]"></asp:SqlDataSource>
        
    </div>
</asp:Content>