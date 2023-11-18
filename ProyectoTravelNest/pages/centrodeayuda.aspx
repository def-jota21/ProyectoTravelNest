<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="centrodeayuda.aspx.cs" Inherits="ProyectoTravelNest.pages.centrodeayuda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="container pt-5 pb-3">
            <a class="h3 mx-2 ver_huesped" style="cursor: pointer">Huesped</a>
            <a class="h3 ver_anfitrion" style="cursor: pointer">Anfitrión</a>
            <div class="row">
                </br>
                <!-- Huesped -->
                    <!-- [Introduccion] -->
                    <div class="col-lg-4 col-md-6 mt-4 mb-4 ca_huesped">
                        <a href="#">
                            <div class="package-item bg-white mb-2">
                                <img class="img-fluid" src="../img/package-5.jpg" alt="">
                                <div class="p-4">
                                    <a class="h5 text-decoration-none" href="">Introduccion</a>
                                </div>
                            </div>
                        </a>
                    </div>
                    <!-- [Encuentra una estadia perfecta] -->
                    <div class="col-lg-4 col-md-6 mt-4 mb-4 ca_huesped">
                        <a href="#">
                            <div class="package-item bg-white mb-2">
                                <img class="img-fluid" src="../img/package-5.jpg" alt="">
                                <div class="p-4">
                                    <a class="h5 text-decoration-none" href="">Encuentra una estadia perfecta</a>
                                </div>
                            </div>
                        </a>
                    </div>
                    <!-- [Para tu viaje] -->
                    <div class="col-lg-4 col-md-6 mt-4 mb-4 ca_huesped">
                        <a href="#">
                            <div class="package-item bg-white mb-2">
                                <img class="img-fluid" src="../img/package-5.jpg" alt="">
                                <div class="p-4">
                                    <a class="h5 text-decoration-none" href="">Para tu viaje</a>
                                </div>
                            </div>
                        </a>
                    </div>
                    

                <!-- Anfitrión -->
                    <!-- [Cómo optimizar tu anuncio] -->
                    <div class="col-lg-4 col-md-6 mt-4 mb-4 ca_anfitrion" style="display: none;">
                        <a href="#">
                            <div class="package-item bg-white mb-2">
                                <img class="img-fluid" src="../img/package-6.png" alt="">
                                <div class="p-4">
                                    <a class="h5 text-decoration-none" href="">Cómo optimizar tu anuncio</a>
                                </div>
                            </div>
                        </a>
                    </div>
                    <!-- [Cómo cobrar] -->
                    <div class="col-lg-4 col-md-6 mt-4 mb-4 ca_anfitrion" style="display: none;">
                        <a href="#">
                            <div class="package-item bg-white mb-2">
                                <img class="img-fluid" src="../img/package-6.png" alt="">
                                <div class="p-4">
                                    <a class="h5 text-decoration-none" href="">Cómo cobrar</a>
                                </div>
                            </div>
                        </a>
                    </div>
                    <!-- [Cómo alcanzar tus metas] -->
                    <div class="col-lg-4 col-md-6 mt-4 mb-4 ca_anfitrion" style="display: none;" >
                        <a href="#">
                            <div class="package-item bg-white mb-2">
                                <img class="img-fluid" src="../img/package-6.png" alt="">
                                <div class="p-4">
                                    <a class="h5 text-decoration-none" href="">Cómo alcanzar tus metas como
                                        anfitrión</a>
                                </div>
                            </div>
                        </a>
                    </div>
                    <!-- [Cambios, cancelaciones y reembolsos] -->
                    <div class="col-lg-4 col-md-6 mt-4 mb-4 ca_anfitrion" style="display: none;">
                        <a href="#">
                            <div class="package-item bg-white mb-2">
                                <img class="img-fluid" src="../img/package-6.png" alt="">
                                <div class="p-4">
                                    <a class="h5 text-decoration-none" href="">Cambios, cancelaciones y reembolsos</a>
                                </div>
                            </div>
                        </a>
                    </div>
            </div>
        </div>
    </div>
    <script>
        // Boton Anfitrion
        var botonA = document.querySelector('.ver_anfitrion');

        botonA.addEventListener('click', function () {
            var anfitrion = document.querySelectorAll('.ca_anfitrion');
            for (var i = 0; i < anfitrion.length; i++) {
                anfitrion[i].style.display = 'block';
            }

            var huesped = document.querySelectorAll('.ca_huesped');
            for (var i = 0; i < huesped.length; i++) {
                huesped[i].style.display = 'none';
            }
        });
        // Boton Huesped
        var botonH = document.querySelector('.ver_huesped');

        botonH.addEventListener('click', function () {
            var anfitrion = document.querySelectorAll('.ca_anfitrion');
            for (var i = 0; i < anfitrion.length; i++) {
                anfitrion[i].style.display = 'none';
            }

            var huesped = document.querySelectorAll('.ca_huesped');
            for (var i = 0; i < huesped.length; i++) {
                huesped[i].style.display = 'block';
            }
        });
    </script>
</asp:Content>
