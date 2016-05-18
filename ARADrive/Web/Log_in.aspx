<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Log_in.aspx.cs" Inherits="Web.Log_in" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel1" runat="server" Height="75px"> </asp:Panel>
    <div class="container-fluid" style="padding:20px">
        <div class="row-fluid">
            <div class="page-header" style="margin-left:20%;margin-right:20%">
                <h1>Log in ARADrive</h1>
            </div>
            <div class="col-xs-4"></div>
            <div class="col-xs-4">
                <form class="form-signin" action="">
                    <div class="form-group">
                        <label for="">Email address</label>
                        <asp:TextBox ID="TextBox_Email" AutoCompleteType="Email" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Password</label>
                        <asp:TextBox ID="TextBox_Password" type="password" class="form-control" runat="server"></asp:TextBox>
                    </div>                         
                    <asp:Label ID="Label_Error" runat="server" Text="" Font-Italic="true" Font-Size="Small" ForeColor="Red"></asp:Label>
                    <br />               
                    
                    <br />
                    <asp:Button ID="Button_Submit" class="btn btn-primary" Width="26%" style="margin-left:37%;" runat="server" Text="Log in" OnClick="Button_Submit_Click" />                
                    <br />
                </form>
            </div>
            <div class="col-xs-4"></div>
        </div>       
    </div>
</asp:Content>
