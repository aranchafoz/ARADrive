<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileNestedMasterPage.master" AutoEventWireup="true" CodeBehind="Formulario web1.aspx.cs" Inherits="Web.History" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderProfile" runat="server">
    <div class="container-fluid">
        <div class="row">
            <asp:Label ID="Label_Title" runat="server" Text="Explore your lasts rents" Font-Size="XX-Large"></asp:Label>
            <br /><br />
        </div>
        <div class="panel">
            <div class="panel-body">
                <div class="row">
                        <div class="col-xs-6">
                            <!-- Fechas -->     
                            <div class="row">
                                <div class="col-xs-4">
                                    <asp:Label ID="Label_BookingCode" runat="server" Text="00034TY" Font-Bold="true" Wrap="true"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:Label ID="Label_PickUp" type="date" runat="server" Text="01/12/2016" Wrap="true"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:Label ID="Label_DropOff" type="date" runat="server" Text="08/12/2016" Wrap="true"></asp:Label>
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
                                    <asp:Label ID="Label_TotalPrice" runat="server" Text="$ 156" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="col-xs-5">
                                    <asp:Button ID="Button_Rent" class="btn btn-info" runat="server" Text="See more" Width="90%"/>
                                </div>
                            </div>                            
                        </div>
                    </div>                
            </div>
        </div>
    </div>
</asp:Content>