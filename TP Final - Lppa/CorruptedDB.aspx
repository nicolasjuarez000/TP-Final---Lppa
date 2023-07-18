<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorruptedDB.aspx.cs" Inherits="TP_Final___Lppa.CorruptedDB" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Corrupted Database</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }
        
        .container .gridview tr.selected {
            background-color: #007bff;
            color: #ffffff;
        }

        .container {
            margin: 0 auto;
            max-width: 800px;
            padding: 40px;
            background-color: #ffffff;
            border-radius: 4px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .container .gridview {
            margin-bottom: 20px;
            width: 100%;
            border-collapse: collapse;
        }

        .container .gridview th,
        .container .gridview td {
            padding: 8px;
            border: 1px solid #cccccc;
        }

        .container .gridview th {
            background-color: #f2f2f2;
            text-align: left;
        }

        .container .gridview tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .container .gridview tr:hover {
            background-color: #e6e6e6;
        }

        .container .restore-button {
            display: inline-block;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            background-color: #007bff;
            color: #ffffff;
            text-decoration: none;
            cursor: pointer;
            font-size: 16px;
        }

        .container .restore-button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" CssClass="gridview" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
            <br />
            <asp:Button ID="btnRestore" runat="server" Text="Restore" OnClick="btnRestore_Click" CssClass="restore-button" />

        </div>
    </form>
</body>
</html>
