<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="BookReviewSite.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />

<script type = "text/javascript">
    function WrongCurrent() {
        alert('Your current password is not correct');
    }

    function DoesNotMatch() {
        alert('Your new passwords do not match');
    }
</script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div id="leftside">
    <ul class="profile">
        <li><asp:LinkButton ID = "lnkProfile" runat = "server" PostBackUrl ="Profile.aspx" 
        Text = "Profile"></asp:LinkButton></li>
        <li><asp:LinkButton ID = "lnkChangePass" runat = "server" PostBackUrl ="ChangePassword.aspx" 
        Text = "Change Password"></asp:LinkButton></li>
        <li><asp:LinkButton ID = "lnkRevCount" runat = "server" PostBackUrl ="ReviewOverview.aspx" 
        Text = "User Statistics"></asp:LinkButton></li>
    </ul>
</div>
<div id="profbod">
<table>
    <tr>
        <td><asp:Label ID="lblCurrentPass" runat="server" Text="Current Password"></asp:Label></td>
        <td><asp:TextBox ID="txtCurrentPass" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblNewPass" runat="server" Text="New Password"></asp:Label></td>
        <td><asp:TextBox ID="txtNewPass" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblConfirmPass" runat="server" Text="Confirm Password"></asp:Label></td>
        <td><asp:TextBox ID="txtConfirmPass" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Button ID="btnChangePass" runat="server" Text="Confirm Change" onclick="btnChangePass_Click"/></td>
    </tr>
</table>
</div>
</asp:Content>
