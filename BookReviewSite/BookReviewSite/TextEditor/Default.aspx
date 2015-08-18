<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rich Text Editor Demo : John Bhatt</title>
    <script src="../tiny_mce/tiny_mce.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,spellchecker"
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 59px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <table style="height: 586px;  width: 80%">
       <tr>
           <td class="auto-style1">
               Post Title : 
           </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="250px"></asp:TextBox>
            </td>
       </tr>
       <tr>
           <td valign="top" class="auto-style1">
            Body :
           </td>
           <td>
               <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="327px" 
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
  
    </form>
</body>
</html>
