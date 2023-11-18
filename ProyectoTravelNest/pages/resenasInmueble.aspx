<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="resenasInmueble.aspx.cs" Inherits="ProyectoTravelNest.pages.resenasInmueble" %>
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

    <div class="container-fluid position-sticky ">


        <div class="container-fluid">
            <asp:Repeater ID="rptDatosInmueble" runat="server">
                <ItemTemplate>
                    <asp:Label ID="lblNombreLugar" runat="server" Text='<%# Eval("Nombre") %>' CssClass="h1" />

                    <div class="d-flex mb-3">
                        <small class="mr-3"><i class="fa fa-star text-primary mr-1"></i><%# Eval("Calificacion") %></small>
                        <small class="mr-3"><%# Eval("TipoAnfitrion") %></small>
                        <small class="mr-3"><%# Eval("Direccion") %></small>
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
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--Fin del repeater--%>
                    <hr />
                    <h4>Comentarios</h4>
                    <div class="row" style="margin-top: -75px;">
                        <div class="col-md-8 my-5">
                            <asp:Repeater ID="RepeaterComentarios" runat="server">
                                <ItemTemplate>
                                    <div class="my-5" style="clear: both;" id="comentario">
                                        <div id="user-image">
                                            <img src="../img/user.png" style="width: 7%;">
                                        </div>
                                        <div style="width: 60%;" id="user-info" class="ms-4">
                                            <a href="/pages/comentariocalificacion?IdUsuario=<%# Eval("Autor") %>" style="text-decoration: none; color: #212529;">
                                                <asp:Label runat="server" Text='<%# Eval("NombreCompleto") %>' CssClass="h5"></asp:Label>
                                            </a>
                                            <br />
                                            <div class="rate r-3" style="margin-top: -9px; margin-bottom: -15px;">
                                                <%# generarCalificacion(Convert.ToInt32(Eval("Calificacion"))) %>
                                            </div><br>
                                            <label style="font-size: 15px; margin-bottom: 40px;">
                                                <%# Eval("Comentario") %>
                                            </label>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <hr />
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
