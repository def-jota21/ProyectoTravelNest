<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pantallapoliticas.aspx.cs" Inherits="ProyectoTravelNest.pages.Pantalla_Politicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html lang="es">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">


        <link href="../Content/Politicas.css" rel="stylesheet" />
        <script>
            function mostrarFormulario() {
                var formulario = document.getElementById('formulario-insertar');
                formulario.style.display = 'block'; // Mostrar el formulario
            }

            function insertar() {
                var titulo = document.getElementById('titulo').value;
                var contenido = document.getElementById('contenido').value;
                var textoAdicional = document.getElementById('texto-adicional').value;

                // Aquí deberías tener una lógica para añadir una nueva tarjeta con estos valores.
                // Por simplicidad, se muestra una alerta con la información.
                alert('Insertar: ' + titulo + ', ' + contenido + ', ' + textoAdicional);

                // Limpiar campos
                document.getElementById('titulo').value = '';
                document.getElementById('contenido').value = '';
                document.getElementById('texto-adicional').value = '';

                // Ocultar formulario
                document.getElementById('formulario-insertar').style.display = 'none';
            }

            function modificar(id) {
                // Similar a insertar, pero obtiene y modifica la tarjeta existente.
            }

            function eliminar(id) {
                // Elimina la tarjeta con el id dado.
            }
        </script>
    </head>
    <body>
        <div class="container mt-4">
            <h1>Políticas de TravelNest</h1>
            <button class="btn btn-primary" onclick="mostrarFormulario()">Insertar Nueva Política</button>
            <div id="formulario-insertar" style="display: none;">
                <input type="text" id="titulo" class="form-control mb-2" placeholder="Título">
                <textarea id="contenido" class="form-control mb-2" placeholder="Contenido"></textarea>
                <input type="text" id="texto-adicional" class="form-control mb-2" placeholder="Texto Adicional">
                <button class="btn btn-success" onclick="insertar()">Confirmar Inserción</button>
            </div>

            <!-- Aquí irían las tarjetas existentes -->
            <div id="tarjetas">
                <!-- Ejemplo de una tarjeta -->
                <div class="card mb-3" id="tarjeta1">
                    <div class="card-body">
                        <h5 class="card-title">Título de Ejemplo</h5>
                        <p class="card-text">Contenido de ejemplo.</p>
                        <p class="card-text">Texto adicional de ejemplo.</p>
                        <button class="btn btn-warning mb-1" onclick="modificar('tarjeta1')">Modificar</button>
                        <button class="btn btn-danger" onclick="eliminar('tarjeta1')">Eliminar</button>
                    </div>
                </div>
                <div class="card mb-3" id="tarjeta2">
                    <div class="row no-gutters">
                        <!-- Columna a la izquierda con campos de texto -->
                        <div class="col-md-8 border-right">
                            <div class="card-body">
                                <div class="form-group">
                                    <label for="titulo-tarjeta2">Título</label>
                                    <input type="text" class="form-control" id="titulo-tarjeta2" placeholder="Título" value="Título de Ejemplo">
                                </div>
                                <div class="form-group">
                                    <label for="contenido-tarjeta2">Contenido</label>
                                    <textarea class="form-control" id="contenido-tarjeta2" placeholder="Contenido">Contenido de ejemplo.</textarea>
                                </div>
                                <div class="form-group">
                                    <label for="adicional-tarjeta2">Texto Adicional</label>
                                    <textarea class="form-control" id="adicional-tarjeta2" placeholder="Texto Adicional">Texto adicional de ejemplo.</textarea>
                                </div>
                            </div>
                        </div>
                        <!-- Columna a la derecha con botones -->
                        <div class="col-md-4">
                            <div class="card-body d-flex flex-column justify-content-around">
                                <button class="btn btn-warning ml-3 mb-2" onclick="modificar('tarjeta2')">Modificar</button>
                                <button class="btn btn-danger ml-3 mb-2" onclick="eliminar('tarjeta2')">Eliminar</button>
                                <button class="btn btn-secondary ml-3" onclick="cancelar('tarjeta2')">Cancelar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </body>
    </html>


</asp:Content>
