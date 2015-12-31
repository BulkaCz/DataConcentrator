<%@ Page Title="" Language="C#" MasterPageFile="~/DataConcentrator.Master" AutoEventWireup="true" CodeBehind="DBVaha.aspx.cs" Inherits="DataConcentratorWEB.DBVaha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="index" DataSourceID="SQLVaha" PageSize="30">
        <Columns>
            <asp:BoundField DataField="index" HeaderText="index" InsertVisible="False" ReadOnly="True" SortExpression="index" />
            <asp:BoundField DataField="cas" HeaderText="cas" SortExpression="cas" />
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
            <asp:BoundField DataField="errorCode" HeaderText="errorCode" SortExpression="errorCode" />
            <asp:BoundField DataField="vahaVykon" HeaderText="vahaVykon" SortExpression="vahaVykon" />
            <asp:BoundField DataField="vahaABS" HeaderText="vahaABS" SortExpression="vahaABS" />
            <asp:BoundField DataField="rychlostPasu" HeaderText="rychlostPasu" SortExpression="rychlostPasu" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SQLVaha" runat="server" ConnectionString="<%$ ConnectionStrings:CevelDBConnectionString %>" SelectCommand="SELECT * FROM [Vaha] ORDER BY [cas] DESC, [id]"></asp:SqlDataSource>
</asp:Content>
