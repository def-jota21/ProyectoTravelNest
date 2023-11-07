<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sesionyseguridad.aspx.cs" Inherits="ProyectoTravelNest.pages.sesionyseguridad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <div class="container mt-5">
            <div class="row">
                
                    <div class="col">
                        <h2>Inicio Sesión y Seguridad</h2>
                        <label for="exampleFormControlInput1" class="form-label mt-4">Contraseña</label>
                        <a href="#" class="stretched-link text-danger mx-5" style="position: relative;">Modificar</a>
                        <br>
                        <label for="exampleFormControlInput1" class="form-label mt-2">Ultima Actualizacion hace 23 dias</label>
                        
                        <h4 class="mt-4">Historial del Dispositivo</h4>
                        <label for="exampleFormControlInput1" class="form-label mt-2">Nombre del Dispositivo</label>
                        <h4 class="mt-4">Cuenta</h4>
                        <label for="exampleFormControlInput1" class="form-label mt-4">Desactivar la cuenta</label>
                        <a href="#" class="stretched-link text-danger mx-5" style="position: relative;">Desactivar</a>
                    </div>

            </div>  
        </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
