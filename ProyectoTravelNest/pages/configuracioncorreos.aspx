<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="configuracioncorreos.aspx.cs" Inherits="ProyectoTravelNest.pages.configuracioncorreos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <style>
    .btn:focus,
    .btn:active {
      outline: none !important;
      box-shadow: none !important;
    }
    .btn:active {
      background-color: #ffffff;
    }
    .btnAyuda{
        background-color: #7AB730 !important;
        color: #212121 !important;
        font-weight: 600;
        border: none !important;
        box-shadow: none !important;
    }
    .btnAyuda:hover{
        background-color: #83c336 !important;
    }
    .btnAyuda:active{
        background-color: #84ca31 !important;
    }
    .btnAyuda:focus {
        outline: none !important;
        box-shadow: none !important;
    }
    .celdaClick:hover{
        background-color: #ebebeb;
    }
    .celdaClick:active{
        background-color: #e4e4e4;
    }

    </style>
    <div class="container mt-4">
        <h1>Configuración de mensajes por correo</h1>
        <div class="row">
            <div class="col-md-8" id="divContenedorPrincipal" style="min-height: 500px;">
                <asp:UpdatePanel runat="server" ID="updPanel_Editar" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="divFormulario" runat="server" style="display: block;" visible="false">
                            <asp:Label runat="server" ID="lblTitulo" CssClass="card-title h5 mb-2" Text="Titulo"></asp:Label>
                            <asp:TextBox ID="txtContenido" runat="server" CssClass="form-control mb-2 full-width"
                                placeholder="Contenido" TextMode="MultiLine" Columns="100" MaxLength="200" Rows="15"
                                style="max-width: 100%"></asp:TextBox>
                            <asp:Button runat="server" ID="btnGuardarEdicion" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardarEdicion_Click"/>
                            <asp:Button runat="server" ID="btnCancelarEdicion" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelarEdicion_Click"/>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server" ID="updPanel_Correos" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="divTarjetas" runat="server" visible="true">
                            <!-- Tarjeta #1 -->
                            <div class="card mb-3" id="tarjeta1">
                                <div class="card-body">
                                    <asp:Label runat="server" ID="lblHuespedReservaTitulo" CssClass="card-title h5" Text="Al reservar un alojamiento (correo para huésped)"></asp:Label>
                                    <br /><br />
                                    <asp:Label runat="server" ID="lblHuespedReserva" CssClass="card-text mt-2" Text="Error: No se generó el mensaje"></asp:Label>
                                    <br /><br />
                                    <asp:Button ID="btnEditarHuespedReserva" runat="server" OnClick="btnEditarHuespedReserva_Click"
                                        CssClass="btn btn-warning mt-3" Text="Modificar" CommandName="Editar" AutoPostBack="true"></asp:Button>
                                </div>
                            </div>
                            <!-- Tarjeta #2 -->
                            <div class="card mb-3" id="tarjeta1">
                                <div class="card-body">
                                    <asp:Label runat="server" ID="lblAnfitrionReservaTitulo" CssClass="card-title h5" Text="Al reservar un alojamiento (correo para anfitrión)"></asp:Label>
                                    <br /><br />
                                    <asp:Label runat="server" ID="lblAnfitrionReserva" CssClass="card-text mt-2" Text="Error: No se generó el mensaje"></asp:Label>
                                    <br /><br />
                                    <asp:Button ID="btnEditarAnfitrionReserva" runat="server" OnClick="btnEditarAnfitrionReserva_Click"
                                        CssClass="btn btn-warning mt-3" Text="Modificar" CommandName="Editar" AutoPostBack="true"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- Tabla con parametros -->
            <div class="col-md-4 position-relative">
                <table class="table table-bordered" id="tablaParametros" style="background-color: white;">
                    <thead>
                        <tr>
                            <th scope="col">Detalle</th>
                            <th scope="col">Parámetro</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Nombre del Huésped</td>
                            <td style="cursor: pointer;" class="celdaClick">{HuespedNombre}</td>
                        </tr>
                        <tr>
                            <td>Apellidos del Huésped</td>
                            <td style="cursor: pointer;" class="celdaClick">{HuespedApellidos}</td>
                        </tr>
                        <tr>
                            <td>Correo del Huésped</td>
                            <td style="cursor: pointer;" class="celdaClick">{HuespedCorreo}</td>
                        </tr>
                        <tr>
                            <td>Teléfono del Huésped</td>
                            <td style="cursor: pointer;" class="celdaClick">{HuespedTelefono}</td>
                        </tr>
                        <tr>
                            <td>Nombre del Anfitrión</td>
                            <td style="cursor: pointer;" class="celdaClick">{AnfitrionNombre}</td>
                        </tr>
                        <tr>
                            <td>Apellidos del Anfitrión</td>
                            <td style="cursor: pointer;" class="celdaClick">{AnfitrionApellidos}</td>
                        </tr>
                        <tr>
                            <td>Teléfono del Anfitrión</td>
                            <td style="cursor: pointer;" class="celdaClick">{AnfitrionTelefono}</td>
                        </tr>
                        <tr>
                            <td>Correo del Anfitrión</td>
                            <td style="cursor: pointer;" class="celdaClick">{AnfitrionCorreo}</td>
                        </tr>
                        <tr>
                            <td>Nombre de la Reservación</td>
                            <td style="cursor: pointer;" class="celdaClick">{NombreReservacion}</td>
                        </tr>
                        <tr>
                            <td>Precio total de la reservación</td>
                            <td style="cursor: pointer;" class="celdaClick">{ReservaPrecioTotal}</td>
                        </tr>
                        <tr>
                            <td>Fecha inicio reservación</td>
                            <td style="cursor: pointer;" class="celdaClick">{ReservaInicio}</td>
                        </tr>
                        <tr>
                            <td>Fecha fin reservación</td>
                            <td style="cursor: pointer;" class="celdaClick">{ReservaFin}</td>
                        </tr>
                    </tbody>
                </table>
                <button type="button" class="btn rounded-circle position-absolute btnAyuda" style="top: 0; right: 0; margin-top: -0.5rem; margin-right: -0.5rem;" data-toggle="modal" data-target="#ejemploParametros">
                    ?
                </button>
                <!-- Modal -->
                <div class="modal fade" id="ejemploParametros" tabindex="-1" role="dialog" aria-labelledby="ejemploParametrosLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="ejemploParametrosLabel">Ejemplo de mensaje con parámetros</h5>
                            </div>
                            <div class="modal-body" style="white-space: pre-wrap;">
Estimado/a <strong style="color: #1fc441">{HuespedNombre} {HuespedApellidos}</strong>,

Le agradecemos por elegir nuestro servicio TravelNest para su reserva. Estamos encantados de confirmar que su reserva, <strong style="color: #1fc441">{NombreReservacion}</strong>, está programada desde el <strong style="color: #1fc441">{ReservaInicio}</strong> hasta el <strong style="color: #1fc441">{ReservaFin}</strong>.

El monto total a pagar por su reserva es <strong style="color: #1fc441">{ReservaPrecioTotal}</strong>. Nuestra meta es brindarle la mejor experiencia durante su alojamiento.

Si requiere más información o asistencia adicional, puede contactar al anfitrión al siguiente número: <strong style="color: #1fc441">{AnfitrionTelefono}</strong>.

Atentamente,
<strong style="color: #1fc441">{AnfitrionNombre} {AnfitrionApellidos}</strong>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Entendido</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var tabla = document.getElementById('tablaParametros');
            function eliminarMensajeExistente() {
                var mensajeExistente = document.getElementById('mensajeCopiado');
                var txtContenido = document.getElementById('txtContenido');
                var parametros = document.querySelectorAll('#tablaParametros .celdaClick');
                if (mensajeExistente) {
                    mensajeExistente.parentNode.removeChild(mensajeExistente);
                }
            }

            tabla.addEventListener('click', function (e) {
                if (e.target && e.target.nodeName === 'TD' && e.target.cellIndex === 1 && e.target.parentNode.rowIndex !== 0) {
                    eliminarMensajeExistente();

                    var aux = document.createElement("input");
                    aux.setAttribute("value", e.target.textContent);
                    document.body.appendChild(aux);
                    aux.select();
                    document.execCommand("copy");
                    document.body.removeChild(aux);

                    var mensaje = document.createElement('div');
                    mensaje.setAttribute('id', 'mensajeCopiado');
                    mensaje.textContent = 'Copiado!';
                    mensaje.style.position = 'absolute';
                    mensaje.style.left = (e.clientX + window.scrollX) + 'px';
                    mensaje.style.top = (e.clientY + window.scrollY) + 'px';
                    mensaje.style.backgroundColor = '#84ca31';
                    mensaje.style.color = 'white';
                    mensaje.style.padding = '10px';
                    mensaje.style.borderRadius = '5px';
                    mensaje.style.zIndex = '1000';
                    mensaje.style.transform = 'translate(-50%, -100%)';
                    document.body.appendChild(mensaje);
                    setTimeout(function () {
                        eliminarMensajeExistente();
                    }, 2000);
                }
            });
            txtContenido.addEventListener('input', function () {
                var contenido = txtContenido.value;
                var palabras = contenido.split(/\s+/);

                txtContenido.value = contenido;

                palabras.forEach(function (palabra) {
                    parametros.forEach(function (parametro) {
                        var textoParametro = parametro.innerText;
                        if (palabra === textoParametro) {
                            contenido = contenido.replace(new RegExp("\\b" + palabra + "\\b", "g"), '<span style="color: #9afeae; font-weight: bold;">' + palabra + '</span>');
                        }
                    });
                });

                txtContenido.value = contenido;
            });
        });
    </script>
</asp:Content>