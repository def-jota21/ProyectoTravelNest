<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="ProyectoTravelNest.pages.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="../Content/Favoritos.css" rel="stylesheet" />
</head>
<body>
    <div class="titulo">Favoritos</div>
    
        <asp:Button ID="btnAddMore" runat="server" Text="Añadir más" CssClass="add-more-button" OnClick="btnAddMore_Click" />
    
</body>
</html>
</asp:Content>
