<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BookReviewSite.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type = "text/javascript">
    function CheckMail() {
        alert('You're password has been sent to your email. Please check it to log in');
    }
    <table>

    <tr>
        <td class="style2">
            <asp:TextBox ID = "txtUserName" placeholder = "Username" runat = "server"></asp:TextBox>
            <asp:Label ID="lblNameValidate" runat="server"></asp:Label>
        </td>
    </tr>

    <tr>
        <td class="style2">
            <asp:TextBox ID = "txtFirstName" placeholder = "First Name" runat = "server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td class="style2">
            <asp:TextBox ID = "txtLastName" placeholder = "Last Name" runat = "server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td class="style2">
            <asp:TextBox ID = "txtEmail" placeholder = "E-mail Address" runat = "server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td class="style2">
            <asp:TextBox ID = "txtQuestion1" placeholder = "Enter your first question (Used in password recovery)" 
                runat = "server" CssClass="TextArea"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td class="style2">
            <asp:TextBox ID = "txtAnswer1" placeholder = "Enter the answer to your first question" 
                runat = "server" CssClass="TextArea"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td class="style2">
            <asp:TextBox ID = "txtQuestion2" placeholder = "Enter your second question" 
                runat = "server" CssClass="TextArea"></asp:TextBox>
        </td>
    </tr>

     <tr>
        <td class="style2">
            <asp:TextBox ID = "txtAnswer2" placeholder = "Enter the answer to your second question" 
                runat = "server" CssClass="TextArea"></asp:TextBox>
        </td>
    </tr>

     <tr>
        <td class="style2">
            <asp:TextBox ID = "txtQuestion3" placeholder = "Enter your third question" 
                runat = "server" CssClass="TextArea"></asp:TextBox>
        </td>
    </tr>

         <tr>
        <td class="style2">
            <asp:TextBox ID = "txtAnswer3" placeholder = "Enter the answer to your third question" 
                runat = "server" CssClass="TextArea"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Button ID = "btnRegister" Text = "Register" runat = "server" 
                onclick="btnRegister_Click" />
        </td>
    </tr>

</table>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="Stylesheets">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css"/>
    <style type="text/css">
        .style1
        {
            height: 32px;
            width: 205px;
        }
        .style2
        {
            width: 205px;
        }
    </style>
</asp:Content>

