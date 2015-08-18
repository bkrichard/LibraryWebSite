<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReviewOverview.aspx.cs" Inherits="BookReviewSite.ReviewOverview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 109px;
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

<div id="profbod">
    <table>
        <tr>
            <td class="style1"><asp:Label ID="lblDate" runat="server" Text="Date Registered:"></asp:Label></td>
            <td><asp:Label ID="lblRegistered" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td class="style1"><asp:Label ID="lblTotalReviews" runat="server" Text="Reviews Posted:"></asp:Label></td>
            <td><asp:Label ID="lblPostsMade" runat="server"></asp:Label></td>
        </tr>
    </table>
</div>
</asp:Content>
