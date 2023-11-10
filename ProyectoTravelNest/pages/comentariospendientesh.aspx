<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="comentariospendientesh.aspx.cs" Inherits="ProyectoTravelNest.pages.comentariospendientesh" %>

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

        #txtcomentarioPrivado {
            resize: none;
        }

        #txtcomentarioPublico {
            resize: none;
        }
    </style>

    <div class="container">
        <img src="../img/estrellas.JPG" alt="" class="img-fluid">
        <div class="container">
            <div class="row">
                <h5>Comentarios Pendientes</h5>
                <div class="col-lg-12 col-md-12 col-sm-12 my-2">
                    <div class="row">
                        <asp:Repeater ID="rptComentariosPendientes" runat="server">
                            <ItemTemplate>
                                <div class="col-lg-4 col-md-6 mb-4">
                                    <div class="package-item bg-white mb-2">
                                        <asp:Image ID="imgMueble" CssClass="img-fluid" runat="server"
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
                                                    <div class="d-flex justify-content-between">
                                                        <h5 class="m-0" style="margin-right: 5px;">Anfitrión:&nbsp;<%# Eval("NombreAnfitrion")%></h5>
                                                    </div>

                                                </div>
                                                <div class="border-top mt-4 pt-4">
                                                    <div class="d-flex justify-content-between">
                                                        <asp:Button ID="btnRealizarComentario" runat="server" Text="Realizar Comentario" CssClass="btn btn-primary btn-block"
                                                            Style="height: 47px; margin-top: -2px; text-align: center;" CommandName="RealizarComentario"
                                                            CommandArgument='<%# $"{Eval("idAnfitrion")},{Eval("IdReservacion")}" %>' OnCommand="btnRealizarComentario_Command"
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
</asp:Content>
