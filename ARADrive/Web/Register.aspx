<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.Register" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="75px"> </asp:Panel>
    <asp:ScriptManager ID="ScriptManagerRegister" runat="server"></asp:ScriptManager>
    <div class="container-fluid" style="padding:20px">
        <div class="row-fluid">
            <div class="page-header" style="margin-left:20%;margin-right:20%">
                <h1>Create your account</h1>
            </div>
            <div class="col-xs-4"></div>
            <div class="col-xs-4">
                <div class="panel translucid" style="padding:30px">
                    <form class="form-signin" action="">
                        <asp:Label ID="Label_Error" runat="server" Text="" Font-Italic="true" Font-Size="Small" ForeColor="Red"></asp:Label>
                        <!--Profile-->
                        <legend>Profile</legend>
                        <div class="form-group">
                            <label for="">Name</label>
                            <asp:TextBox ID="TextBox_Name" AutoCompleteType="FirstName" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Surname</label>
                            <asp:TextBox ID="TextBox_Surname" AutoCompleteType="LastName" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Email address</label>
                            <asp:TextBox ID="TextBox_Email" AutoCompleteType="Email" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Confirm email address</label>
                            <asp:TextBox ID="TextBox_EmailConfirm" AutoCompleteType="Email" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Password</label>
                            <asp:TextBox ID="TextBox_Password" type="password" class="form-control" runat="server"></asp:TextBox>
                            <p style="color:#d0e0d9"> <em>It must be at least 8 characters</em> 
                            <br /><em>You must include a letter</em> 
                            <br /><em>You must include a number</em>
                            <br /><em>It can not contain the word "password"</em></p>
                        </div>
                        <div class="form-group">
                            <label for="">Confirm password</label>
                            <asp:TextBox ID="TextBox_PasswordConfirm" type="password" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <!--Contact information-->
                        <legend>Contact information</legend>
                        <div class="form-group">
                            <label for="">Country</label>
                            <asp:TextBox ID="TextBox_Country" class="form-control" runat="server"></asp:TextBox>
                        </div>    
                        <div class="form-group">
                            <label for="">City</label>
                            <asp:TextBox ID="TextBox_Location" AutoCompleteType="HomeCity" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Address</label>
                            <asp:TextBox ID="TextBox_Address" AutoCompleteType="HomeStreetAddress" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Postal code</label>
                            <asp:TextBox ID="TextBox_PostalCode" AutoCompleteType="HomeZipCode" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Telephone number</label>
                            <asp:TextBox ID="TextBox_Telephone" AutoCompleteType="Cellular" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">NIF</label>
                            <asp:TextBox ID="TextBox_NIF" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Birthdate</label>
                            <asp:TextBox ID="TextBox_Birthdate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <!--Driving license details-->                                     
                        <legend>Driving license details</legend>
                        <div class="form-group">
                            <asp:CheckBox ID="CheckBox_DrivingLicense" runat="server" />
                            <label for="">Driving license</label>                      
                        </div>     
                        <!--To be completed only if he has-->
                        <asp:Panel ID="Panel_DrivingLicense" runat="server" Height="0">                    
                            <div class="form-group">
                                <label for="">Issuing country</label>
                                <asp:TextBox ID="TextBox_IssuingCountry" class="form-control" runat="server"></asp:TextBox>
                            </div>                                 
                            <div class="form-group">
                                <label for="">Driving license number</label>
                                <asp:TextBox ID="TextBox_DrivingLicenseNumber" class="form-control" runat="server"></asp:TextBox>
                            </div>      
                            <div class="form-group">
                                <label for="">Due date</label>
                                <asp:TextBox ID="TextBox_DrivingLicenseDueDate" type="date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                            </div>              
                        </asp:Panel>                    
                        <br />
                        <asp:Button ID="Button_Submit" class="btn btn-default" runat="server" Text="Submit" OnClick="Button_Submit_Click"/>                
                        <br />
                    </form>
                </div>
            </div>
            <div class="col-xs-4"></div>
        </div>       
    </div>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender_DrivingLicense" runat="server" Enabled="true"
            TargetControlID="Panel_DrivingLicense" ExpandControlID="CheckBox_DrivingLicense" CollapseControlID="CheckBox_DrivingLicense"
            Collapsed="true" 
            SuppressPostBack="false" />
</asp:Content>
