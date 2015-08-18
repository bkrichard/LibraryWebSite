<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TextEditor.aspx.cs" Inherits="BookReviewSite.TextEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<title>Rich Text Editor Demo : John Bhatt</title>
    <script src="../tiny_mce/tiny_mce.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups"
        });
    </script>
 <table style="height: 586px;  width: 80%">
       <tr>
           <td class="auto-style1">
               Post Title : 
           </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="250px"></asp:TextBox>
            </td>
       </tr>
       <tr>
           <td valign="top" class="auto-style1">
            Body :
           </td>
           <td>
               <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Height="327px" 
                   Width="528px"></asp:TextBox>
               <br />
               <br />
           </td>
       </tr>
       <%--<tr>
           <td class="auto-style1">
               Tags :
           </td>
           <td>
               <asp:TextBox ID="TextBox3" runat="server" Height="22px" Width="267px"></asp:TextBox>
           </td>
       </tr>--%>
       <tr>
           <td colspan="2" align="left">
               <asp:Button ID="btnPost" runat="server" Text="Post" onclick="btnPost_Click"/>
           </td>
       </tr>

   </table>
</asp:Content>
