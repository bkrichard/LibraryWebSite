<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="BookReviewSite.Library" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type = "text/javascript">
    function SetSource(SourceID) {
        var hidSourceID =
        document.getElementById("<%=hidSourceID.ClientID%>");
        hidSourceID.value = SourceID;
    }

    function BookFound() {

        alert("This book is already in your list");

    }
</script>
    <asp:DropDownList ID = "ddlGenre" runat = "server" AutoPostBack="True"></asp:DropDownList>
    <asp:Repeater id="rptBooks" runat="server">

          <HeaderTemplate>
             <table border="0" width = "50%">
          </HeaderTemplate>

          <ItemTemplate>
             <tr>
                <td>
                    <asp:Image ID = "imgbookCover" runat = "server" Height = "120" Width = "100" ImageUrl = '<%#DataBinder.Eval(Container.DataItem, "PhotoName")%>' />
                </td>
                <td> <%#DataBinder.Eval(Container.DataItem, "Title")%> </td>
                <td> <%#DataBinder.Eval(Container.DataItem, "Price")%> </td>
                <td> <%#DataBinder.Eval(Container.DataItem, "Genre")%> </td>
                <td><asp:ImageButton ID="btnAdd" ImageUrl="~/Images/add_icon.png"
                runat="server" CommandName="add" OnClientClick = "SetSource(this.id)"
                 CommandArgument = '<%#DataBinder.Eval(Container.DataItem, "ID")%>'/>
                </td>
                <td><asp:ImageButton ID="btnEdit" ImageUrl="~/Images/edit_icon.gif"
                runat="server" CommandName="edit" OnClientClick = "SetSource(this.id)"
                  CommandArgument = '<%#DataBinder.Eval(Container.DataItem, "ID")%>'/>
                </td>
             </tr>
             <tr>
                <td><asp:LinkButton ID = "lnkReview" runat = "server" Text = "Write Review" CommandName = "review" OnClientClick = "SetSource(this.id)" CommandArgument = '<%#DataBinder.Eval(Container.DataItem, "ID")%>'></asp:LinkButton></td>
                <td><asp:LinkButton ID = "lnkReViewer" runat = "server" Text = "Read Reviews" CommandName = "readreview" OnClientClick = "SetSource(this.id)" CommandArgument = '<%#DataBinder.Eval(Container.DataItem, "ID")%>'></asp:LinkButton></td>
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
       <asp:HiddenField ID="hidSourceID" runat="server" />
</asp:Content>
