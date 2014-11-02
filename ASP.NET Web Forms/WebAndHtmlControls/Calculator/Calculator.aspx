<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link href="styles.css" rel="stylesheet" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Panel ID="calculator" runat="server">
                    <asp:TextBox ID="Input" runat="server" OnTextChanged="ChangeInput"></asp:TextBox>
                    <br />
                    <asp:Button ID="One" runat="server" Text="1" OnClick="Click_One"/>
                    <asp:Button ID="Two" runat="server" Text="2" OnClick="Click_One"/>
                    <asp:Button ID="Three" runat="server" Text="3" OnClick="Click_One"/>
                    <asp:Button ID="Plus" runat="server" Text="+" OnClick="Click_One"/>
                    <br />
                    <asp:Button ID="Four" runat="server" Text="4" OnClick="Click_One"/>
                    <asp:Button ID="Five" runat="server" Text="5" OnClick="Click_One" />
                    <asp:Button ID="Six" runat="server" Text="6" OnClick="Click_One" />
                    <asp:Button ID="Minus" runat="server" Text="-" OnClick="Click_One"/>
                    <br />
                    <asp:Button ID="Seven" runat="server" Text="7" OnClick="Click_One"/>
                    <asp:Button ID="Eight" runat="server" Text="8" OnClick="Click_One"/>
                    <asp:Button ID="Nine" runat="server" Text="9" OnClick="Click_One"/>
                    <asp:Button ID="Multiply" runat="server" Text="*" OnClick="Click_One"/>
                     <br />
                    <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Click_One"/>
                    <asp:Button ID="Zero" runat="server" Text="0" OnClick="Click_One"/>
                    <asp:Button ID="Divide" runat="server" Text="/" OnClick="Click_One"/>
                    <asp:Button ID="Square" runat="server" Text="√" OnClick="Click_One"/>
                    <br />
                    <asp:Button ID="Equal" runat="server" Text="=" OnClick="Click_One"/>
                </asp:Panel>
            </div>
        </form>
    </body>
</html>
