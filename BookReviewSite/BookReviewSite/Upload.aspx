<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="BookReviewSite.Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/Validation.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:FileUpload ID = "fuPhoto" runat = "server" />
<asp:Button ID = "btnUpload" runat = "server" Text = "Upload" onclick="btnUpload_Click" />
<asp:Label ID = "lblMessage" runat = "server"></asp:Label>
<table>
    <tr>
        <td><asp:TextBox ID = "txtTitle" runat = "server" Text = "Book's Title"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvTitleValidate" runat="server" 
                ControlToValidate="txtTitle" ErrorMessage="Book Title required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td><asp:DropDownList ID = "ddlGenre" runat = "server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td class="style1"><asp:TextBox ID = "txtPrice" runat = "server" Text = "Book's Price"></asp:TextBox>
            <asp:CustomValidator ID="cvPrice" runat="server" 
                ClientValidationFunction="ValidatePrice" ControlToValidate="txtPrice" 
                ErrorMessage="Not in correct format (&quot;0.00&quot;)" 
                ValidateEmptyText="True"></asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td><asp:Button ID = "btnSave" runat = "server" Text = "Save" onclick="btnSave_Click" /></td>
    </tr>
</table>
</asp:Content>
