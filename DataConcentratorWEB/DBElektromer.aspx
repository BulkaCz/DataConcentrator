<%@ Page Title="" Language="C#" MasterPageFile="~/DataConcentrator.Master" AutoEventWireup="true" CodeBehind="Databaze.aspx.cs" Inherits="DataConcentratorWEB.Databaze" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="index" DataSourceID="SqlElektromer">
        <Columns>
            <asp:BoundField DataField="index" HeaderText="index" InsertVisible="False" ReadOnly="True" SortExpression="index" />
            <asp:BoundField DataField="cas" HeaderText="cas" SortExpression="cas" />
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
            <asp:BoundField DataField="errorCode" HeaderText="errorCode" SortExpression="errorCode" />
            <asp:BoundField DataField="cinnaEnergie" HeaderText="cinnaEnergie" SortExpression="cinnaEnergie" />
            <asp:BoundField DataField="jalovaEnergie" HeaderText="jalovaEnergie" SortExpression="jalovaEnergie" />
            <asp:BoundField DataField="cinnyVykon" HeaderText="cinnyVykon" SortExpression="cinnyVykon" />
            <asp:BoundField DataField="jalovyVykon" HeaderText="jalovyVykon" SortExpression="jalovyVykon" />
            <asp:BoundField DataField="ucinnik" HeaderText="ucinnik" SortExpression="ucinnik" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlElektromer" runat="server" ConnectionString="<%$ ConnectionStrings:CevelDBConnectionString %>" SelectCommand="SELECT * FROM [Elektromer] ORDER BY [cas] DESC, [id]"></asp:SqlDataSource>
    
    </asp:Content>
