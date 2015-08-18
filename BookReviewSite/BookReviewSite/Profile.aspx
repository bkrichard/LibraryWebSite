<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BookReviewSite.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 101px;
        }
    </style>
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

<div  id="profbod">
        <table>
        <tr>
            <td class="style1"><asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label></td>
            <td><asp:Label ID="lblDisplayFName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="style1"><asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label></td>
            <td><asp:Label ID="lblDisplayLName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="style1"><asp:Label ID="lblUName" runat="server" Text="User Name:"></asp:Label></td>
            <td><asp:Label ID="lblDisplayUName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="style1"><asp:Label ID="lblEMail" runat="server" Text="E-Mail:"></asp:Label></td>
            <td><asp:Label ID="lblDisplayEMail" runat="server"></asp:Label></td>
        </tr>

    </table>
</div>

</asp:Content>
