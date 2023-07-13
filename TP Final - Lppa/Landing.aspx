<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="TP_Final___Lppa.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            Bienvenido</p>
        <asp:Label ID="lblusername" runat="server" Text="Label"></asp:Label>
        <p>
            &nbsp;</p>
        <asp:Button ID="btnlogs" runat="server" OnClick="btnlogs_Click" Text="Logs" />&nbsp&nbsp&nbsp&nbsp<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
    </form>
</body>
</html>
