<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="elegirinmueble.aspx.cs" Inherits="ProyectoTravelNest.pages.elegirinmueble" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/stylesInmueble.css" rel="stylesheet" />
    <div class="container" style="margin-top: 6vh;">
        <h1 runat="server" id="h1_titulo">Agregar, modificar o eliminar</h1>
        <h5>Seleccione el inmueble.</h5>

        <!-- Cartas -->

        <div class="container-fluid mt-5">
            <div class="row" id="row" runat="server">
                <%--<!-- Carta #1 -->
                <div class="col-lg-3 col-md-5 p-0 mb-5 me-4 bg-white rounded">
                    <a href="#" class="text-decoration-none" style="color: initial;">
                        <div class="package-item bg-white mb-2">
                            <img class="img-fluid" src="../img/inmueble.jpg" style="border-radius: 7px;">
                            <div style="clear: both;">
                                <h5 class="ms-1">Islas Canarias</h5>
                                <label class="text-muted">Lorem ipsum dolor sit amet consectetur adipisicing elit.
                                    Vero quae ipsum quas accusantium eum, consectetur...</label>
                                <div class="border-top mt-4 pt-4">
                                    <div class="d-flex justify-content-around">
                                        <h6 class="m-0"><i class="fa fa-star text-primary"></i>4.5
                                            <small>(250)</small></h6>
                                        <h5 class="m-0">$350</h5>
                                        <p><b>por noche</b></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>

                <!-- ! Mas cartas -->
                <!-- Carta #2 -->
                <div class="col-lg-3 col-md-5 p-0 mb-5 me-4 bg-white rounded">
                    <a href="#" class="text-decoration-none" style="color: initial;">
                        <div class="package-item bg-white mb-2">
                            <img class="img-fluid" src="../img/inmueble.jpg" style="border-radius: 7px;">
                            <div style="clear: both;">
                                <h5 class="ms-1">Islas Canarias</h5>
                                <label class="text-muted">Lorem ipsum dolor sit amet consectetur adipisicing elit.
                                    Vero quae ipsum quas accusantium eum, consectetur...</label>
                                <div class="border-top mt-4 pt-4">
                                    <div class="d-flex justify-content-around">
                                        <h6 class="m-0"><i class="fa fa-star text-primary"></i>4.5
                                            <small>(250)</small></h6>
                                        <h5 class="m-0">$350</h5>
                                        <p><b>por noche</b></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>--%>



                
            </div>
        </div>


    </div>
</asp:Content>
