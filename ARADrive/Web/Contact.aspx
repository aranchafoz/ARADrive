<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Web.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel1" runat="server" Height="75px"> </asp:Panel>
    <div class="container-fluid" style="padding:20px">
        <div class="row-fluid">
            <div class="page-header" style="margin-left:20%;margin-right:20%">
                <h1>Get in contact with us</h1>
            </div>
            <div class="col-xs-4"></div>
            <div class="col-xs-4">
                <form class="form-signin" action="">
                    <div class="form-group">
                        <label for="">Your name&nbsp;<i style="color:#cccccc"><small>*required</small></i></label>
                        <asp:TextBox ID="TextBox_UserName" AutoCompleteType="DisplayName" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Your email&nbsp;<i style="color:#cccccc"><small>*required</small></i></label>
                        <asp:TextBox ID="TextBox_UserEmail" AutoCompleteType="Email" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Subject&nbsp;<i style="color:#cccccc"><small>*required</small></i></label>
                        <asp:TextBox ID="TextBox_Subject" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Your message</label>
                        <asp:TextBox ID="TextBox_Message" type="text" class="form-control" runat="server" Height="200px" TextMode="MultiLine"></asp:TextBox>
                    </div>                  
                    
                    <br />
                    <asp:Button ID="Button_Send" class="btn btn-primary" Width="26%" style="margin-left:37%;" runat="server" Text="Send" />                
                    <br />
                    <asp:Label ID="Label_Resultado" runat="server" Text="Label"></asp:Label>
                    <br />
                </form>
            </div>
            <div class="col-xs-4"></div>
        </div>       
    </div>
    <asp:Panel ID="Panel2" runat="server" Height="100px"> </asp:Panel>
</asp:Content>
