<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileNestedMasterPage.master" AutoEventWireup="true" CodeBehind="Premium.aspx.cs" Inherits="Web.Premium" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderProfile" runat="server">
    <div class="container-fluid">
        <div class="row">
            <asp:Label ID="Label_PersuadingMessage" runat="server" Text="Go Premium!" Font-Size="XX-Large"></asp:Label>
            <br /><br />
        </div>
        <div class="row">
            <div class="col-xs-6" style="border-radius:10px;padding:10px 5%">
                <div class="panel panel-warning">
                    <div class="panel-heading">
                        <h3 class="panel-title" style="text-align:center"><b>Regular User</b></h3>
                    </div>
                    <div class="panel-body">
                        <ul style="list-style-image:url(assets/img/Delete-15.png);margin-left:20%">
                            <li>Insurance</li>
                            <li>Baby seat</li>
                            <li>GPS</li>
                            <li>Roof rack</li>
                            <li>Chauffeur</li>
                            <li>No extra fees (for novices)</li>
                        </ul>
                    </div>
                    <div class="panel-footer" style="text-align:center">
                        <h4 style="text-align:center;margin-right:5px">Price: <b>FREE</b></h4>
                        <asp:Button ID="Button_RegularUser" CssClass="btn" runat="server" Text="Selected" Enabled="false"/>
                    </div>
                </div>                
            </div>
            <div class="col-xs-6" style="border-radius:10px;padding:10px 5%">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <h3 class="panel-title" style="text-align:center"><b>Premium User</b></h3>
                    </div>
                    <div class="panel-body">
                        <ul style="list-style-image:url(assets/img/Checkmark-15.png);margin-left:20%">
                            <li>Insurance</li>
                            <li>Baby seat</li>
                            <li>GPS</li>
                            <li>Roof rack</li>
                            <li>Chauffeur</li>
                            <li>No extra fees (for novices)</li>
                        </ul>
                    </div>
                    <div class="panel-footer" style="text-align:center">
                        <h4 style="text-align:center;margin-right:5px">Price: <b>65$</b><i><small> per year</small></i></h4>
                        <asp:Button ID="Button_PremiumUser" CssClass="btn btn-success" runat="server" Text="Upgrape"/>
                    </div>
                </div>                
            </div>
        </div>
    </div>
</asp:Content>