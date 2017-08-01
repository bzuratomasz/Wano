<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WanoControlCenter.Web.WanoService.RequestRegisterCard>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ViewWano
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>ViewWano</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            <%: Html.DisplayNameFor(model => model.CardId) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.Deleted) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.EndTime) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.Password) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.Permissions) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.StartTime) %>
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.CardId) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Deleted) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.EndTime) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Password) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Permissions) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.StartTime) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
            <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
