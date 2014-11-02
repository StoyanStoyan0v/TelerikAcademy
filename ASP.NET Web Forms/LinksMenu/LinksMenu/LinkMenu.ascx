<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkMenu.ascx.cs" Inherits="LinksMenu.LinkMenu" %>
<asp:DataList ID="ListMenuDataList" runat="server" >
    <ItemTemplate >
        <asp:HyperLink  ID="LinkText" runat="server" NavigateUrl='<%# Eval("url")%>'
                        ForeColor ='<%# this.FontColour %>' 
                        Font-Names="<%# new string[]{this.FontName} %>"           
                        Text='<%# Eval("Title") %>'>> </asp:HyperLink>
    </ItemTemplate>
</asp:DataList>
