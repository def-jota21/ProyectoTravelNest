<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verinformacion.aspx.cs" Inherits="ProyectoTravelNest.pages.verinformacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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

    <div class="container-fluid position-sticky ">


        <div class="container-fluid">

            <h1>Nombre del Lugar</h1>
            <div class="d-flex mb-3">
                <small class="mr-3"><i class="fa fa-star text-primary mr-1"></i>#</small>
                <small class="mr-3"><a href="#">Comentarios</a></small>
                <small class="mr-3">Tipo Anfitrion</small>
                <small class="mr-3">Ubicacion</small>
            </div>

        </div>

        <!-- Carousel Start -->
        <div id="carouselE1" class="carousel slide" data-bs-ride="carousel">

            <div class="carousel-inner">

                <div class="carousel-item active">
                    <img src="img/carousel-1.jpg" class="d-block w-100" alt="">
                </div>

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
                    <h4 style="display: inline-block;">Anfitrión: </h4>
                    <h4 style="display: inline-block;">NOMBRE ANFITRIÓN</h4>
                    <div class="d-flex mb-3">
                        <small class="mr-3">
                            <p style="display: inline;">
                                <p style="display: inline;">#</p>
                                huespedes
                            </p>
                        </small>
                        <small class="mr-3">
                            <p style="display: inline;">
                                <p style="display: inline;">#</p>
                                baño
                            </p>
                        </small>
                        <small class="mr-3">
                            <p style="display: inline;">
                                <p style="display: inline;">#</p>
                                cama
                            </p>
                        </small>
                        <small class="mr-3">
                            <p style="display: inline;">
                                <p style="display: inline;">#</p>
                                habitación
                            </p>
                        </small>
                    </div>
                    <hr class="hrinfo" />
                    <div class="col-lg-8 col-md-12 col-sm-12 ">
                        <p>
                            Lorem ipsum dolor sit amet consectetur adipisicing elit. Error recusandae eius officiis fuga
                            est, perspiciatis optio aliquam, enim modi atque maiores voluptatem vero velit, nesciunt
                            minus possimus explicabo. Omnis, itaque.
                        </p>
                    </div>
                    <hr />
                    <h4>Servicios</h4>
                    <div class="row">
                        <div class="col-lg-4 col-md-6 mb-4">
                            <div class="service-item bg-white text-center mb-2 py-5 px-4">
                                <i class="fa fa-2x fa-route mx-auto mb-4"></i>
                                <h5 class="mb-2">Travel Guide</h5>
                                <p class="m-0">
                                    Justo sit justo eos amet tempor amet clita amet ipsum eos elitr. Amet
                                    lorem est amet labore
                                </p>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 mb-4">
                            <div class="service-item bg-white text-center mb-2 py-5 px-4">
                                <i class="fa fa-2x fa-ticket-alt mx-auto mb-4"></i>
                                <h5 class="mb-2">Ticket Booking</h5>
                                <p class="m-0">
                                    Justo sit justo eos amet tempor amet clita amet ipsum eos elitr. Amet
                                    lorem est amet labore
                                </p>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 mb-4">
                            <div class="service-item bg-white text-center mb-2 py-5 px-4">
                                <i class="fa fa-2x fa-hotel mx-auto mb-4"></i>
                                <h5 class="mb-2">Hotel Booking</h5>
                                <p class="m-0">
                                    Justo sit justo eos amet tempor amet clita amet ipsum eos elitr. Amet
                                    lorem est amet labore
                                </p>
                            </div>
                        </div>
                        <div class="text-center">
                            <a href="#">Ver Más Servicios</a>
                        </div>
                    </div>
                    <hr>
                    <h4>Amenidades</h4>
                    <p style="display: inline;">
                        <i class="fa fa-wifi text-primary mr-1" style="display: inline;"></i>
                        Wifi
                    </p>
                    <hr />
                    <div class="row">
                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <h4>Fechas de estadia</h4>
                            <div class="container">
                                Fecha de Ingreso:
                                <input id="startDate" width="276" />
                                Fecha de Salida:
                                <input id="endDate" width="276" />
                                <div class="mt-2">
                                    <button class="btn btn-primary btn-block rounded" type="submit"
                                        style="height: 47px; margin-top: -2px; width: 276px;">
                                        Consultar Fechas</button>
                                </div>
                            </div>
                            <script>
                                var today = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate());
                                $('#startDate').datepicker({
                                    uiLibrary: 'bootstrap4',
                                    iconsLibrary: 'fontawesome',
                                    minDate: today,
                                    maxDate: function () {
                                        return $('#endDate').val();
                                    }
                                });
                                $('#endDate').datepicker({
                                    uiLibrary: 'bootstrap4',
                                    iconsLibrary: 'fontawesome',
                                    minDate: function () {
                                        return $('#startDate').val();
                                    }
                                });
                            </script>
                        </div>
                    </div>
                    <hr />
                    <h4>Comentarios</h4>
                    <hr />
                    <h4>Lo que debes saber</h4>
                    <div class="row">
                        <div class="col-lg-4 col-md-12 col-sm-12">
                            <div class="card">
                                <div class="card-header">
                                    Reglas del lugar
                                </div>
                                <div class="card-body">
                                    <p class="card-text">
                                        With supporting text below as a natural lead-in to additional
                                        content.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-12 col-sm-12">
                            <div class="card">
                                <div class="card-header">
                                    Seguridad y propiedad
                                </div>
                                <div class="card-body">
                                    <p class="card-text">
                                        With supporting text below as a natural lead-in to additional
                                        content.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-12 col-sm-12">
                            <div class="card">
                                <div class="card-header">
                                    Política de cancelación
                                </div>
                                <div class="card-body">
                                    <p class="card-text">
                                        With supporting text below as a natural lead-in to additional
                                        content.
                                    </p>
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
                                    <h5 class="card-title" style="display: inline-block;">$$</h5>
                                    <h5 class="card-title" style="display: inline-block;">/ noche</h5>
                                    <select class="form-select" aria-label="Default select example">
                                        <option selected>Huespedes</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                    <div class="mt-2">
                                        <button class="btn btn-primary btn-block rounded" type="submit"
                                            style="height: 47px; margin-top: -2px;">
                                            Reservar</button>
                                    </div>
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
</asp:Content>
