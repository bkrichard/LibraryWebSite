<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="BookReviewSite.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>

    <tr>
        <td>
            <asp:TextBox ID = "txtFirstName" placeholder = "First Name" runat = "server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>
            <asp:TextBox ID = "txtLastName" placeholder = "Last Name" runat = "server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>
            <asp:TextBox ID = "txtUserName" placeholder = "User Name" runat = "server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><asp:TextBox ID = "txtEmail" placeholder = "Email" runat = "server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID = "lblQuestion"
                runat = "server"></asp:Label>
        </td>
    </tr>

    <tr>
        <td>
            <asp:TextBox ID = "txtAnswer" placeholder = "Answer here" 
                runat = "server" CssClass="TextArea"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Button ID = "btnForgot" Text = "Forgot Password" runat = "server" 
                onclick="btnForgot_Click" />
            <asp:Button ID = "btnSend" Text = "Send Email" runat = "server" Visible = "false" 
                onclick="btnSend_Click" />
                <asp:Label ID ="lblStatus" runat ="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
