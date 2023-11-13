<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="elegirinmueble.aspx.cs" Inherits="ProyectoTravelNest.pages.elegirinmueble" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/stylesInmueble.css" rel="stylesheet" />
    <div class="container" style="margin-top: 6vh;">
        <h1 runat="server" id="h1_titulo">Agregar, modificar o eliminar</h1>
        <h5>Seleccione el inmueble.</h5>

        <!-- Cartas -->

        <div class="container-fluid mt-5">
            <div class="row" id="row" runat="server">
                <!-- Lista Inmuebles -->
            </div>
        </div>


    </div>
</asp:Content>
