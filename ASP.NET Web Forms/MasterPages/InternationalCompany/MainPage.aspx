<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="InternationalCompany.MainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLanguage" runat="server">
    <asp:HyperLink runat="server" NavigateUrl="~/Bulgarian/Home.aspx" Text="Bulgarian" />
    <asp:HyperLink runat="server" NavigateUrl="~/English/Home.aspx" Text="English"/>
</asp:Content>
