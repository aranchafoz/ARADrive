<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server" Height="75px"> </asp:Panel>
    <div class="container-fluid" style="padding:20px">
        <div class="row-fluid">
            <div class="page-header" style="margin-left:20%;margin-right:20%">
                <h1>Make a reservation</h1>
            </div>
            <div class="col-xs-4"></div>
            <div class="col-xs-4 well">
                <form class="form-signin" action="">
                    <div class="form-group">
                        <label for="">Pick up date</label>
                        <asp:TextBox ID="Calendar_PickUp1" type="date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="">Drop off date</label>
                        <asp:TextBox ID="Calendar_DropOff1" type="date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    </div>                  
                    
                    <br />
                    <asp:Button ID="Button_Search" class="btn" Width="26%" style="margin-left:37%;" runat="server" Text="Search" />                
                    <br />
                </form>
            </div>
            <div class="col-xs-4"></div>
        </div>       
    </div>
    <asp:Panel ID="Panel3" runat="server" Height="100px"> </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Height="100px"> </asp:Panel>
    <table style="width: 100%;">
        <!--Fila 1-->
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <!--Fila 2-->
        <tr> 
            <td>&nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="Pick Up Date"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Calendar ID="Calendar_PickUp" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle Font-Bold="true" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Drop Off Date"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:Calendar ID="Calendar_DropOff" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle Font-Bold="true" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
            <td>
            </td>
        </tr>

        <!--Fila 3-->
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <!--Fila 4-->
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <!--Fila 5-->
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <table>
        <tr>
            <td>
                <asp:Panel ID="Line1" runat="server" Visible="false" BackColor="#00cc99" Width="100px" Height="10px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label_Result" runat="server" Visible="false"/>
            </td>
        </tr>
    </table>

</asp:Content>
