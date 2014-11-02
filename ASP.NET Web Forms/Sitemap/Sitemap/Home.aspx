<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Sitemap.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <h1>Home</h1>
                <asp:TreeView ID="TreeViewSitePages" runat="server" 
                              DataSourceID="SiteMapDataSource" SkipLinkText=""></asp:TreeView>
                <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" />
            </div>
        </form>
    </body>
</html>
