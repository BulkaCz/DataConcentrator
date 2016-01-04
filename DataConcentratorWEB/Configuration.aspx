<%@ Page Title="" Language="C#" MasterPageFile="~/DataConcentrator.Master" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="DataConcentratorWEB.Configuration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        height: 23px;
    }
    .auto-style2 {
        width: 220px;
    }
    .auto-style3 {
        height: 23px;
        width: 220px;
    }
    .auto-style4 {
        width: 220px;
        height: 26px;
    }
    .auto-style5 {
        height: 26px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Port 1"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="Label10" runat="server" Text="Port 2"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="Enabled"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="cbPort1Enabled" runat="server" AutoPostBack="True" />
            </td>
            <td>&nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="Label11" runat="server" Text="Enabled"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="cbPort2Enabled" runat="server" AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label3" runat="server" Text="Typ měřícího bodu"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddlPort1Typ" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem Value="Elektromer">Elektroměr</asp:ListItem>
                    <asp:ListItem Value="Vaha">Váha</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style3">
                <asp:Label ID="Label12" runat="server" Text="Typ měřícího bodu"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddlPort2Typ" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem Value="Elektromer">Elektroměr</asp:ListItem>
                    <asp:ListItem Value="Vaha">Váha</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td class="auto-style3">
                <asp:Label ID="Label4" runat="server" Text="ID měřícího bodu"></asp:Label>
             </td>
            <td class="auto-style1">
                <asp:TextBox ID="tbPort1ID" runat="server" AutoPostBack="True" CausesValidation="True" TextMode="Number"></asp:TextBox>
             </td>
            <td class="auto-style1"></td>
            <td class="auto-style3">
                <asp:Label ID="Label13" runat="server" Text="ID měřícího bodu"></asp:Label>
             </td>
            <td class="auto-style1">
                <asp:TextBox ID="tbPort2ID" runat="server" AutoPostBack="True" TextMode="Number"></asp:TextBox>
             </td>
        </tr>
         <tr>
            <td class="auto-style4">
                <asp:Label ID="Label5" runat="server" Text="Perioda komunikace (ms)"></asp:Label>
             </td>
            <td class="auto-style5">
                <asp:TextBox ID="tbPort1PollInterval" runat="server" AutoPostBack="True" TextMode="Number"></asp:TextBox>
             </td>
            <td class="auto-style5"></td>
            <td class="auto-style4">
                <asp:Label ID="Label14" runat="server" Text="Perioda komunikace (ms)"></asp:Label>
             </td>
            <td class="auto-style5">
                <asp:TextBox ID="tbPort2PollInterval" runat="server" AutoPostBack="True" TextMode="Number"></asp:TextBox>
             </td>
        </tr>
         <tr>
            <td class="auto-style4">
                <asp:Label ID="Label6" runat="server" Text="Port Name"></asp:Label>
             </td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlPort1Name" runat="server" Width="150px">
                </asp:DropDownList>
             </td>
            <td class="auto-style5"></td>
            <td class="auto-style4">
                <asp:Label ID="Label15" runat="server" Text="Port Name"></asp:Label>
             </td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlPort2Name" runat="server" AutoPostBack="True" Width="150px">
                </asp:DropDownList>
             </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label7" runat="server" Text="BaudRate"></asp:Label>
             </td>
            <td>
                <asp:DropDownList ID="ddlPort1BaudRate" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem>9600</asp:ListItem>
                    <asp:ListItem>19200</asp:ListItem>
                    <asp:ListItem>38400</asp:ListItem>
                    <asp:ListItem>57600</asp:ListItem>
                    <asp:ListItem>115200</asp:ListItem>
                </asp:DropDownList>
             </td>
            <td>&nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="Label16" runat="server" Text="BaudRate"></asp:Label>
             </td>
            <td>
                <asp:DropDownList ID="ddlPort2BaudRate" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem>9600</asp:ListItem>
                    <asp:ListItem>19200</asp:ListItem>
                    <asp:ListItem>38400</asp:ListItem>
                    <asp:ListItem>57600</asp:ListItem>
                    <asp:ListItem>115200</asp:ListItem>
                </asp:DropDownList>
             </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label8" runat="server" Text="Parity"></asp:Label>
             </td>
            <td>
                <asp:DropDownList ID="ddlPort1Parity" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem>None</asp:ListItem>
                    <asp:ListItem>Even</asp:ListItem>
                    <asp:ListItem>Odd</asp:ListItem>
                </asp:DropDownList>
             </td>
            <td>&nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="Label17" runat="server" Text="Parity"></asp:Label>
             </td>
            <td>
                <asp:DropDownList ID="ddlPort2Parity" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem>None</asp:ListItem>
                    <asp:ListItem>Even</asp:ListItem>
                    <asp:ListItem>Odd</asp:ListItem>
                </asp:DropDownList>
             </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label9" runat="server" Text="DataBits"></asp:Label>
             </td>
            <td>
                <asp:DropDownList ID="ddlPort1DataBits" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem Selected="True">8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                </asp:DropDownList>
             </td>
            <td>&nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="Label18" runat="server" Text="DataBits"></asp:Label>
             </td>
            <td>
                <asp:DropDownList ID="ddlPort2DataBits" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem Selected="True">8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                </asp:DropDownList>
             </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label19" runat="server" Text="StopBits"></asp:Label>
             </td>
            <td>
                <asp:DropDownList ID="ddlPort1StopBits" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                </asp:DropDownList>
             </td>
            <td>&nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="Label20" runat="server" Text="StopBits"></asp:Label>
             </td>
            <td>
                <asp:DropDownList ID="ddlPort2StopBits" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                </asp:DropDownList>
             </td>
        </tr>
    </table>
<asp:Button ID="btnLoadConfig" runat="server" OnClick="btnLoadConfig_Click" Text="Read Config" />
<asp:Button ID="btnSaveConfig" runat="server" OnClick="btnSaveConfig_Click" Text="Write Config" />
</asp:Content>
