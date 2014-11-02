<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="02.AppendSession.aspx.cs" Inherits="State_Management.AppendSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Add Item" OnClick="Btn_Clicked" />
                <br />  
                <asp:Label ID="Label1" runat="server" Text="Items in current session: "></asp:Label>
            </div>

        </form>
    </body>
</html>
