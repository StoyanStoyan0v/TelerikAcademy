<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaper.aspx.cs" Inherits="HtmlEscaping.Escaper" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:TextBox ID="TextToShow" runat="server" ></asp:TextBox>
                <asp:Button ID="ShowBtn" runat="server" Text="Show" OnClick="Btn_Click" />
                <br />
                <asp:Label ID="ShowLabel" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="ShowText" runat="server"></asp:TextBox>
            </div>
        </form>
    </body>
</html>
