<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorruptedDB.aspx.cs" Inherits="TP_Final___Lppa.CorruptedDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" ></asp:GridView>
            <asp:Button ID="btnRestore" runat="server" Text="Restore" OnClick="btnRestore_Click" />
        </div>
    </form>
</body>
</html>
