<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web.Home" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server" Height="70px"> </asp:Panel>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="container-fluid" style="padding:20px;">
            <div class="row-fluid">
                <div class="page-header" style="margin-left:20%;margin-right:20%">
                    <h1>Make a reservation</h1>
                </div>
                <div class="col-xs-4"></div>
                <div class="col-xs-4 well transparent">
                    <form class="form-signin" action="">
                        <div class="form-group">
                            <label for="">Pick up date&nbsp;<i style="color:#666666"><small>*required</small></i></label>
                            <asp:TextBox ID="Calendar_PickUp1" type="date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Drop off date&nbsp;<i style="color:#666666"><small>*required</small></i></label>
                            <asp:TextBox ID="Calendar_DropOff1" type="date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>                        
                        <asp:Label ID="Label_Error" runat="server" Text="" Font-Italic="true" Font-Size="Small" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:Panel ID="Panel_MainContent" runat="server">
                            <asp:Button ID="Button_Search" class="btn btn-primary" runat="server" Width="26%" style="margin-left:37%;"  Text="Search" 
                                OnClick="OnClick_Search" OnClientClick="OnClick_Search"/> 
                        </asp:Panel>               
                        <br />                        
                        <!--<asp:Button ID="Button_Format" class="btn btn-danger" runat="server" Width="26%" style="margin-left:37%;"  Text="Format" 
                                />-->
                    </form>
                </div>
                <div class="col-xs-4"></div>
            </div>       
        </div>
        <!-- Results -->
        <div class="row">
            <div class="col-xs-3"></div>
            <div class="col-xs-6" style="align-items:center">
            <asp:Panel ID="Panel_SearchResult" runat="server" Height="0">
                <asp:DataList ID="DataList_Consult" runat="server" DataSourceID="SqlDataSourceCarsDays">
                    <ItemTemplate>
                        <div class="panel panel-info" style="">
                            <div class="panel-heading">
                                <asp:Label ID="Label_CarName" runat="server" Text='<%# Eval("name") %>' Font-Size="Large"></asp:Label>
                            </div>
                            <div class="panel-body"  >
                                <div class="row" >
                                    <div class="col-xs-4">
                                        <img class="img-responsive" style="crop:inherit" src="assets/img/carPics/<%# Eval("IMG") %>" />  
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label ID="Label_CarCode" runat="server" Text='<%# Eval("category") %>' Visible="false"></asp:Label>
                                        <label for=""><em>Category:</em> &nbsp;</label>
                                        <asp:Label Text='<%# Eval("category") %>' runat="server" ID="Label_CarCategory" /><br />                            
                                        <label for=""><em>Description:</em></label><br />
                                        <p style="padding-left:20px;padding-bottom:0">
                                            <asp:Label Text='<%# Eval("descrip") %>' runat="server" ID="Label_CarDescription" />
                                        </p>
                                        <label for=""><em>Price per day:</em>&nbsp;</label>                
                                        <asp:Label Text='<%# Eval("price") %>' runat="server" ID="Label_CarPrice" />
                                    </div>
                                    <div class="col-xs-1"></div>
                                    <div class="col-xs-2">
                                        <label for=""><small><strong>Total price: &nbsp;</strong></small></label>
                                        <asp:Label Text="$ 10" runat="server" ID="Label_TotalPrice" Font-Size="X-Large" Font-Bold="true"/>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button_SeeMore" class="btn btn-primary" runat="server" Width="100%"  Text="See more" CommandName="ClickSeeMore"/>
                                        <br />
                                    </div>
                                </div>                                
                            </div>
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource runat="server" ID="SqlDataSourceCarsDays" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' 
                    SelectCommand="SELECT [code], [IMG], [name], [category], [descrip], [price] FROM [T_Car]"></asp:SqlDataSource>
            </asp:Panel>
            </div>
            <div class="col-xs-3"></div>
        </div>
        <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender_Result" runat="server" Enabled="true"
            TargetControlID="Panel_SearchResult" ExpandControlID="Button_Search" CollapseControlID="Button_Format" 
            Collapsed="true" 
            SuppressPostBack="false">
        </ajaxToolkit:CollapsiblePanelExtender> 
</asp:Content>

