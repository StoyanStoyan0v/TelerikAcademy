<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestMenuListaspx.aspx.cs" Inherits="LinksMenu.TestMenuListaspx" %>
<%@ Register src="LinkMenu.ascx" tagname="LinksMenu"
tagprefix="userControl" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Links</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <userControl:LinksMenu ID="LinksMenuList" FontColour="Red" FontName="Verdana" runat="server"></userControl:LinksMenu>
        </form>
    </body>
</html>
