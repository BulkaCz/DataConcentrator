<%@ Page Title="" Language="C#" MasterPageFile="~/DataConcentrator.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="DataConcentratorWEB.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="ddlConfigFiles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlConfigFiles_SelectedIndexChanged" Width="150px">
    </asp:DropDownList> <br>
    <asp:ListBox ID="lbLogs" runat="server" AutoPostBack="True" Height="597px" Width="1266px"></asp:ListBox>
    <p>
    </p>
</asp:Content>
