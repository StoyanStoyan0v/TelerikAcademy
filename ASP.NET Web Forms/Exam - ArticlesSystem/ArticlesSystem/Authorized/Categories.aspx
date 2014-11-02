<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="ArticlesSystem.Categories" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:gridview id="CategoriesGridView" 
                  autogeneratecolumns="False"
                  allowpaging="True" PageSize="5" AllowSorting="true" OnSorting="Sort"       
                  runat="server" DataKeyNames="Id" OnRowEditing="Edit" OnRowDeleting="Delete"                  
                  OnPageIndexChanging="PageIndexChanged"
                  GridLines="None">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name"                        
                            SortExpression="Name" />
            <asp:ButtonField  buttontype="Link"
                              commandname="Edit" 
                              text="Edit" ItemStyle-CssClass="btn btn-info">
            </asp:ButtonField>

            <asp:ButtonField  buttontype="Link"
                              commandname="Delete" 
                              text="Delete" ItemStyle-CssClass="btn btn-danger">
            </asp:ButtonField>

        </Columns>
    </asp:gridview>
    <asp:Label runat="server">Enter name and click edit: </asp:Label>
    <asp:TextBox runat="server" ID="EditName"></asp:TextBox>
    <hr />
    <asp:Label runat="server">Add new category: </asp:Label>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="CatName" CssClass="col-md-2 control-label">Content</asp:Label>
        <div class="col-md-6">
            <asp:TextBox runat="server" ID="CatName" TextMode="SingleLine" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="CatName"
                                        CssClass="text-danger" ErrorMessage="The category name field is required." />
        </div>
    </div>
    <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="AddCatBtn" OnClick="AddCatBtn_Click" Text="Add Category"></asp:LinkButton>

</asp:Content>
