<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="RandomGeneratorWebControls.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="LowerLabel" runat="server" Text="Lower: "></asp:Label>
                <asp:TextBox ID="Lower" runat="server"></asp:TextBox>                
                <br />
                <asp:Label ID="UpperLabel" runat="server" Text="Upper: "></asp:Label>
                <asp:TextBox ID="Upper" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="GenerateNumber" runat="server" Text="Generate" OnClick="Btn_Click" />
                <br />
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </div>
        </form>
    </body>
</html>
