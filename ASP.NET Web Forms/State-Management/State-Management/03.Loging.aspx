<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="03.Loging.aspx.cs" Inherits="State_Management.Loging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Log in" OnClick="LogIn" />
    </div>
    </form>
</body>
</html>
