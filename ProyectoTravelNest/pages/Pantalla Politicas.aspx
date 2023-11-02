<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pantalla Politicas.aspx.cs" Inherits="ProyectoTravelNest.pages.Pantalla_Politicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Nuestras políticas de los servicios</title>

        <link href="../Content/Politicas.css" rel="stylesheet" />
    </head>
    <body>
        <div class="titulo">Nuestras políticas de los servicios:</div>
        </body>

        
   
        <div id="rectangle-271">
            <!-- Contenido del rectángulo 271 -->
        </div>
        <div id="rectangle-269">
        <!-- Contenido del rectángulo 269 -->
    </div>
    <div id="rectangle-270">
        <!-- Contenido del rectángulo 270 -->
    </div>
      <div id="rectangle-272">
        <!-- Contenido del rectángulo 270 -->
    </div>

        <div id="mi-banco" class="boton" onclick="redireccionarAMiBanco()">
            Mi Banco.
        </div>

        <div id="depositos-seguridad" class="boton" onclick="redireccionarADepositosSeguridad()">
            Depósitos de seguridad.
        </div>

        <div id="evitar-fraude" class="boton" onclick="redireccionarAEvitarFraude()">
            Evitar el fraude, la estafa y el abuso.
        </div>

        <div id="seguridad" class="boton" onclick="redireccionarASeguridad()">
            Seguridad.
        </div>

        <div id="seguridad-anfitriones-huéspedes" class="boton" onclick="redireccionarASeguridadAnfitrionesHuespedes()">
            Seguridad de los anfitriones y huéspedes.
        </div>

        <div id="Contenido--reseñas" class="boton" onclick="redireccionarAContenidoReseñas()">
            Contenido y reseñas.
        </div>

        <div id="Contenido--reseñas2" class="boton" onclick="redireccionarAContenidoReseñas2()">
            Contenido restringido.
        </div>

        <div id="Contenido--reseñas3" class="boton" onclick="redireccionarAContenidoReseñas3()">
            Escribir reseñas relevantes e imparciales.
        </div>

        <div id="cancelaciones-reembolsos" class="boton" onclick="redireccionarACancelacionesReembolsos()">
            Cancelaciones y reembolsos.
        </div>

        <div id="cancelaciones-reembolsos2" class="boton" onclick="redireccionarACancelacionesReembolsos2()">
            Política de reembolso y asistencia.
        </div>

        <script>
            function redireccionarAMiBanco() {
                window.location.href = "PaginaMiBanco.aspx";
            }

            function redireccionarADepositosSeguridad() {
                window.location.href = "PaginaDepositosSeguridad.aspx";
            }

            function redireccionarAEvitarFraude() {
                window.location.href = "PaginaEvitarFraude.aspx";
            }

            function redireccionarASeguridad() {
                window.location.href = "PaginaSeguridad.aspx";
            }

            function redireccionarASeguridadAnfitrionesHuespedes() {
                window.location.href = "PaginaSeguridadAnfitrionesHuespedes.aspx";
            }

            function redireccionarAContenidoReseñas() {
                window.location.href = "PaginaContenidoReseñas.aspx";
            }

            function redireccionarAContenidoReseñas2() {
                window.location.href = "PaginaContenidoReseñas2.aspx";
            }

            function redireccionarAContenidoReseñas3() {
                window.location.href = "PaginaContenidoReseñas3.aspx";
            }

            function redireccionarACancelacionesReembolsos() {
                window.location.href = "PaginaCancelacionesReembolsos.aspx";
            }

            function redireccionarACancelacionesReembolsos2() {
                window.location.href = "PaginaCancelacionesReembolsos2.aspx";
            }
        </script>
    </body>
    </html>
</asp:Content>
