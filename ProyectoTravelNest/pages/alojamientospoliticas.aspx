﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alojamientospoliticas.aspx.cs" Inherits="ProyectoTravelNest.pages.alojamientospoliticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta content="Free HTML Templates" name="keywords">
    <meta content="Free HTML Templates" name="description">

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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>

    <link href="../Content/styleComentariosPendientes.css" rel="stylesheet" />

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
            display: flex;
            text-align: center !important;
        }

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

        #txtcomentarioPrivado {
            resize: none;
        }

        #txtcomentarioPublico {
            resize: none;
        }

        /* Estilo por defecto para pantallas grandes */
        .btn-politicas {
            font-size: 16px; /* o el tamaño que prefieras */
        }

        /* Estilo para pantallas medianas */
        @media screen and (max-width: 768px) {
            .btn-politicas {
                font-size: 14px;
            }
        }

        /* Estilo para pantallas pequeñas */
        @media screen and (max-width: 576px) {
            .btn-politicas {
                font-size: 14px;
            }
        }

        .btn-center-text {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 47px; /* Mantén la altura deseada */
        }
    </style>

    <div class="container">
        <div class="d-flex align-items-center justify-content-center">
            <img src="../img/covergestionusuarios.jpg" alt="" class="img-fluid">
        </div>
        <div class="container">
            <h5>Administrar Políticas</h5>
            <p style="color:black;">Seleccione el alojamiento al que desea administrar las políticas</p>
            <a style="margin-bottom:4px !important;" href="panelanfitrion.aspx"><i class="fa fa-arrow-left text-primary mr-2"></i>Regresar</a>
            <div class="row mt-3">
                <asp:Repeater ID="rptAlojamientos" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 mb-4">
                            <div class="package-item bg-white mb-2">
                                <asp:Image ID="imgMueble" CssClass="img-fluid" runat="server" Style="min-height: 240px !important;"
                                    src='<%# Eval("Imagen") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) : "" %>'
                                    AlternateText="Imagen del mueble" />

                                <div class="p-4">
                                    <div class="d-flex justify-content-between mb-3">
                                        <small class="m-0"><i class="fa fa-map-marker-alt text-primary mr-2"></i>
                                            <asp:Label ID="lblUbicacion" runat="server" Text='<%# Eval("Direccion") %>'></asp:Label></small>

                                    </div>
                                    <asp:Label ID="lnkDetalle" CssClass="h5 text-decoration-none" runat="server" NavigateUrl="#"><%# Eval("Nombre") %></asp:Label>
                                    <div class="border-top mt-4 pt-4">
                                        <div class="d-flex justify-content-between">
                                            <asp:Button ID="btnPoliticas" runat="server" Text="Administrar Políticas"
                                                CssClass="btn btn-primary btn-block btn-politicas btn-center-text"
                                                Style="height: 47px; margin-top: -2px; text-align: center;"
                                                CommandName="AdmPoliticas"
                                                CommandArgument='<%# $"{Eval("idUsuario")},{Eval("IdInmueble")}" %>'
                                                OnCommand="btnPoliticas_Command"
                                                UseSubmitBehavior="false" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
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
