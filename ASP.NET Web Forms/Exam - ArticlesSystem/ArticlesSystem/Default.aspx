<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArticlesSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>News</h1>
    <h2>Most Popular Articles</h2>

    <asp:ListView runat="server" ID="ListViewCategories" ItemType="ArticlesSystem.Models.Article" SelectMethod="ListViewArticles_GetData">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <li style="margin-top:50px">
                <asp:HyperLink NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.Id) %>' runat="server" 
                               Text='<%# Item.Title %>' />
                <small><%# Item.Category.Name %></small>
                <p>
                <%# Item.Content %>
                </p>
                <p>Likes: <%# Item.Like.Value %></p>
                <div>
                    <i>by <%#Item.Author.UserName %></i>
                    <i>created on: <%# Item.DateCreated %></i>
                </div>
            </li>
        </ItemTemplate>
    </asp:ListView>

    <h2 style="margin-top:50px">All categories</h2>
    <asp:ListView runat="server" ID="CategoriesListView" ItemType="ArticlesSystem.Models.Category"
                  SelectMethod="ListViewCategories_GetData">

        <ItemTemplate>
            <h3 ><%#Item.Name %></h3>
            <div class="col-md-6">
                <asp:ListView runat="server" ID="ArticlesListView" ItemType="ArticlesSystem.Models.Article" 
                              DataSource="<%# Item.Articles.OrderByDescending(x=>x.DateCreated).Take(3) %>">
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.Id) %>' runat="server" 
                                           Text='<%# string.Format(@"<b>{0}</b> by <i>{1}</i>", Item.Title, Item.Author.UserName) %>' />
                        </li>
                    </ItemTemplate>
                    <EditItemTemplate>
                        No Articles
                    </EditItemTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
