<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchases.aspx.cs" Inherits="TP_Final___Lppa.Purchases" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Purchases</title>
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

        .container .filter-button {
            display: inline-block;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            background-color: #007bff;
            color: #ffffff;
            text-decoration: none;
            cursor: pointer;
            font-size: 16px;
            float: right;
        }

        .container .filter-button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="Label3" runat="server" Text="Ventas" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Font-Strikeout="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Filtrar por productos"></asp:Label>
            &nbsp
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Filtrar por buyer"></asp:Label>
            &nbsp
            <asp:DropDownList ID="dropBuyer" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropBuyer_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnSelectionChanged="Calendar1_SelectionChanged" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
            <br />
            <br />
            <asp:Button ID="btnDescarga" runat="server" Text="Descargar reporte" OnClick="btnDescarga_Click" />
            <asp:GridView ID="GridView1" runat="server" CssClass="gridview">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
