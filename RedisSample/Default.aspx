<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RedisSample._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
       
    </div>
    <div>
        Enter the key you want to retreive <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><t\></t> [Enter only keys : key1, key2, key3, key4"]
        <br /><asp:Button ID="Button1" runat="server" Text="Get" OnClick="Button1_Click" />
    </div>
    <br />
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
