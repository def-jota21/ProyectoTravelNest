<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="paneladministracionhuesped.aspx.cs" Inherits="ProyectoTravelNest.pages.paneladministracionhuesped" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">


    <style>
        .notification {
            color: white;
            text-decoration: none;
            padding: 15px 26px;
            position: relative;
            display: inline-block;
            border-radius: 4px;
        }

            .notification .badgeCard {
                position: absolute;
                top: -10px;
                right: -10px;
                padding: 5px 10px;
                border-radius: 70%;
                background: red;
                color: white;
            }
    </style>
    <div class="container-fluid bg-registration py-5" style="margin: 90px 0;">
        <div class="container py-5">
            <div class="row align-items-center">
            </div>
        </div>
    </div>

    <div class="container mt-5">
        <div class="row">
            <div class="col-12">
                <div class="card-deck">
                    <div class="card">
                        <a href="datospersonales.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Datos Personales</h5>
                                <p class="h6 mt-4">Proporciona tus datos personales y como podemos contactarte.</p>
                            </span>

                        </a>
                    </div>


                    <div class="card">
                        <a href="sesionyseguridad.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Inicio de sesion y seguridad</h5>
                                <p class="h6 mt-4">Configura la forma que ingresas.</p>
                            </span>
                            <span class="badgeCard">1</span>
                        </a>
                    </div>
                    <div class="card">
                        <a href="centrodeayuda.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Centro de Ayuda</h5>
                                <p class="h6 mt-4">Te ayudamos en lo que necesites</p>
                            </span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <!-- [Cartas anfitrion] -->
        <div class="row mt-4">
            <div class="col-12">
                <div class="card-deck">
                    <!-- Reglas -->
                    <div class="card">
                        <asp:LinkButton runat="server" ID="lbtnReglas" style="text-decoration: none" OnClick="lbtnReglas_Click" CssClass="notification">
                            <span>
                                <h5 class="h5 mt-2">Reglas</h5>
                                <p class="h6 mt-4">Establece reglas personalizadas para la gestión eficiente de tus alojamientos.</p>
                            </span>
                        </asp:LinkButton>
                    </div>
                    <!-- Promociones -->
                    <div class="card">
                        <asp:LinkButton runat="server" ID="lbtnPromociones" style="text-decoration: none" OnClick="lbtnPromociones_Click" CssClass="notification">
                            <span>
                                <h5 class="h5 mt-2">Promociones</h5>
                                <p class="h6 mt-4">Agrega promociones para atrer mas huespedes.</p>
                            </span>
                        </asp:LinkButton>
                    </div>
                    <!-- Calendario -->
                    <div class="card">
                        <asp:LinkButton runat="server" ID="lbtnCalendario" style="text-decoration: none" OnClick="lbtnCalendario_Click" CssClass="notification">
                            <span>
                                <h5 class="h5 mt-2">Modificar calendario</h5>
                                <p class="h6 mt-4">Configura el calendario de un alojamiento.</p>
                            </span>
                        </asp:LinkButton>
                    </div>
                    <!-- Descuentos -->
                    <div class="card">
                        <asp:LinkButton runat="server" ID="lbtnDescuentos" style="text-decoration: none" OnClick="lbtnDescuentos_Click" CssClass="notification">
                            <span>
                                <h5 class="h5 mt-2">Descuentos</h5>
                                <p class="h6 mt-4">Agrega descuentos a tu alojamiento.</p>
                            </span>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-12">
                <div class="card-deck">
                    <div class="card">
                        <a href="#" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Notificaciones</h5>
                                <p class="h6 mt-4">Opinion de los anfitriones</p>
                                <% 
                                int cantidadNotificaciones = (Session["CantidadNotificaciones"] != null) ? (int)Session["CantidadNotificaciones"] : 0;
                                if (cantidadNotificaciones > 0)
                                { 
                                %>
                                    <span class="badgeCard"><%= cantidadNotificaciones %></span>
                                <% 
                                } 
                                %>
                        </a>
                    </div>


                    <div class="card">
                        <% 
                        bool usuarioMiBanco = (Session["MiBancoUsuario"] != null) ? (bool)Session["MiBancoUsuario"] : false;

                        if (usuarioMiBanco)
                        { 
                        %>
                            <a href="eliminarCuentaMiBanco.aspx" class="notification" style="text-decoration: none">
                                <span>
                                    <h5 class="h5 mt-2">Mi Banco</h5>
                                    <p class="h6 mt-4">Proporciona tus datos de tu cuenta para poder hacer el pago.</p>
                                </span>
                            </a>
                        <% 
                        }
                        else
                        {
                        %>
                            <a href="agregarmibanco.aspx" class="notification" style="text-decoration: none">
                                <span>
                                    <h5 class="h5 mt-2">Mi Banco</h5>
                                    <p class="h6 mt-4">Proporciona tus datos de tu cuenta para poder hacer el pago.</p>
                                </span>
                                <span class="badgeCard">1</span>
                            </a>
                        <% 
                        } 
                        %>

                    </div>
                    <div class="card">
                        <a href="#" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Lugares Visitados</h5>
                                <p class="h6 mt-4">Mira los hermosos lugares que has visitado.</p>
                            </span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <script>
        document.getElementById("miBanco").addEventListener("click", function () {

            $('#miBancoModal').modal("show");

        });
    </script>
    </span></asp:Content>
