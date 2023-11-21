<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TP_Final___Lppa.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cart</title>
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
            <asp:Label ID="Label4" runat="server" Text="Carrito" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Productos" Font-Bold="True" Font-Italic="False"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"/>
            <div style="text-align: right;">
            <asp:Label ID="Label2" runat="server" Text="Cantidad: " Visible="False"></asp:Label>
            <asp:Label ID="lblCantidad" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Importe total: " style="text-align: right;" Visible="False"></asp:Label>
            <asp:Label ID="lblImporteTotal" runat="server" Text="" Visible="False"></asp:Label>
            </div>
            <asp:GridView ID="GridView1" runat="server" CssClass="gridview"></asp:GridView>
        </div>
    </form>
</body>
</html>
