<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecepcionMensajes.aspx.cs" Inherits="ProyectoTravelNest.pages.RecepcionMensajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Chat de Mensajes</title>

    <link href="../Content/RecepcionMensajes.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <h2>Seleccionar Categoría</h2>
                <div class="btn-group" role="group">
                    <button class="btn btn-secondary category-button" id="category-messages">Bandeja de Mensajes</button>
                    <%--<button class="btn btn-secondary category-button" id="category-reports">Denuncias</button>--%>
                </div>
                <div class="form-group mt-3">
                    <button class="btn btn-secondary user-button" id="user1">Usuario 1</button>
                </div>
                <div class="form-group">
                    <button class="btn btn-secondary user-button" id="user2">Usuario 2</button>
                </div>
            </div>
            <div class="col-md-8">
                <h2 id="chat-title">Mensajes</h2>
                <div class="chat-section" id="chat-box">
                </div>Enviar Mensaje    <div class="input-group mt-3">
                    <input type="text" id="message-input" class="form-control" placeholder="Escribe un mensaje...">
                    <div class="input-group-append">
                        <button id="send-button" class="btn btn-success">Enviar Mensaje</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {
            // Manejar el clic en el botón de categoría "Mensajes"
            $("#category-messages").click(function () {
                $("#chat-title").text("Mensajes");
                $("#category-messages").addClass("btn-success");
                $("#category-reports").removeClass("btn-success");
                $("#send-button").text("Enviar Mensaje");
            });

            // Manejar el clic en el botón de categoría "Denuncias"
            $("#category-reports").click(function () {
                $("#chat-title").text("Denuncias");
                $("#category-reports").addClass("btn-success");
                $("#category-messages").removeClass("btn-success");
                $("#send-button").text("Enviar Denuncia");
            });

            // Manejar el clic en el botón de usuario 1
            $("#user1").click(function () {
                $(".user-button").removeClass("btn-success");
                $("#user1").addClass("btn-success");
            });

            // Manejar el clic en el botón de usuario 2
            $("#user2").click(function () {
                $(".user-button").removeClass("btn-success");
                $("#user2").addClass("btn-success");
            });

            // Manejar el clic en el botón de enviar
            $("#send-button").click(function () {
                // Obtener el texto del mensaje
                const message = $("#message-input").val();
                const user = $(".user-button.btn-success").text(); // Obtener el usuario seleccionado

                // Obtener el título de la categoría
                const categoryTitle = $("#chat-title").text();

                // Crear un nuevo mensaje en el chat
                const newMessage = `<div class="message"><strong>${user} (${categoryTitle}):</strong> ${message}</div>`;
                $("#chat-box").append(newMessage);

                // Borrar el contenido del campo de entrada
                $("#message-input").val("");
            });
        });
    </script>
</body>
</html>
</asp:Content>
