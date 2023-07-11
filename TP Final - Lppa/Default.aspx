<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Final___Lppa._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    Usuario&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <br />
    Contraseña&nbsp;
    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign in" />&nbsp&nbsp&nbsp&nbsp
    <asp:Button ID="Button2" runat="server" Text="Logs" OnClick="Button2_Click" />
&nbsp;

</asp:Content>
