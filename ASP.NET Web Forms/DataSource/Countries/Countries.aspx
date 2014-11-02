<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="Countries.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">

            <h3> Continents: </h3>

            <asp:ListBox ID="ListBoxContinents" runat="server"
                         DataTextField="Name" DataValueField="Name" 
                         OnSelectedIndexChanged="ListBoxContinents_SelectedIndexChanged"
                         AutoPostBack="true" />

            <h3>Continents:</h3>

            <asp:GridView ID="GridViewCountries" runat="server" 
                          AutoGenerateColumns="False" DataKeyNames="CountryId" PageSize="1"
                          AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridViewCountries_PageIndexChanging" OnRowCommand="Command">
                <Columns>
                    <asp:ButtonField  buttontype="Link"
                                      commandname="View" 
                                      text="View">
                    </asp:ButtonField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                    <asp:BoundField DataField="Continent.Name" HeaderText="Continent" SortExpression="Continent.Name" />
                </Columns>
            </asp:GridView>

            <h3>Towns: </h3>

            <asp:ListView ID="TownsView" runat="server" ItemType="Countries.Data.Models.Town">
                <ItemTemplate>
                    
                    <%# Item.Name %> | <%# Item.Population %> | <%# Item.Country.Name %>
                </ItemTemplate>
            </asp:ListView>

        </form>
    </body>
</html>
