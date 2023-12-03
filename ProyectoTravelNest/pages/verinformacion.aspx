<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verinformacion.aspx.cs" Inherits="ProyectoTravelNest.pages.verinformacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/stylesInmueble.css" rel="stylesheet" />
    <!-- Favicon -->
    <link href="img/favicon.ico" rel="icon">

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;500;600;700&display=swap" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">

    <!-- Libraries Stylesheet -->
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>

    <!-- Customized Bootstrap Stylesheet -->
    <link href="../Content/style.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>


    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://unpkg.com/gijgo@1.9.14/js/gijgo.min.js" type="text/javascript"></script>
    <link href="https://unpkg.com/gijgo@1.9.14/css/gijgo.min.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .etiquetaPersonalizada {
            border: 1px solid #ccc; /* Borde sólido de 1 píxel en color gris */
            border-radius: 5px; /* Esquinas redondeadas de 5 píxeles */
            padding: 5px; /* Espaciado interno de 5 píxeles */
            display: inline-block; /* Permite establecer dimensiones y márgenes */
            margin-top: 2px;
            text-align: center;
            max-width: 280px;
            display: flex;
        }

        .calendar-inicio {
            background-color: #f9f9f9; /* Puedes cambiar "#FFA500" al color que desees */
        }

        .responsive-calendar table {
            width: 100% !important;
            font-size: 12px !important; /* Reduce el tamaño de la fuente */
            table-layout: fixed; /* Asegura que la tabla no exceda el ancho del contenedor */
        }

        @media screen and (max-width: 768px) {
            .responsive-calendar table {
                font-size: 8px !important; /* Reduce aún más el tamaño de la fuente para dispositivos móviles */
            }

            .responsive-calendar th, .responsive-calendar td {
                padding: 4px !important; /* Reduce el padding para ahorrar espacio */
            }

            .responsive-calendar .day-header, .responsive-calendar .week-number {
                display: none; /* Ocultar encabezados de día y números de semana para simplificar */
            }

            .responsive-calendar .next-prev a {
                font-size: 10px; /* Reduce el tamaño de la fuente en los botones de navegación del calendario */
            }

            /* Opcional: Estilos para controlar la altura de las filas */
            .responsive-calendar tr {
                height: 20px; /* Altura reducida para las filas */
            }

            .responsive-calendar td {
                font-size: 10px !important; /* Reduce el tamaño de la fuente de los números */

                width: 100%;
                height: 100%;
                line-height: normal; /* Ajusta la línea si es necesario */
                padding: 2px; /* Ajusta el padding si es necesario */
            }

            .responsive-calendar th {
                font-size: 10px !important; /* Reduce el tamaño de la fuente de los números */

                width: 100%;
                height: 100%;
                line-height: normal; /* Ajusta la línea si es necesario */
                padding: 2px; /* Ajusta el padding si es necesario */
            }
        }

        /* Estilo para evitar desbordamiento en pantallas pequeñas */
        .responsive-calendar {
            overflow-x: auto;
        }
    </style>


    <div class="container-fluid position-sticky ">


        <div class="container-fluid">
            <asp:Repeater ID="rptDatosInmueble" runat="server">
                <ItemTemplate>
                    <asp:Label ID="lblNombreLugar" runat="server" Text='<%# Eval("Nombre") %>' CssClass="h1" />


                    <div class="row mb-3 mt-2">
                        <div class="col-12 col-lg-auto">
                            <small><i class="fa fa-user text-primary mr-1"></i>El anfitrión: </small>
                        </div>
                        <div class="col-12 col-lg-auto">
                            <small><i class="fa fa-star text-primary mr-1"></i><%# Eval("Calificacion") %></small>
                        </div>
                        <div class="col-12 col-lg-auto">
                            <small><i class="fa fa-comment text-primary mr-1"></i><a href="comentariocalificacion?IdUsuario=<%# Request.QueryString["IdUsuario"] %>">Comentarios</a></small>
                        </div>
                        <div class="col-12 col-lg-auto">
                            <small><i class="fa fa-medal text-primary mr-1"></i><%# Eval("TipoAnfitrion") %></small>
                        </div>
                        <div class="col-lg-auto">
                            <small><i class="fa fa-map-marker-alt text-primary mr-1"></i><%# Eval("Direccion") %></small>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <!-- Carousel Start -->
        <div id="carouselE1" class="carousel slide" data-bs-ride="carousel">

            <div class="carousel-inner">
                <asp:Repeater ID="RepeaterImagen" runat="server">
                    <ItemTemplate>
                        <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                            <asp:Image ID="imgMueble" CssClass="img-fluid" runat="server"
                                src='<%# Eval("Imagen") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) : "" %>'
                                AlternateText="Imagen del mueble" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>



            <button class="carousel-control-prev" type="button" data-bs-target="#carouselE1" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselE1" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
        <!-- Carousel End -->


        <div class="container-fluid mt-3 ">

            <div class="row">
                <!--Principal-->
                <div class="col-lg-8 col-md-12 col-sm-12">
                    <asp:Repeater ID="RepeaterDatosSecundarios" runat="server">
                        <ItemTemplate>
                            <h4 style="display: inline-block;">Anfitrión: </h4>
                            <h4 style="display: inline-block;"><%# Eval("Dueno") %></h4>
                            <div class="d-flex ">
                                <small class="mr-3">
                                    <p style="display: inline;">
                                        <i class="fa fa-user text-primary mr-1"></i>
                                        <p style="display: inline;"><%# Eval("Cantidad_Huesped") %></p>
                                        Huéspedes
                                    </p>
                                </small>
                                <small class="mr-3"><i class="fa fa-toilet text-primary mr-1"></i>
                                    <p style="display: inline;">
                                        <p style="display: inline;"><%# Eval("Banhos") %></p>
                                        Baños
                                    </p>
                                </small>
                                <small class="mr-3">
                                    <p style="display: inline;">
                                        <i class="fa fa-bed text-primary mr-1"></i>
                                        <p style="display: inline;"><%# Eval("Habitaciones") %></p>
                                        Habitaciones
                                    </p>
                                </small>
                            </div>
                            <hr />
                            <div class="col-lg-8 col-md-12 col-sm-12 ">
                                <p>
                                    <%# Eval("Descripcion") %>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--Fin del repeater--%>
                    <hr />
                    <h4>Servicios</h4>
                    <div class="row">
                        <asp:Repeater ID="rptServicios" runat="server">
                            <ItemTemplate>
                                <div class="col-lg-4 col-md-6 mt-3 mb-4">
                                    <div class="service-item bg-white text-center mb-2 py-5 px-4" style="height: 230px;">
                                        <i class="fa fa-2x <%# ObtenerIconoServicio(Eval("Nombre").ToString()) %> mx-auto mb-4"></i>
                                        <h5 class="mb-2"><%# Eval("Nombre") %></h5>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="text-center">
                            <a href="#" data-toggle="modal" data-target="#serviciosModal">Ver Más Servicios</a>
                        </div>
                    </div>
                    <hr>
                    <h4>Amenidades</h4>
                    <asp:Repeater ID="rptAmenidades" runat="server">
                        <ItemTemplate>
                            <p class="d-inline-block m-2">

                                <i class="fa <%# ObtenerIconoAmenidad(Eval("Nombre").ToString()) %> text-primary mr-1 mx-2" style="display: inline;"></i>
                                <%# Eval("Nombre") %>
                            </p>
                        </ItemTemplate>
                    </asp:Repeater>
                    <hr />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <p style="color: red;">Fechas en rojo: No Disponibles</p>

                                <div class="col-lg-6 col-md-12 col-sm-12">

                                    <!-- Cambiado a col-lg-6 -->
                                    <h4>Fecha de Entrada</h4>
                                    <asp:Calendar ID="CalendarInicio" CssClass="calendar-inicio responsive-calendar" SelectionMode="DayWeekMonth" runat="server" OnDayRender="CalendarInicio_DayRender" OnSelectionChanged="CalendarInicio_SelectionChanged" AutoPostBack="false" />
                                </div>
                                <div class="col-lg-6 col-md-12 col-sm-12">
                                    <!-- Cambiado a col-lg-6 -->
                                    <h4>Fecha de Salida</h4>
                                    <asp:Calendar ID="CalendarFinal" CssClass="calendar-inicio responsive-calendar" SelectionMode="DayWeekMonth" runat="server" OnDayRender="CalendarFinal_DayRender" OnSelectionChanged="CalendarFinal_SelectionChanged" AutoPostBack="false" />
                                </div>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <hr />
                    <h4>Comentarios</h4>
                    <div class="row">
                        <asp:Repeater ID="RepeaterComentarios" runat="server">
                            <ItemTemplate>
                                <div class="my-2" style="clear: both;" id="comentario">
                                    <div id="user-image">
                                        <asp:Image ID="imgMueble" CssClass="img-fluid" runat="server"
                                            src='<%# Eval("Rostro") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Rostro")) : "../img/user.png" %>'
                                            Style="width: 30px; height: 30px; object-fit: cover; border-radius: 100px;" />
                                    </div>
                                    <div style="width: 60%;" id="user-info" class="ms-4">
                                        <a href="/pages/comentariocalificacion?IdUsuario=<%# Eval("Autor") %>" style="text-decoration: none; color: #212529;">
                                            <asp:Label runat="server" Text='<%# Eval("NombreCompleto") %>' CssClass="h5"></asp:Label>
                                        </a>
                                        <br />
                                        <div class="rate r-3" style="margin-top: -9px; margin-bottom: -15px;">
                                            <%# generarCalificacion(Convert.ToInt32(Eval("Calificacion"))) %>
                                        </div>
                                        <br>
                                        <label style="font-size: 15px; margin-bottom: 20px;">
                                            <%# Eval("Comentario") %>
                                        </label>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <hr />
                    <h4>Lo que debes saber</h4>
                    <div class="row">
                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="card" style="height: 100%;">
                                <div class="card-header" style="background-color: #7AB730; text-align: center; color: white; font-size: 20px;">
                                    Reglas del lugar
                                </div>
                                <div class="card-body" style="height: 100%; overflow-y: auto;">
                                    <asp:Repeater ID="rptReglas" runat="server">
                                        <ItemTemplate>
                                            <p class="card-text">
                                                <%# Eval("Explicacion") %>
                                            </p>
                                            <br />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="card" style="height: 100%;">
                                <div class="card-header" style="background-color: #7AB730; text-align: center; color: white; font-size: 20px;">
                                    Políticas del lugar
                                </div>
                                <div class="card-body" style="height: 100%; overflow-y: auto;">
                                    <asp:Repeater ID="rptPoliticas" runat="server">
                                        <ItemTemplate>
                                            <p class="card-text">
                                                <%# Eval("Comentario") %>
                                            </p>
                                            <br />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />

                </div>

                <!--Cotización-->
                <div class="col-lg-4 col-md-12 col-sm-12 sticky-lg-top" style="top: 20px;">
                    <div class="row">
                        <div class="col-sm-12 mb-12 mb-sm-12">
                            <div class="card">
                                <div class="card-body">
                                    <asp:UpdatePanel ID="UpdatePanelRepeater" runat="server">
                                        <ContentTemplate>
                                            <asp:Repeater ID="rptInmuebles" runat="server" OnItemDataBound="rptInmuebles_ItemDataBound">
                                                <ItemTemplate>
                                                    <div>
                                                        <div style="display: inline-block;">

                                                            <h5 class="card-title" style="display: inline-block;">$<%# Math.Round(Convert.ToDecimal(Eval("Precio")), 2) %></h5>
                                                            <h5 class="card-title" style="display: inline-block;">/ noche</h5>
                                                        </div>
                                                        <div>
                                                            <asp:Label ID="lblCantidadHuespedes" runat="server" Text='<%# Eval("Cantidad_Huesped") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="Label1" runat="server" Text="Huespedes"></asp:Label>
                                                            <asp:DropDownList ID="ddlHuespedes" runat="server" CssClass="form-select" AppendDataBoundItems="true" AutoPostBack="false">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <div>
                                                <asp:Label ID="Label2" runat="server" Text="Fecha Entrada"></asp:Label>
                                                <asp:Label ID="lblFechaEntrada" runat="server" Text="" CssClass="etiquetaPersonalizada"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text="Fecha Salida"></asp:Label>
                                                <asp:Label ID="lblFechaSalida" runat="server" Text="" CssClass="etiquetaPersonalizada"></asp:Label>

                                                <asp:Label ID="Label4" runat="server" Text="Total"></asp:Label>
                                                <asp:Label ID="txtTotal" runat="server" Text="" CssClass="etiquetaPersonalizada"></asp:Label>

                                            </div>

                                            <div class="mt-2">
                                                <asp:Button ID="btnReservar" runat="server" Text="Reservar" CssClass="btn btn-primary btn-block rounded"
                                                    Style="height: 47px; margin-top: -2px;" OnClick="btnReservar_Click" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>


        </div>

    </div>
    <!-- JavaScript Libraries -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"
        crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.7.0.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
    <!-- Contact Javascript File -->
    <script src="mail/jqBootstrapValidation.min.js"></script>
    <script src="mail/contact.js"></script>

    <!-- Template Javascript -->
    <script src="js/main.js"></script>
    <script>

        window.addEventListener('DOMContentLoaded', event => {

            const datatablesSimple = document.getElementById('datatablesSimple');
            if (datatablesSimple) {
                new simpleDatatables.DataTable(datatablesSimple);
            }

            var parametrosURL = new URLSearchParams(window.location.search);
            var IdUsuario = parametrosURL.get('IdUsuario');
            var IdInmueble = parametrosURL.get('IdInmueble');

            document.getElementById("pagComentariosI").href = "resenasInmueble.aspx?IdUsuario=" + IdUsuario + "&IdInmueble=" + IdInmueble;

        });
        document.getElementById("showModalButton").addEventListener("click", function () {
            $('#ModalInicioSesion').modal("show");

        });
        $(document).ready(function () {
            // Manejar el clic en los botones "Editar"
            $(".editar-btn").click(function () {
                // Mostrar el modal
                $("#FormModalEditar").modal("show");
            });
        });
        new DataTable('#example', {
            responsive: true
        });

    </script>
    <!-- Modal de servicios -->
    <div class="modal fade" id="serviciosModal" tabindex="-1" role="dialog" aria-labelledby="serviciosModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="serviciosModalLabel">Lista de Servicios</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Cerrar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Repeater ID="rptTodosServicios" runat="server">
                        <ItemTemplate>
                            <div class="service-item bg-white text-center mb-2 py-5 px-4" style="margin-bottom: 8px; display: flex;">
                                <i class="fa fa-2x <%# ObtenerIconoServicio(Eval("Nombre").ToString()) %>"></i>
                                <h3 class="mt-3 mx-5"><%# Eval("Nombre") %></h3>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
