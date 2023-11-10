<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="favoritos.aspx.cs" Inherits="ProyectoTravelNest.pages.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
        <link href="../Content/Favoritos.css" rel="stylesheet" />
        <link href="../Content/style.css" rel="stylesheet" />
        <style>
            .add-more-button {
                position: fixed;
                top: 30%;
                right: 800px;
                transform: translateY(-10%);
            }
        </style>
    </head>
    <body>
        <div class="titulo">Favoritos</div>
        <div class="tarjetas-container" style="margin-top: 60px;">
            <!-- Aquí se mostrarán las tarjetas -->
        </div>

        <div id="lstfrmMantenimiento" runat="server" class="contenedor">
            <!-- Aquí va el contenido de los favoritos -->
        </div>

        <asp:Button ID="btnAddMore" runat="server" Text="Añadir más" CssClass="add-more-button" OnClick="btnAddMore_Click" />
    </body>
    </html>
</asp:Content>
