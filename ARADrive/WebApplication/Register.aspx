<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DisenyoWeb.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="75px"> </asp:Panel>
    <div class="container-fluid" style="padding:20px">
        <div class="row-fluid">
            <div class="page-header" style="margin-left:20%;margin-right:20%">
                <h1>Create your account</h1>
            </div>
            <div class="col-xs-4"></div>
            <div class="col-xs-4">
                <form class="form-signin" action="">
                    <!--Profile-->
                    <legend>Profile</legend>
                    <div class="form-group">
                        <label for="">Name</label>
                        <asp:TextBox ID="TextBox_Name" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Surname</label>
                        <asp:TextBox ID="TextBox_Surname" class="form-control" runat="server"></asp:TextBox>
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
                        <p> It must be at least 8 characters
                        <br />You must include a letter
                        <br />You must include a number
                        <br />It can not contain the word "password "</p>
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
                        <label for="">Location</label>
                        <asp:TextBox ID="TextBox_Location" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Address</label>
                        <asp:TextBox ID="TextBox_Address" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Postal code</label>
                        <asp:TextBox ID="TextBox_PostalCode" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Telephone number</label>
                        <asp:TextBox ID="TextBox_Telephone" type="number" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Mobile number</label>
                        <asp:TextBox ID="TextBox_Mobile" type="number" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <!--Driving license details-->                                     
                    <legend>Driving license details</legend>
                    <div class="form-group">
                        <asp:CheckBox ID="CheckBox_DrivingLicense" runat="server" />
                        <label for="">Driving license</label>                      
                    </div>     
                    <!--To be completed only if he has-->
                    <div class="form-group">
                        <label for="">NIF</label>
                        <asp:TextBox ID="TextBox_NIF" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Issuing country</label>
                        <asp:TextBox ID="TextBox_IssuingCountry" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Birthdate</label>
                        <asp:TextBox ID="TextBox_Birthdate" type="date" class="form-control" runat="server"></asp:TextBox>
                    </div>             
                    <div class="form-group">
                        <label for="">Driving license number</label>
                        <asp:TextBox ID="TextBox_DrivingLicenseNumber" class="form-control" runat="server"></asp:TextBox>
                    </div>      
                    <div class="form-group">
                        <label for="">Due date</label>
                        <asp:TextBox ID="TextBox_DrivingLicenseDueDate" type="date" class="form-control" runat="server"></asp:TextBox>
                    </div>              
                    
                    
                    <br />
                    <asp:Button ID="Button_Sudmit" class="btn btn-default" runat="server" Text="Sudmit" />                
                    <br />
                </form>
            </div>
            <div class="col-xs-4"></div>
        </div>       
    </div>
    <asp:Panel ID="Panel2" runat="server" Height="100px"> </asp:Panel>
</asp:Content>
