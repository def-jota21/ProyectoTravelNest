<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="centroayuda.aspx.cs" Inherits="ProyectoTravelNest.pages.centroayuda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../Content/style.css" rel="stylesheet" />
    <!--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">-->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">



    <div class="container-fluid bg-registration py-5" style="margin: 90px 0;">
        <div class="container py-5">
            <div class="row align-items-center">
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="container pt-5 pb-3">
            <a class="h3 mx-2">Huesped</a>
            <a class="h3">Anfitrión</a>
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 mt-4 mb-4 h-100">
                    <a href="introduccioncentroayuda.aspx">
                        <div class="package-item bg-white mb-2">
                            <img class="img-fluid" src="../img/blog-1.jpg" alt="">
                            <div class="p-4">
                                <a class="h5 text-decoration-none" href="#">Introduccion</a>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 mt-4 mb-4 h-100">
                    <a href="estadiacentroayuda.aspx">
                        <div class="package-item bg-white mb-2">
                            <img class="img-fluid" src="../img/package-5.jpg" alt="">
                            <div class="p-4">
                                <a class="h5 text-decoration-none" href="#">Encuentra una estadia perfecta</a>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 mt-4 mb-4 h-100">
                    <a href="viajecentroayuda.aspx">
                        <div class="package-item bg-white mb-2">
                            <img class="img-fluid" src="../img/package-1.jpg" alt="">
                            <div class="p-4">
                                <a class="h5 text-decoration-none" href="#">Para tu viaje</a>
                            </div>
                        </div>
                    </a>
                </div>
            </div>

        </div>
    </div>
    

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>


</asp:Content>
