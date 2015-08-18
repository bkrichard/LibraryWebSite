<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookReviewSite.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>

<tr>
    <td><asp:TextBox ID="txtUserName" runat = "server" placeholder = "Username">BRichard</asp:TextBox></td>
</tr>

<tr>
    <td><asp:TextBox ID="txtPassword" runat = "server" 
            Height="22px">brichard</asp:TextBox></td>
</tr>

<tr>
    <td><asp:Button ID="btnLogin" runat = "server" Text = "Login"
            onclick="btnLogin_Click"></asp:Button>
            <asp:Button ID="btnRegister"
            runat = "server" Text = "Register"
            onclick="btnRegister_Click"></asp:Button></td>
</tr>

<tr>
    <td>&nbsp;</td>
</tr>

<tr>
    <td><asp:Button ID = "btnForgot" Text = "Forgot Password" runat = "server" 
        onclick="btnForgot_Click"/><asp:Label ID = "lblStatus" runat = "server"></asp:Label></td>
</tr>

</table>
</asp:Content>
