<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileNestedMasterPage.master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Web.Formulario_web1" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderProfile" runat="server">
    
    <div class="container-fluid">
        <!-- This part is not editable by the user, it will be complete with information at DB of this user -->
        <div class="row">
            <asp:Label ID="Label_UserName" runat="server" Text="Mark" Font-Size="XX-Large"></asp:Label>
            &nbsp;            
            <asp:Label ID="Label_UserSurname" runat="server" Text="Sanders" Font-Size="XX-Large"></asp:Label>
        </div>
        <div class="row">
            <div class="col-xs-6" style="margin:0;padding:0">
                <asp:Label ID="Label_UserEmail" runat="server" Text="marksanders82@gmail.com" Font-Size="Large" Font-Italic="true"></asp:Label>
            </div>   
            <div class="col-xs-6" style="text-align:right">
                <asp:Label ID="Label_UserPremium" runat="server" Text="Regular User" Font-Size="Larger" Font-Bold="true" ForeColor="#996600"></asp:Label>
            </div>
        </div>
        <br />
        <!-- This fields will be editable by the user -->
        <div class="row">
            <div class="col-xs-6">
                <!--<div class="input-group">
                  <span class="input-group-addon" id="basic-addon1"><img src="assets/img/Phone-20.png" /></span>
                  <asp:TextBox ID="TextBox_UserPhone" class="form-control" runat="server" placeholder="Phone number" aria-describedby="basic-addon1"></asp:TextBox>
                </div>-->
                <div>
                    <img src="assets/img/Phone-20.png" />
                    &nbsp;            
                    <!--<asp:Label ID="Label_UserPhone" runat="server" Text="+34 622 10 41 88" Font-Size="Medium"></asp:Label>-->
                    <asp:TextBox ID="Text_UserPhone" runat="server" Text="+34 622 10 41 88" Font-Size="Medium"
                    ReadOnly="true" BorderStyle="None" BackColor="Transparent" Wrap="true"></asp:TextBox>    
                </div>
            </div>
            <div class="col-xs-6">
                <!--<div class="input-group">
                  <span class="input-group-addon" id="basic-addon2"><img src="assets/img/Calendar-20.png" /></span>
                  <asp:TextBox ID="TextBox_UserBirth" class="form-control" runat="server" placeholder="Birthdate" aria-describedby="basic-addon2"></asp:TextBox>
                </div>-->
                <div>
                    <img src="assets/img/Calendar-20.png" />
                    &nbsp;            
                    <!--<asp:Label ID="Label_UserBirth" runat="server" Text="27/04/1982" Font-Size="Medium"></asp:Label>-->
                    <asp:TextBox ID="Text_UserBirth" runat="server" Text="27/04/1982" Font-Size="Medium"
                    ReadOnly="true" BorderStyle="None" BackColor="Transparent" Wrap="true"></asp:TextBox>  
                </div>
            </div>     
        </div>
        <br />
        <div class="row">
            <div class="col-xs-6">
                <!--<div class="input-group">
                  <span class="input-group-addon" id="basic-addon3"><img src="assets/img/Building-20.png" /></span>
                  <asp:TextBox ID="TextBox_UserCity" class="form-control" runat="server" placeholder="City" aria-describedby="basic-addon3"></asp:TextBox>
                </div>-->
                <div>
                    <img src="assets/img/Building-20.png" />
                    &nbsp;            
                    <!--<asp:Label ID="Label_UserCity" runat="server" Text="Aquapolis" Font-Size="Medium"></asp:Label>-->
                    <asp:TextBox ID="Text_UserCity" runat="server" Text="Aquapolis" Font-Size="Medium"
                    ReadOnly="true" BorderStyle="None" BackColor="Transparent" Wrap="true"></asp:TextBox>  
                </div>
            </div>
            <div class="col-xs-6">
                <!--<div class="input-group">
                  <span class="input-group-addon" id="basic-addon4"><img src="assets/img/Home-20.png" /></span>
                  <asp:TextBox ID="TextBox_UserAddress" class="form-control" runat="server" placeholder="Address" aria-describedby="basic-addon4"></asp:TextBox>
                </div>-->
                <div>
                    <img src="assets/img/Home-20.png" />
                    &nbsp;            
                    <!--<asp:Label ID="Label_UserAddress" runat="server" Text="Av. Coldwater nº 23 7" Font-Size="Medium"></asp:Label>-->
                    <asp:TextBox ID="Text_UserAddress" runat="server" Text="Av. Coldwater nº 23 7" Font-Size="Medium"
                    ReadOnly="true" BorderStyle="None" BackColor="Transparent" Wrap="true"></asp:TextBox> 
                </div>                
            </div>     
        </div>
        <br />
        <div class="row">
            <div class="col-xs-6">
                <!--<div class="input-group">
                  <span class="input-group-addon" id="basic-addon5"><img src="assets/img/ID_Card-20.png" /></span>
                  <asp:TextBox ID="TextBox_UserNIF" class="form-control" runat="server" placeholder="NIF" aria-describedby="basic-addon5"></asp:TextBox>
                </div>-->
                <div>
                    <img src="assets/img/ID_Card-20.png" />
                    &nbsp;            
                    <!--<asp:Label ID="Label_UserNIF" runat="server" Text="45692333S" Font-Size="Medium"></asp:Label>-->
                    <asp:TextBox ID="Text_UserNIF" runat="server" Text="45692333S" Font-Size="Medium"
                    ReadOnly="true" BorderStyle="None" BackColor="Transparent" Wrap="true"></asp:TextBox> 
                </div>                
            </div>
            <div class="col-xs-6">
                <!--<div class="input-group">
                  <span class="input-group-addon" id="basic-addon6"><img src="assets/img/Driver_License_Card-20.png" /></span>
                  <asp:TextBox ID="TextBox_UserDrivingLicense" class="form-control" runat="server" placeholder="Driving License" aria-describedby="basic-addon6">
                  </asp:TextBox>
                </div>-->
                <div>
                    <img src="assets/img/Driver_License_Card-20.png" />
                    &nbsp;            
                    <!--<asp:Label ID="Label_UserDrivingLicense" runat="server" Text="None" Font-Size="Medium"></asp:Label>-->
                    <asp:TextBox ID="Text_UserDrivingLicense" runat="server" Text="None" Font-Size="Medium"
                    ReadOnly="true" BorderStyle="None" BackColor="Transparent" Wrap="true"></asp:TextBox> 
                </div>
            </div>     
        </div>
        <br />
        <div class="row" style="text-align:right">
            <div class="col-xs-12">
                <!--<asp:Button ID="Button_Save" class="btn btn-success" Width="20%" runat="server" Text="Save"/>-->
                <asp:Button ID="Button_Edit" CssClass="btn btn-info" Width="20%" runat="server" Text="Edit"/>
            </div>  
        </div>
    </div>
</asp:Content>
