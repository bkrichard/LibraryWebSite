<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReViewer.aspx.cs" Inherits="BookReviewSite.ReViewer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function ExpandableDisplay(id) {
            // 'd' was concatenated to get id of description text
            var descelem = document.getElementById('d' + id);
            if (descelem) {
                if (descelem.style.display != 'block') {
                    descelem.style.display = 'block';
                    descelem.style.visibility = 'visible';
                }
                else {
                    descelem.style.display = 'none';
                    descelem.style.visibility = 'hidden';
                }
            }
        }
    </script>

    <style type="text/css">
        div.user { font-size: larger; font-weight: bold; cursor: pointer; background-color: #cccccc; font-family: sans-serif; }
        div.description { display: none; visibility: hidden; font-family: sans-serif; }
    </style>

<table>
    <tr>
        <td>
        <asp:Image ID = "imgbookCover"  runat = "server" Height = "120" Width = "100"/>
        </td>
    </tr>
</table>
<asp:Repeater id="rptReviews" runat="server">

          <HeaderTemplate>
             <table border="0" width = "50%">
          </HeaderTemplate>

          <ItemTemplate>
             <tr>
                <td>
                <%#DataBinder.Eval(Container.DataItem, "User")%>:
                 <div id='h<%# DataBinder.Eval(Container, "ItemIndex") %>' class="user"
                    onclick='ExpandableDisplay(<%# DataBinder.Eval(Container, "ItemIndex") %>);'>
                    <b><%#DataBinder.Eval(Container.DataItem, "Title")%></b>
                </div>
                </td>
             </tr>
             <tr>
                <td>
                <div id='d<%# DataBinder.Eval(Container, "ItemIndex") %>' class="description">
                    <b><%#DataBinder.Eval(Container.DataItem, "BookReview")%></b>
                </div>
                </td>
             </tr>
           
          </ItemTemplate>

          <SeparatorTemplate>
          <tr>
            <td colspan="6"><hr /></td>
          </tr>
          </SeparatorTemplate>

          <FooterTemplate>
             </table>
          </FooterTemplate>

       </asp:Repeater>
</asp:Content>
