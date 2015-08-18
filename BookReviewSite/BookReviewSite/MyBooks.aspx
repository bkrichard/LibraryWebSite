<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation = "true" AutoEventWireup="true" CodeBehind="MyBooks.aspx.cs" Inherits="BookReviewSite.MyBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--<script language = "javascript" type = "text/javascript">
    function deleteit(ptr) {
        //alert(ptr.parentNode.parentNode);
        var row = ptr.parentNode.parentNode;
        row.outerHTML = "";
     }
</script>--%>
<asp:Repeater id="rptBooks" runat="server">

          <HeaderTemplate>
             <table border="0" width = "50%">
          </HeaderTemplate>

          <ItemTemplate>
             <tr>
                <td>
                    <asp:Image ID = "imgbookCover"  runat = "server" Height = "120" Width = "100" ImageUrl = '<%#DataBinder.Eval(Container.DataItem, "PhotoName")%>' />
                </td>
                <td> <%#DataBinder.Eval(Container.DataItem, "Title")%> </td>
                <td> <%#DataBinder.Eval(Container.DataItem, "Price")%> </td>
                <td> <%#DataBinder.Eval(Container.DataItem, "Genre")%> </td>
                <td><asp:ImageButton ID="btnEdit" ImageUrl="~/Images/edit_icon.gif" 
                runat="server" CommandName="edit"  CommandArgument = '<%#DataBinder.Eval(Container.DataItem, "ID")%>'/>
                </td>
                <td><asp:ImageButton ID="btnDelete" ImageUrl="~/Images/delete_icon.gif" 
                runat="server" CommandName="delete"  CommandArgument = '<%#DataBinder.Eval(Container.DataItem, "ID")%>'/>
                </td>
                <tr>
                <td><asp:LinkButton ID = "lnkReview" runat = "server" Text = "Write Review" CommandName = "review" OnClientClick = "SetSource(this.id)" CommandArgument = '<%#DataBinder.Eval(Container.DataItem, "ID")%>'></asp:LinkButton></td>
                 <td><asp:LinkButton ID = "lnkReViewer" runat = "server" Text = "Read Review" CommandName = "readreview" OnClientClick = "SetSource(this.id)" CommandArgument = '<%#DataBinder.Eval(Container.DataItem, "ID")%>'></asp:LinkButton></td>
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
