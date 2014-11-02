<%@ Page Title="Articles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="ArticlesSystem.Authorized.Articles" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

    </div>
    <asp:gridview id="CategoriesGridView" 
                  autogeneratecolumns="False"
                  allowpaging="True" PageSize="5" AllowSorting="true" OnSorting="Sort"       
                  runat="server" DataKeyNames="Id" OnRowEditing="Edit" OnRowDeleting="Delete"                  
                  OnPageIndexChanging="PageIndexChanged" ItemType="ArticlesSystem.Models.Article"
                  
                  GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label style="font-size:20px" CssClass="LabelHeader"  ID="Title" runat="server" Text="<%#Item.Title %>">

                    </asp:Label>
                    <p>Category: <%# Item.Category.Name==null ? "" : Item.Category.Name %></p>
                    <p>
                    <%# Item.Content.Length>=298 ? Item.Content.Substring(0,297)+"..." : Item.Content %></p>
                    <p>Likes count: <%# Item.Like.Value %></p>
                    <div style="margin-bottom:50px">
                        <i>by <%# Item.Author.UserName %></i>
                        <i>created on: <%# Item.DateCreated %></i>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField  buttontype="Link"
                              commandname="Edit"                               
                              text="Edit" ItemStyle-CssClass="btn btn-info pull-left">
            </asp:ButtonField>
            <asp:ButtonField  buttontype="Link"
                              commandname="Delete" 
                              text="Delete" ItemStyle-CssClass="btn btn-danger pull-left">
            </asp:ButtonField>

        </Columns>
    </asp:gridview>
    <a id="buttonhowinsertpanel" class="btn btn-info pull-right" onclick="(function (ev) {
       $('#panelInsertArticle').show();
       $('#buttonshowinsertpanel').hide();
       }())">insert new article</a>

    <div id="panelInsertArticle" class="form-horizontal">
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ArticleTitle" CssClass="col-md-2 control-label">Title</asp:Label>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="ArticleTitle" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ArticleTitle"
                                            CssClass="text-danger" ErrorMessage="The title field is required." />
            </div>
        </div>

        <div class="form-group">

            <asp:Label runat="server" AssociatedControlID="DropDownListxCategories" CssClass="col-md-2 control-label">Category</asp:Label>
            <div class="col-md-10">

                <asp:DropDownList ID="DropDownListxCategories" runat="server" CssClass="form-control"
                                  DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListxCategories"
                                            CssClass="text-danger" ErrorMessage="The category field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Content" CssClass="col-md-2 control-label">Content</asp:Label>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="Content" TextMode="MultiLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Content"
                                            CssClass="text-danger" ErrorMessage="The content field is required." />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateArticleClick" Text="Insert" CssClass="btn btn-success" />
                <a class="btn btn-danger" onclick="(function (ev) {
                   $('#panelInsertArticle').hide();
                   $('#buttonhowinsertpanel').show();
                   }())">Cancel</a>

            </div>
        </div>
    </div>
    <script>
        $('#panelInsertArticle').hide();
        $('#buttonshowinsertpanel').show();
    </script>
</asp:Content>
