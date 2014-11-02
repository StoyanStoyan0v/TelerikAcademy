<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="StudentInfo.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="fname" runat="server" Text="First Name: "></asp:Label>
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lname" runat="server" Text="Last Name: "></asp:Label>
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="fnumber" runat="server" Text="Faculty Number: "></asp:Label>
                <asp:TextBox ID="FacNumber" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="uni" runat="server" Text="University: "></asp:Label>
                <asp:DropDownList ID="University" runat="server">
                    <asp:ListItem> Sofia University </asp:ListItem>
                    <asp:ListItem> UNWE </asp:ListItem>
                    <asp:ListItem> New Bulgarian University </asp:ListItem>
                    <asp:ListItem> Medical University </asp:ListItem>
                    <asp:ListItem> Telerik Academy </asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="spec" runat="server" Text="Specialty: "></asp:Label>
                <asp:DropDownList ID="Specialty" runat="server">
                    <asp:ListItem> Software Technologies </asp:ListItem>
                    <asp:ListItem> Artificial Intelligence </asp:ListItem>
                    <asp:ListItem> Marketing </asp:ListItem>
                    <asp:ListItem> Finances </asp:ListItem>
                    <asp:ListItem> Dental Medicine </asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="course" runat="server" Text="Courses: "></asp:Label>
                <asp:ListBox ID="Courses" runat="server" SelectionMode="Multiple" >
                    <asp:ListItem >Maths</asp:ListItem>
                    <asp:ListItem >Biology</asp:ListItem>
                    <asp:ListItem >Marketing Basics</asp:ListItem>
                    <asp:ListItem >Corporate Finances</asp:ListItem>
                    <asp:ListItem >Economics</asp:ListItem>
                </asp:ListBox>
                <br />
                <asp:Button ID="submit" runat="server" Text="Submit" OnClick="Submit" />
            </div>

        </form>
    </body>
</html>
