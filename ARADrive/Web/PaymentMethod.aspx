<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileNestedMasterPage.master" AutoEventWireup="true" CodeBehind="PaymentMethod.aspx.cs" Inherits="Web.Formulario_web2" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderProfile" runat="server">
    <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading">
                <asp:Label ID="Label_Info" runat="server" Text="Submit you credentials to rent!" Font-Size="XX-Large"></asp:Label>
            </div>
            <div class="panel-body">
                <h3>Login with <img src="assets/img/Paypal-64.png" /></h3><br />
                <div class="col-xs-6">
                    <!-- User -->
                    <div class="input-group">
                        <span class="input-group-addon" id="basic-addon1"><img src="assets/img/User-20.png" /></span>
                        <asp:TextBox ID="TextBox_PaypalUser" class="form-control" runat="server" placeholder="User" aria-describedby="basic-addon1"></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-6">
                    <!-- Password -->
                    <div class="input-group">
                      <span class="input-group-addon" id="basic-addon2"><img src="assets/img/Key-20.png" /></span>
                      <asp:TextBox ID="TextBox_PaypalPassword" class="form-control" runat="server" placeholder="Password" aria-describedby="basic-addon2" TextMode="Password"></asp:TextBox>
                    </div>
                    <br />
                    <div class="row" style="text-align:right">
                        <div class="col-xs-12">
                            <!--<asp:Button ID="Button_Save" class="btn btn-success" Width="20%" runat="server" Text="Save"/>-->
                            <asp:Button ID="Button_Submit" class="btn btn-primary" Width="40%" runat="server" Text="Submit" OnClick="Button_Submit_Click"/>
                        </div>  
                    </div>
                </div>  
                
            </div>
        </div>
    </div>
</asp:Content>