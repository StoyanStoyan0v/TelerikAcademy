<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="HelloAsp.hello" %>
<%
HelloAspLabel.Text = "Hello, ASP.NET! (from aspx)";
%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">    
            <div>
                <asp:Label ID="HelloAspLabel" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="AnotherHelloAspLabel" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Location" runat="server"></asp:Label>
            </div>
        </form>
    </body>
</html>
