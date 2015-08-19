<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookReview.aspx.cs" Inherits="BookReviewSite.BookReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script language = "javascript" type ="text/javascript">
 function toggle()
{
            var eleMethod = document.getElementById("toggleTextEName");

            var textMethod = document.getElementById("displayTextEName");

            if (eleMethod.style.display == "block") {

                eleMethod.style.display = "none";

                textMethod.innerHTML = "[ Expand ]";

            }

            else {

                eleMethod.style.display = "block";

                textMethod.innerHTML = "[ Collapse ]";
            }
        }
</script>

<div>

 <span><a id="displayTextEName" href="javascript:toggle();">[ Expand ]</a></span>

</div>

<div id="toggleTextEName" style="display: none;">

<table>
<tr>
<td><asp:Label ID = "lblBody" runat = "server"></asp:Label></td>
</tr>
</table>

</div>
</asp:Content>
