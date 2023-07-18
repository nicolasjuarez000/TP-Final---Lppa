<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logs.aspx.cs" Inherits="TP_Final___Lppa.Logs" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Logs</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }

        .container {
            margin: 0 auto;
            max-width: 800px;
            padding: 40px;
            background-color: #ffffff;
            border-radius: 4px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .container label {
            font-weight: bold;
            font-size: 18px;
        }

        .container .gridview {
            margin-top: 20px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <label for="Label1" class="label">Logs</label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" CssClass="gridview" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
