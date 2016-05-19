<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Web.Catalog" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="75px"> </asp:Panel>
    <div class="container-fluid" style="padding:20px">
        <div class="row-fluid">
            <div class="page-header" style="margin-left:20%;margin-right:20%">
                <h1>Catalog</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-3"></div>
            <div class="col-xs-6" style="align-items:center">
            <asp:Panel ID="Panel_SearchResult" runat="server">
                <asp:DataList ID="DataList_Consult" runat="server" DataSourceID="SqlDataSourceCarsCatalog" OnItemCommand="Catalog_ItemDataBound" >
                    <ItemTemplate>
                        <div class="panel panel-info" style="">
                            <div class="panel-heading">
                                <asp:Label ID="Label_CarName" runat="server" Text='<%# Eval("name") %>' Font-Size="Large"></asp:Label>
                            </div>
                            <div class="panel-body"  >
                                <div class="row" >
                                    <div class="col-xs-4">
                                        <img class="img-responsive" style="crop:inherit" src="assets/img/carPics/<%# Eval("IMG") %>" />                                        
                                        <!--IMG:
                                        <asp:Label Text='<%# Eval("IMG") %>' runat="server" ID="IMGLabel" /><br />-->
                                    </div>
                                    <div class="col-xs-4">
                                        <label for=""><em>Category:</em> &nbsp;</label>
                                        <asp:Label Text='<%# Eval("category") %>' runat="server" ID="Label_CarCategory" /><br />                            
                                        <label for=""><em>Description:</em></label><br />
                                        <p style="padding-left:20px;padding-bottom:0">
                                            <asp:Label Text='<%# Eval("descrip") %>' runat="server" ID="Label_CarDescription" />
                                        </p>
                                        <label for=""><em>Price per day:</em>&nbsp;</label>                
                                        <asp:Label Text='<%# Eval("price") %>' runat="server" ID="Label_CarPrice" />
                                    </div>
                                    <div class="col-xs-4">
                                        <label for=""><em>Automatic Transmission:</em></label><br />
                                        <asp:Label Text='<%# Eval("automaticTransmission") %>' runat="server" ID="Label_CarTransmission" /><br />
                                        <label for=""><em>Doors:</em></label><br />
                                        <asp:Label Text='<%# Eval("doors") %>' runat="server" ID="Label_CarDoors" /><br />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button_SeeMore" class="btn btn-primary" runat="server" Width="60%" style="margin-left:20%" Text="See more" CommandName="ClickSeeMore"/>
                                        <asp:Label ID="Label_CarCode" runat="server" Text='<%# Eval("code") %>' Visible="false"></asp:Label>
                                        <br />
                                    </div>
                                </div>                                
                            </div>
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource runat="server" ID="SqlDataSourceCarsCatalog" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' 
                    SelectCommand="SELECT [code],[IMG], [name], [category], [descrip], [price], [automaticTransmission], [doors], [code] FROM [T_Car]"></asp:SqlDataSource>
            </asp:Panel>
            </div>
            <div class="col-xs-3"></div>
        </div>       
    </div>
</asp:Content>