<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_Code.Controls.WidgetContainer" %>
<div class="panel <%= Widget.Name.Replace(" ", String.Empty).ToLowerInvariant() %>" id="widget<%= Widget.WidgetId %>">
    <% if (!this.Widget.ShowTitle) { %> <%= AdminLinks %> <% } %>
    <% if (this.Widget.ShowTitle)
       { %>
    <div class="panel-heading">
        <%= Widget.Title%>
        <span class="pull-right"><%= AdminLinks %></span>
    </div>
    <% } %>
    <div class="panel-body">
        <asp:PlaceHolder ID="phWidgetBody" runat="server"></asp:PlaceHolder>
    </div>
</div>
