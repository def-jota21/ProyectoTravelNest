<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoTravelNest._Default" %>

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


    <style>
        .center-cont {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: auto;
        }
    </style>

    <script>
        function validarContrasena() {
            const contrasenaInput = document.getElementById('<%= txtcontrasenaCrear.ClientID %>');
            if (contrasenaInput) {
                const contrasena = contrasenaInput.value;
                const longitudValida = contrasena.length >= 10;
                const contieneMayuscula = /[A-Z]/.test(contrasena);
                const contieneNumero = /\d/.test(contrasena);
                const noConsecutivos = !/(.)\1{1,}/.test(contrasena);
                const mensajes = document.getElementsByClassName("mensaje");
                const mensaje = mensajes.length > 0 ? mensajes[0] : null;
                if (longitudValida && contieneMayuscula && contieneNumero && noConsecutivos) {
                    mensaje.innerHTML = "Contraseña válida";
                    mensaje.style.color = "green";
                } else {
                    mensaje.innerHTML = "La contraseña debe cumplir con los siguientes requisitos:<br>";
                    if (!longitudValida) {
                        mensaje.innerHTML += " - Debe tener al menos 10 caracteres<br>";
                    }
                    if (!contieneMayuscula) {
                        mensaje.innerHTML += " - Debe contener al menos una letra mayúscula<br>";
                    }
                    if (!contieneNumero) {
                        mensaje.innerHTML += " - Debe contener al menos un número<br>";
                    }
                    if (!noConsecutivos) {
                        mensaje.innerHTML += " - No debe tener caracteres consecutivos<br>";
                    }
                    mensaje.style.color = "red";
                }


                // Habilitar o deshabilitar el botón de envío
                const botonEnvio = document.getElementById('<%= btnCrearCuenta.ClientID %>');
                botonEnvio.disabled = !(longitudValida && contieneMayuscula && contieneNumero && noConsecutivos);
            }
        }
    </script>

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
    <div class="container">
        <div class="bg-light shadow" style="padding: 30px;">
            <div class="row align-items-center" style="min-height: 60px;">
                <div class="col-md-10">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="mb-3 mb-md-0">
                                <select id="ddlCategorias" runat="server" class="custom-select px-4" style="height: 47px;">
                                    <option selected>Tipo de Alojamiento</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3 mb-md-0">
                                <select id="ddlCantidadPersonas" runat="server" class="custom-select px-4" style="height: 47px;">
                                    <option selected>Selecione catidad de personas</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3 mb-md-0">
                                <select id="ddlCalificacion" runat="server" class="custom-select px-4" style="height: 47px;">
                                    <option selected>Selecione calificacion</option>
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                <asp:LinkButton ID="Filtrar" runat="server" CssClass="btn btn-primary btn-block add-more-button" style="height: 47px; margin-top: -2px;">Filtrar</asp:LinkButton>
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
                <asp:Repeater ID="rptInmuebles" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 mb-4" data-categoria='<%# Eval("Categoria") %>'>
                            <div class="package-item bg-white mb-2">
                                <asp:Image ID="imgMueble" CssClass="img-fluid" runat="server"
                                    src='<%# Eval("Imagen") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) : "" %>'
                                    AlternateText="Imagen del mueble" />

                                <div class="p-4">
                                    <div class="d-flex justify-content-between mb-3">
                                        <small class="m-0"><i class="fa fa-map-marker-alt text-primary mr-2"></i>
                                            <asp:Label ID="lblUbicacion" runat="server" Text='<%# Eval("Direccion") %>'></asp:Label></small>
                                        <small class="m-0"><i class="fa fa-heart text-danger"></i>
                                            <asp:LinkButton ID="lnkFavorito" CssClass="m-0" runat="server"  data-idinmueble="1">
                                                &nbsp;Favorito
                                            </asp:LinkButton>
                                        </small>
                                        <small class="m-0"><i class="fa fa-user text-primary mr-2"></i>
                                            <asp:Label ID="lblPersonas" runat="server" Text='<%# Eval("Cantidad_Huesped") %>'></asp:Label></small>
                                    </div>
                                    <asp:Label ID="lnkDetalle" CssClass="h5 text-decoration-none" runat="server" NavigateUrl="#"><%# Eval("Nombre") %></asp:Label>
                                    <div class="border-top mt-4 pt-4">
                                        <div class="d-flex justify-content-between">
                                            <h6 class="m-0"><i class="fa fa-star text-primary mr-2"></i><%# Math.Round(Convert.ToDecimal(Eval("Calificacion")), 2) %><small></small></h6>
                                            <div class="d-flex justify-content-between">
                                                <h5 class="m-0" style="margin-right: 5px;">$<%# Math.Round(Convert.ToDecimal(Eval("Precio")), 2) %></h5>
                                                <p class="m-0"><b>&nbsp;por noche</b></p>
                                            </div>

                                        </div>
                                        <div class="border-top mt-4 pt-4">
                                            <div class="d-flex justify-content-between">
                                                <asp:Button ID="btnVerInformacion" runat="server" Text="Ver Información" CssClass="btn btn-primary btn-block"
                                                    Style="height: 47px; margin-top: -2px" CommandName="VerInformacion"
                                                    CommandArgument='<%# $"{Eval("IdUsuario")},{Eval("IdInmueble")}" %>' OnCommand="btnVerInformacion_Command"
                                                    UseSubmitBehavior="false" />



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--Fin carta-->
                    </ItemTemplate>
                </asp:Repeater>
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
                    <button type="button" class=" btn btn-primary" data-bs-dismiss="modal">
                        <i class="fa-solid fa-x"
                            style="color: #000000;"></i>
                    </button>
                </div>
                <div class="modal-body text-center center-cont">
                    <div class="row  col-sm-12 text-center">
                        <div class="col-sm-12">
                            <img src="img/logo2.png" alt="logo" class="img-fluid">
                        </div>

                        <div class="col-sm-12">
                            <div class="col-sm-12">
                                <asp:Label ID="lblCorreo" runat="server" AssociatedControlID="txtcorreo" CssClass="form-label">Correo Electrónico</asp:Label>
                                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-sm-12">
                            <div class="col-sm-12">
                                <asp:Label ID="lblContrasena" runat="server" AssociatedControlID="txtcontrasena" CssClass="form-label">Contraseña</asp:Label>
                                <asp:TextBox ID="txtcontrasena" runat="server" TextMode="Password" CssClass="form-control" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>



                        <div class="col-sm-12 mt-4">
                            <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary btn-block" Style="height: 47px; margin-top: -2px" OnClick="btnIniciarSesion_Click" />

                        </div>
                        <div class="col-sm-12 mt-4">
                            <button class="btn btn-primary btn-block" style="height: 47px; margin-top: -2px;"
                                id="showModalButtonCrearCuenta" data-bs-toggle="modal"
                                data-bs-target="#crearcuentamodal" data-bs-dismiss="modal">
                                Crear
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
                    <h5 class="modal-title" id="ModalCrearCuenta">Crear Cuenta</h5>
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">
                        <i class="fa-solid fa-x"
                            style="color: #000000;"></i>
                    </button>
                </div>
                <div class="modal-body center-cont">
                    <div class="row col-lg-12 col-sm-12 text-center">
                        <div class="col-sm-12 col-lg-12">
                            <img src="img/logo2.png" alt="logo" class="img-fluid">
                        </div>

                        <div class="col-sm-12 col-lg-6 mt-2">
                            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" CssClass="form-label">Nombre</asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" AutoComplete="off" placeholder="Nombre"></asp:TextBox>
                        </div>

                        <div class="col-sm-12 col-lg-6 mt-2">
                            <asp:Label ID="lblCorreoElectronico" runat="server" AssociatedControlID="txtCorreoElectronico" CssClass="form-label">Correo Electrónico</asp:Label>
                            <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control" AutoComplete="off" placeholder="alguien@ejemplo.com"></asp:TextBox>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <asp:Label ID="lblRol" runat="server" AssociatedControlID="ddlRol" CssClass="form-label">Rol</asp:Label>
                            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select" aria-label="Default select example">
                                <asp:ListItem Value="Anfitrión">Anfitrión</asp:ListItem>
                                <asp:ListItem Value="Huésped">Huésped</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <asp:Label ID="lblIdentificacion" runat="server" AssociatedControlID="txtIdentificacion" CssClass="form-label">Identificación</asp:Label>
                            <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control" MaxLength="11" aria-describedby="idHelp"
                                pattern="[0-9]{1}-[0-9]{4}-[0-9]{4}" placeholder="1-1111-1111" required="true"></asp:TextBox>
                            <small id="idHelpIdentificacion" class="form-text text-muted">El formato debe ser #-####-####</small>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <asp:Label ID="lblApellidos" runat="server" AssociatedControlID="txtApellidos" CssClass="form-label">Apellidos</asp:Label>
                            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" AutoComplete="off" placeholder="Apellidos"></asp:TextBox>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <asp:Label ID="lblContrasenaCrear" runat="server" AssociatedControlID="txtContrasena" CssClass="form-label">Contraseña</asp:Label>
                            <asp:TextBox ID="txtcontrasenaCrear" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña"
                                MinLength="10" OnKeyUp="validarContrasena()" required="true"></asp:TextBox>
                            <div>
                                <span class="mensaje" style="color: red;"></span>
                            </div>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <asp:Label ID="lblTelefono" runat="server" AssociatedControlID="txtTelefono" CssClass="form-label">Teléfono</asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" AutoComplete="off" placeholder="88888888"
                                pattern="[0-9]{4}[0-9]{4}"></asp:TextBox>
                            <small id="idHelp" class="form-text text-muted">El formato debe ser ########</small>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <asp:Label ID="lblImagen" runat="server" AssociatedControlID="fileImagen" CssClass="form-label">Foto Perfil:</asp:Label>
                            <asp:FileUpload ID="fileImagen" runat="server" Style="margin: auto; max-width: 126px;" accept=".jpg" required="true"></asp:FileUpload>
                        </div>

                        <div class="col-sm-12 mt-12">
                            <asp:Button disabled="true" ID="btnCrearCuenta" runat="server" Text="Crear Cuenta" CssClass="btn btn-primary btn-block"
                                Style="height: 47px; margin-top: -2px" OnClick="btnCrearCuenta_Click" />

                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal Valdiar Iniciar Sesion -->
    <div class="modal fade" id="validariniciomodal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true"
        data-bs-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="exampleModalLabel">Bienvenido</h5>
                    <button type="button" class=" btn btn-primary" data-bs-dismiss="modal">
                        <i class="fa-solid fa-x"
                            style="color: #000000;"></i>
                    </button>
                </div>
                <div class="modal-body text-center center-cont">
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
                                style="height: 47px; margin-top: -2px;">
                                Validar</button>
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
        document.addEventListener("DOMContentLoaded", function () {
            const enlaceFavorito = document.getElementById("enlace-favorito");
            const corazon = document.getElementById("corazon");

            enlaceFavorito.addEventListener("click", function (event) {
                event.preventDefault(); // Evita que el enlace siga el enlace original

                // Cambia la clase del corazón para cambiar su color a rojo
                corazon.classList.toggle("favorito-activo");
            });
        });

        // Función para agregar elementos a favoritos
        function agregarAFavoritos(elemento) {
            // Obtener los datos relevantes de la tarjeta (puedes usar atributos de datos personalizados)
            var ubicacion = elemento.getAttribute("data-ubicacion");
            var personas = elemento.getAttribute("data-personas");
            var detalle = elemento.getAttribute("data-detalle");
            var precio = elemento.getAttribute("data-precio");

            // Crear un objeto que contenga la información de la tarjeta
            var lugarFavorito = {
                ubicacion: ubicacion,
                personas: personas,
                detalle: detalle,
                precio: precio
            };

            // Guardar el lugar favorito en el almacenamiento local o en una cookie
            var favoritos = JSON.parse(localStorage.getItem('favoritos')) || [];
            favoritos.push(lugarFavorito);
            localStorage.setItem('favoritos', JSON.stringify(favoritos));

            // Redireccionar a la página de Favoritos
            window.location.href = 'favoritos.html';
        }

    </script>
</asp:Content>
