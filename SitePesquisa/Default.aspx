<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SitePesquisa._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <label>Busca:</label>
    <asp:TextBox ID="txtBusca" runat="server"></asp:TextBox>
    <asp:Button ID="btnBusca" runat="server" OnClick="btnBusca_Click" Text="Buscar" />
    <br />
    <asp:Label ID="lblRetorno" runat="server" Visible="false"></asp:Label>
    
</asp:Content>
