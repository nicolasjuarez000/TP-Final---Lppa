<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Final___Lppa._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .container {
            margin: 0 auto;
            max-width: 400px;
            padding: 40px;
            background-color: #ffffff;
            border-radius: 4px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        
        .container h2 {
            text-align: center;
            margin-bottom: 30px;
            color: #333333;
        }
        
        .form-group {
            margin-bottom: 20px;
        }
        
        .form-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }
        
        .form-group input[type="text"],
        .form-group input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #cccccc;
            border-radius: 4px;
        }
        
        .form-group .error-message {
            color: red;
            margin-top: 5px;
        }
        
        .form-group .success-message {
            color: green;
            margin-top: 5px;
        }
        
        .form-group .button {
            width: 100%;
            padding: 10px;
            border: none;
            border-radius: 4px;
            background-color: #007bff;
            color: #ffffff;
            cursor: pointer;
        }
        
        .form-group .button:hover {
            background-color: #0056b3;
        }
    </style>
    <div class="container">
        <h2>Login</h2>
        <div class="form-group">
            <label for="TextBox2">Usuario</label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TextBox3">Contraseña</label>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblloginerror" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign in" CssClass="button" />
        </div>
    </div>
</asp:Content>
