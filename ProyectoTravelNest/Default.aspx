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
        .package-item {
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            height: 100%;
        }

            .package-item .p-4 {
                flex: 1;
            }

            .package-item .btnVerInformacion {
                align-self: flex-end;
            }

        .center-cont {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: auto;
        }
    </style>



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
    <asp:UpdatePanel runat="server" ID="upd_Panel" UpdateMode="Conditional">
        <ContentTemplate>

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
                                            <asp:DropDownList ID="ddlCantidadPersonas" runat="server" CssClass="custom-select px-4" Style="height: 47px;">
                                                <asp:ListItem Text="Cantidad de personas" Value="0" />
                                                <asp:ListItem Text="1" Value="1" />
                                                <asp:ListItem Text="2" Value="2" />
                                                <asp:ListItem Text="3" Value="3" />
                                                <asp:ListItem Text="4" Value="4" />
                                                <asp:ListItem Text="5" Value="5" />
                                                <asp:ListItem Text="6" Value="6" />
                                                <asp:ListItem Text="7" Value="7" />
                                                <asp:ListItem Text="8" Value="8" />
                                                <asp:ListItem Text="9" Value="9" />
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="mb-3 mb-md-0">
                                            <asp:DropDownList ID="ddlCalificacion" runat="server" CssClass="custom-select px-4" Style="height: 47px;">
                                                <asp:ListItem Text="Seleccione calificación" Value="0" />
                                                <asp:ListItem Text="1" Value="1" />
                                                <asp:ListItem Text="2" Value="2" />
                                                <asp:ListItem Text="3" Value="3" />
                                                <asp:ListItem Text="4" Value="4" />
                                                <asp:ListItem Text="5" Value="5" />
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <asp:LinkButton ID="Filtrar" runat="server" CssClass="btn btn-primary btn-block add-more-button" OnClick="FiltrarIn" Style="height: 47px; margin-top: -2px;">Filtrar</asp:LinkButton>
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
                        <asp:ListView ID="lvInmuebles" runat="server" OnPagePropertiesChanging="lvInmuebles_OnPagePropertiesChanging">
                            <LayoutTemplate>
                                <div class="row">
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="col-lg-4 col-md-12 mb-12" data-categoria='<%# Eval("Categoria") %>'>
                                    <div class="package-item bg-white mb-2">
                                        <asp:Image ID="imgMueble" CssClass="img-fluid" Style="min-height: 240px !important; max-height: 240px !important" runat="server"
                                            src='<%# Eval("Imagen") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) : "" %>'
                                            AlternateText="Imagen del mueble" />

                                        <div class="p-4">
                                            <div class="d-flex justify-content-between mb-3">
                                                <small class="m-0"><i class="fa fa-map-marker-alt text-primary mr-2"></i>
                                                    <asp:Label ID="lblUbicacion" runat="server"
                                                        Text='<%# Eval("Direccion").ToString().Length > 12 ? Eval("Direccion").ToString().Substring(0, 12) + "..." : Eval("Direccion") %>'>
                                                    </asp:Label></small>
                                                <small class="m-0"><i class="fa fa-heart text-danger"></i>
                                                    <asp:LinkButton ID="lnkFavorito" CssClass="m-0" runat="server" data-idinmueble='<%# Eval("IdInmueble") %>' OnClick="AgregarFavorito_Click">
                                    &nbsp;Favorito
                                                    </asp:LinkButton>
                                                </small>
                                                <small class="m-0"><i class="fa fa-user text-primary mr-2"></i>
                                                    <asp:Label ID="lblPersonas" runat="server" Text='<%# Eval("Cantidad_Huesped") %>'></asp:Label></small>
                                            </div>
                                            <asp:Label ID="lnkDetalle" CssClass="h5 text-decoration-none" runat="server" NavigateUrl="#"><%# Eval("Nombre").ToString().Length > 19 ? Eval("Nombre").ToString().Substring(0, 19) + "..." : Eval("Nombre") %></asp:Label>
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
                                                            Style="height: 47px;" CommandName="VerInformacion"
                                                            CommandArgument='<%# $"{Eval("IdUsuario")},{Eval("IdInmueble")}" %>' OnCommand="btnVerInformacion_Command"
                                                            UseSubmitBehavior="false" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                        <div>
                            <b>Páginas</b>
                        </div>
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="15" PagedControlID="lvInmuebles">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                <asp:NumericPagerField />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>
            </div>

            <!-- Cartas -->


        </ContentTemplate>
    </asp:UpdatePanel>

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

    <script>
        $(document).ready(function () {
            // Encuentra todas las tarjetas en el repeater
            var cards = $(".package-item");

            // Encuentra la altura máxima entre todas las tarjetas
            var maxHeight = 0;
            cards.each(function () {
                var cardHeight = $(this).outerHeight();
                if (cardHeight > maxHeight) {
                    maxHeight = cardHeight;
                }
            });

            // Establece la misma altura máxima para todas las tarjetas
            cards.css("height", maxHeight + "px");
        });
    </script>




</asp:Content>
