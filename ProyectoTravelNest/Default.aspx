﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoTravelNest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
    <!-- Customized Bootstrap Stylesheet -->
  
    <link href="Content/style.css" rel="stylesheet" />
     <!-- Carousel Start -->
    <div class="container-fluid p-0">
        <div id="header-carousel" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img class="w-100" src="img/carousel-1.jpg" />" alt="Image">
                    <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                        <div class="p-3" style="max-width: 900px;">
                            <h4 class="text-white text-uppercase mb-md-3">Tours & Viajes</h4>
                            <h1 class="display-3 text-white mb-md-4">Vamos a Descubrir el Mundo Juntos</h1>
                        </div>
                    </div>
                </div>
                <div class="carousel-item">
                    <img class="w-100" src="img/carousel-2.jpg" alt="Image">
                    <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                        <div class="p-3" style="max-width: 900px;">
                            <h4 class="text-white text-uppercase mb-md-3">Tours & Viajes</h4>
                            <h1 class="display-3 text-white mb-md-4">Descubre Lugares Fantasticos con Nosotros</h1>
                        </div>
                    </div>
                </div>
            </div>
            <a class="carousel-control-prev" href="#header-carousel" data-slide="prev">
                <div class="btn btn-dark" style="width: 45px; height: 45px;">
                    <span class="carousel-control-prev-icon mb-n2"></span>
                </div>
            </a>
            <a class="carousel-control-next" href="#header-carousel" data-slide="next">
                <div class="btn btn-dark" style="width: 45px; height: 45px;">
                    <span class="carousel-control-next-icon mb-n2"></span>
                </div>
            </a>
        </div>
    </div>
    <!-- Carousel End -->


    <!-- Booking Start -->
    <div class="container-fluid booking mt-5">
        <div class="container ">
            <div class="bg-light shadow" style="padding: 30px;">
                <div class="row align-items-center" style="min-height: 60px;">
                    <div class="col-md-10">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="mb-3 mb-md-0">
                                    <select class="custom-select px-4" style="height: 47px;">
                                        <option selected>Tipo de Alojamiento</option>

                                    </select>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="mb-3 mb-md-0">
                                    <div class="date" id="date1" data-target-input="nearest">
                                        <input type="text" class="form-control p-4 datetimepicker-input"
                                            placeholder="Fecha de Ingreso" data-target="#date1"
                                            data-toggle="datetimepicker" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="mb-3 mb-md-0">
                                    <div class="date" id="date2" data-target-input="nearest">
                                        <input type="text" class="form-control p-4 datetimepicker-input"
                                            placeholder="Fecha de Salida" data-target="#date2"
                                            data-toggle="datetimepicker" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <button class="btn btn-primary btn-block" type="submit"
                            style="height: 47px; margin-top: -2px;">Filtrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Booking End -->


    <!-- Cartas -->
    <div class="container-fluid">
        <div class="container pt-5 pb-3">
            <div class="text-center mb-3 pb-3">
                <h6 class="text-primary text-uppercase" style="letter-spacing: 5px;">Lugares</h6>
                <h1>Encuentra Tu Lugar Perfecto</h1>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-6 mb-4">
                    <div class="package-item bg-white mb-2">
                        <img class="img-fluid" src="img/package-1.jpg" alt="">
                        <div class="p-4">
                            <div class="d-flex justify-content-between mb-3">
                                <small class="m-0"><i
                                        class="fa fa-map-marker-alt text-primary mr-2"></i>Thailand</small>
                                <small class="m-0"><i class="fa fa-heart text-danger"></i><a href="#">
                                        Favorito</a></small>
                                <small class="m-0"><i class="fa fa-user text-primary mr-2"></i>2 Person</small>
                            </div>
                            <a class="h5 text-decoration-none" href="">Islas Canarias</a>
                            <div class="border-top mt-4 pt-4">
                                <div class="d-flex justify-content-between">
                                    <h6 class="m-0"><i class="fa fa-star text-primary mr-2"></i>4.5 <small>(250)</small>
                                    </h6>
                                    <h5 class="m-0">$350</h5>
                                    <p><b>por noche</b></p>
                                </div>
                            </div>
                            <div class="border-top mt-4 pt-4">
                                <div class="d-flex justify-content-between">
                                    <button class="btn btn-primary btn-block" id="showModalButton"
                                        style="height: 47px; margin-top: -2px;" data-bs-toggle="modal"
                                        data-bs-target="#iniciarsesionmodal">Ver Información</button>
                                    <button class="btn btn-primary btn-block" style="height: 47px; margin-top: -2px;"
                                        id="showModalButtonCrearCuenta" data-bs-toggle="modal"
                                        data-bs-target="#crearcuentamodal" data-bs-dismiss="modal">Crear
                                        Cuenta</button>
                                    <button class="btn btn-primary btn-block" style="height: 47px; margin-top: -2px;"
                                        id="showModalButtonvalidariniciomodal" data-bs-toggle="modal"
                                        data-bs-target="#validariniciomodal" data-bs-dismiss="modal">validar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- mas cartas -->
            </div>
        </div>
    </div>
    <!-- Cartas -->

    <!-- Modal Iniciar Sesion -->
    <div class="modal fade" id="iniciarsesionmodal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true"
        data-bs-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="exampleModalLabel">Bienvenido</h5>
                    <button type="button" class=" btn btn-primary" data-bs-dismiss="modal"><i class="fa-solid fa-x"
                            style="color: #000000;"></i></button>
                </div>
                <div class="modal-body text-center ">
                    <input id="txtid" type="hidden" value="0" />
                    <div class="row  col-sm-12 text-center">
                        <div class="col-sm-12">
                            <img src="img/logo2.png" alt="logo" class="img-fluid">
                        </div>

                        <div class="col-sm-12">
                            <div class="col-sm-12">
                                <label for="txtcorreo" class="form-label">Correo Electrónico</label>
                                <input type="text" class="form-control" id="txtcorreo" name="txtcorreo"
                                    autocomplete="off">
                            </div>
                        </div>

                        <div class="col-sm-12">
                            <div class="col-sm-12">
                                <label for="txtcontrasena" class="form-label">Contraseña</label>
                                <input type="password" class="form-control" id="txtcontrasena" name="txtcontrasena"
                                    autocomplete="off">
                            </div>
                        </div>

                        <div class="col-sm-12 mt-4">
                            <button class="btn btn-primary btn-block" style="height: 47px; margin-top: -2px;">Iniciar
                                Sesión</button>
                        </div>
                        <div class="col-sm-12 mt-4">
                            <button class="btn btn-primary btn-block" style="height: 47px; margin-top: -2px;"
                                id="showModalButtonCrearCuenta" data-bs-toggle="modal"
                                data-bs-target="#crearcuentamodal" data-bs-dismiss="modal">Crear
                                Cuenta</button>
                        </div>



                    </div>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Crear Cuenta -->
    <div class="modal fade" id="crearcuentamodal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true"
        data-bs-backdrop="static">
        <div class="modal-dialog" style="z-index: 2000;">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="exampleModalLabel">Crear Cuenta</h5>
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal"><i class="fa-solid fa-x"
                            style="color: #000000;"></i></button>
                </div>
                <div class="modal-body">
                    <input id="txtid" type="hidden" value="0" />
                    <div class="row col-lg-12 col-sm-12 text-center">
                        <div class="col-sm-12 col-lg-12">
                            <img src="img/logo2.png" alt="logo" class="img-fluid">
                        </div>

                        <div class="col-sm-12 col-lg-6 mt-2">
                            <label for="txtnombre" class="form-label">Nombre</label>
                            <input type="text" class="form-control" id="txtnombre" name="txtnombre" autocomplete="off"
                                placeholder="Nombre">
                        </div>

                        <div class="col-sm-12 col-lg-6 mt-2">
                            <label for="txtcorreo" class="form-label">Correo Electrónico</label>
                            <input type="text" class="form-control" id="txtcorreo" name="txtcorreo" autocomplete="off"
                                placeholder="alguien@ejemplo.com">
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <label for="selectrol" class="form-label">Rol</label>
                            <select class="form-select" aria-label="Default select example" name="selectrol">
                                <option value="Anfitrión">Anfitrión</option>
                                <option value="Huésped">Huésped</option>
                            </select>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <label for="txtidentificacion">Identificación</label>
                            <input type="text" class="form-control" name="txtidentificacion" maxlength="11"
                                aria-describedby="idHelp" pattern="[0-9]{1}-[0-9]{4}-[0-9]{4}" placeholder="1-1111-1111"
                                required>
                            <small id="idHelp" class="form-text text-muted">El formato debe ser #-####-####</small>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <label for="txtapellidos" class="form-label">Apellidos</label>
                            <input type="text" class=" form-control" id="txtapellidos" name="txtapellidos"
                                autocomplete="off" placeholder="Apellidos">
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <label for="txtcontraseña">Contraseña</label>
                            <input type="password" class="form-control" id="password" name="txtcontrasena"
                                placeholder="Contraseña" minlength="10" required onkeyup="validarContrasena()">
                            <div>
                                <span id="mensaje" style="color: red;"></span>
                            </div>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <label for="txttelefono" class="form-label">Teléfono</label>
                            <input type="text" class="form-control" id="txttelefono" name="txttelefono"
                                autocomplete="off" placeholder="8888-8888" pattern="[0-9]{4}-[0-9]{4}">
                            <small id="idHelp" class="form-text text-muted">El formato debe ser ####-####</small>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <label for="imagen">Foto Perfil: </label>
                            <input style="margin: auto; max-width: 126px;" type="file" name="imagen" accept="image/*"
                                required>
                        </div>

                        <div class="col-sm-12 mt-4">
                            <button class="btn btn-primary btn-block" style="height: 47px; margin-top: -2px;">Crear
                                Cuenta</button>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal Iniciar Sesion -->
    <div class="modal fade" id="validariniciomodal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true"
        data-bs-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="exampleModalLabel">Bienvenido</h5>
                    <button type="button" class=" btn btn-primary" data-bs-dismiss="modal"><i class="fa-solid fa-x"
                            style="color: #000000;"></i></button>
                </div>
                <div class="modal-body text-center ">
                    <input id="txtid" type="hidden" value="0" />
                    <div class="row  col-sm-12 text-center">
                        <p>El código de verificación fue enviado a su correo</p>
                        <div class="col-sm-12">
                            <img src="img/logo2.png" alt="logo" class="img-fluid">
                        </div>

                        <div class="col-sm-12">
                            <div class="col-sm-12">
                                <label for="txtcorreo" class="form-label">Código</label>
                                <input type="text" class="form-control" id="txtcorreo" name="txtcorreo"
                                    autocomplete="off">
                            </div>
                        </div>

                        <div class="col-sm-12 mt-4">
                            <button class="btn btn-primary btn-block"
                                style="height: 47px; margin-top: -2px;">Validar</button>
                        </div>

                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>



    <!-- JavaScript Libraries -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"
        crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.7.0.js" crossorigin="anonymous"></script>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"
        crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <!-- Contact Javascript File -->
    <script src="mail/jqBootstrapValidation.min.js"></script>
    <script src="mail/contact.js"></script>

    <!-- Template Javascript -->
    <script src="js/main.js"></script>
    <script>
        document.getElementById("iniciarsesionmodal").addEventListener("click", function () {

            $('#iniciarsesionmodal').modal("show");

        });

        document.getElementById("showModalButtonCrearCuenta").addEventListener("click", function () {

            $('#crearcuentamodal').modal("show");

        });

        document.getElementById("showModalButtonvalidariniciomodal").addEventListener("click", function () {

            $('#validariniciomodal').modal("show");

        });

        
    </script>

</asp:Content>
