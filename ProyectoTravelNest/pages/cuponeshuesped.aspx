<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cuponeshuesped.aspx.cs" Inherits="ProyectoTravelNest.pages.cuponeshuesped" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Favicon -->
    <link href="img/favicon.ico" rel="icon">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;500;600;700&display=swap" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css"
        integrity="sha512-z3gLpd7yknf1YoNbCzqRKc4qyor8gaKU1qmn+CShxbuBusANI9QpRohGBreCFkKxLhei6S9CQXFEbbKuqLg0DA=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />

    <!-- Libraries Stylesheet -->
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
    <link href="../Content/styleComentariosPendientes.css" rel="stylesheet" />

    <link href="../Content/cupones.css" rel="stylesheet" />
    <!-- Customized Bootstrap Stylesheet -->
    <style>
        .center-content {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        .btn-primary {
            color: #fff;
            background-color: #7AB730;
            border-color: #7AB730;
        }

        #txtcomentarioPrivado {
            resize: none;
        }

        #txtcomentarioPublico {
            resize: none;
        }

        #seccionEdicion {
            display: none;
            color: black;
            border: 2px dotted #7AB730; /* Color del borde */
            padding: 20px; /* Espacio interior para que no esté pegado el contenido al borde */
            margin-top: 20px; /* Espacio exterior superior */
            border-radius: 10px; /* Bordes redondeados */
            background-color: #f9f9f9; /* Color de fondo */
        }

        #seccionAgregar {
            display: none;
            color: black;
            border: 2px dotted #7AB730; /* Color del borde */
            padding: 20px; /* Espacio interior para que no esté pegado el contenido al borde */
            margin-top: 20px; /* Espacio exterior superior */
            border-radius: 10px; /* Bordes redondeados */
            background-color: #f9f9f9; /* Color de fondo */
        }
    </style>

    <div class="container">
        <h1 style="color: #7AB730;">Mis Cupones</h1>
        <p style="color: dimgrey;">Cupones disponibles.</p>
        <a style="margin-bottom: 4px !important;" href="paneladministracionhuesped.aspx"><i class="fa fa-arrow-left text-primary mr-2"></i>Regresar</a>
        <div class="row">

            <div class="col-lg-8 col-md-12 col-sm-12 my-2">


                <ul>
                    <asp:Repeater ID="rptCupon" runat="server">
                        <ItemTemplate>
                            <li class="card">
                                <div class="card__flipper">
                                    <div class="card__front">
                                        <p class="card__name">
                                            <span>Vencimiento: <%# Convert.ToDateTime(Eval("FechaVencimiento")).ToString("dd/MM/yyyy") %></span><br>
                                            <span style="margin-bottom: 6px !important;">Cupon</span><br>
                                            <%# Eval("IdCupon") %>
                                        </p>
                                        <p class="card__name">
                                        </p>
                                        <p class="card__num" style="font-size: 80px;"><%# Eval("PorcentajeDescuento") %>%</p>
                                    </div>
                                    <div class="card__back">
                                        <svg height="180" width="180">
                                            <circle cx="90" cy="90" r="55" stroke="#7AB730" stroke-width="35" />
                                        </svg>
                                        <span style="color: #7AB730;"><%# Eval("PorcentajeDescuento") %>%</span>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>

            </div>
            <div class="col-lg-4 col-md-12 col-sm-12 my-2 d-flex align-items-center">
                <div class="w-100">
                    <img src="../img/cuponeshuesped.jpg" alt="" class="img-fluid">
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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
    <!-- Contact Javascript File -->
    <script src="mail/jqBootstrapValidation.min.js"></script>
    <script src="mail/contact.js"></script>

    <!-- Template Javascript -->
    <script src="js/main.js"></script>

    <script>

        var Flipper = (function () {
            var card = $('.card');
            var flipper = card.find('.card__flipper');
            var win = $(window);

            var flip = function () {
                var thisCard = $(this);
                var thisFlipper = thisCard.find('.card__flipper');
                var offset = thisCard.offset();
                var xc = win.width() / 2;
                var yc = win.height() / 2;
                var docScroll = $(document).scrollTop();
                var cardW = thisCard.outerWidth() / 2;
                var cardH = thisCard.height() / 2;

                var transX = xc - offset.left - cardW;
                var transY = docScroll + yc - offset.top - cardH;
                //     if (offset.top > card.height()) transY = docScroll - offset.top + cardH;
                if (win.width() <= 700) transY = 0;

                if (card.hasClass('active')) unflip();

                thisCard.css({ 'z-index': '3' }).addClass('active');

                thisFlipper.css({
                    'transform': 'translate3d(' + transX + 'px,' + transY + 'px, 0) rotateY(180deg) scale(1)',
                    '-webkit-transform': 'translate3d(' + transX + 'px,' + transY + 'px, 0) rotateY(180deg) scale(1)',
                    '-ms-transform': 'translate3d(' + transX + 'px,' + transY + 'px, 0) rotateY(180deg) scale(1)'
                }).addClass('active');

                return false;
            };

            var unflip = function (e) {
                card.css({ 'z-index': '1' }).removeClass('active');
                flipper.css({
                    'transform': 'none',
                    '-webkit-transform': 'none',
                    '-ms-transform': 'none'
                }).removeClass('active');
            };

            var bindActions = function () {
                card.on('click', flip);
                win.on('click', unflip);
            }

            var init = function () {
                bindActions();
            };

            return {
                init: init
            };

        }());

        Flipper.init();
    </script>
</asp:Content>
