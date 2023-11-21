<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="TP_Final___Lppa.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }

        .container {
            margin: 0 auto;
            max-width: 400px;
            padding: 40px;
            background-color: #ffffff;
            border-radius: 4px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .container p {
            text-align: center;
            margin-bottom: 20px;
            color: #333333;
            font-size: 20px;
        }

        .container label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .container .button {
            display: inline-block;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            background-color: #007bff;
            color: #ffffff;
            text-decoration: none;
            cursor: pointer;
            margin-top: 10px;
            font-size: 16px;
        }

        .container .button + .button {
            margin-left: 10px;
        }

        .container .button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <p class="welcome-text">Bienvenido</p>
            <asp:Label ID="lblusername" runat="server" Text="Label" CssClass="username-label"></asp:Label>
            <p>&nbsp;</p>
            <asp:Button ID="btnlogs" runat="server" OnClick="btnlogs_Click" Text="Logs" CssClass="button" />
            <asp:Button ID="btnData" runat="server" Text="Purchases" CssClass="button" OnClick="btnData_Click" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" CssClass="button" />
            <asp:Button ID="btnCreateBackup" runat="server" Text="Create Backup" CssClass="button" OnClick="btnCreateBackup_Click" />
            <asp:Button ID="btnRestore" runat="server" OnClick="btnRestore_Click" Text="Restore DB"  CssClass="button"/>
            <asp:Button ID="btnCart" runat="server" Text="Cart" CssClass="button" OnClick="btnCart_Click" />
        </div>
    </form>
</body>
</html>
