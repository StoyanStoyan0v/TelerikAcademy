<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleDetails.aspx.cs" Inherits="ArticlesSystem.ArticleDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="FormViewArticlekDetails" 
                  ItemType="ArticlesSystem.Models.Article" SelectMethod="FormViewArticleDetails_GetItem">

        <ItemTemplate>
            <table cellspacing="0" style="border-collapse:collapse;">
                <tbody>
                    <tr>
                        <td colspan="2">

                            <div>
                                <div class="like-control col-md-1">
                                    <div>Likes</div>
                                    <div>
                                        <asp:LinkButton runat="server" ID="UpVote" CssClass="btn btn-default glyphicon glyphicon-chevron-up"  OnClick="Up_Click" />
                                        <span class="like-value"><%#Item.Like.Value %></span>
                                        <asp:LinkButton runat="server" ID="DownVote" CssClass="btn btn-default glyphicon glyphicon-chevron-down" OnClick="Down_Click" />
                                    </div>
                                </div>
                            </div>
                            <h2>
                                <%# Item.Title %> <small>Category: <%#Item.Category.Name %></small>
                            </h2>
                            <p><%#Item.Content %></p>
                            <p>
                                <span>Author: <%#Item.Author.UserName %></span>
                                <span class="pull-right"><%# Item.DateCreated %></span>
                            </p>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
