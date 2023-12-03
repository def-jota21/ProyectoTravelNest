﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="paneladministracionhuesped.aspx.cs" Inherits="ProyectoTravelNest.pages.paneladministracionhuesped" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">


    <style>
        .notification {
            color: white;
            text-decoration: none;
            padding: 15px 26px;
            position: relative;
            display: inline-block;
            border-radius: 4px;
        }

            .notification .badgeCard {
                position: absolute;
                top: -10px;
                right: -10px;
                padding: 5px 10px;
                border-radius: 70%;
                background: red;
                color: white;
            }
    </style>
    <div class="container-fluid bg-registration py-5" style="margin: 90px 0;">
        <div class="container py-5">
            <div class="row align-items-center">
            </div>
        </div>
    </div>

    <div class="container mt-5">
        <div class="row">
            <h2 class="mb-3">Panel Huesped</h2>
            <div class="col-12">
                <div class="card-deck">
                    <div class="card">
                        <a href="datospersonales.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Datos Personales</h5>
                                <p class="h6 mt-4">Proporciona tus datos personales y como podemos contactarte.</p>
                            </span>

                        </a>
                    </div>


                    <div class="card">
                        <a href="sesionyseguridad.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Inicio de sesion y seguridad</h5>
                                <p class="h6 mt-4">Configura la forma que ingresas.</p>
                            </span>
                            <span class="badgeCard"><i class="fa-solid fa-triangle-exclamation"></i></span>
                        </a>
                    </div>
                    <div class="card">
                        <a href="centrodeayuda.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Centro de Ayuda</h5>
                                <p class="h6 mt-4">Te ayudamos en lo que necesites</p>
                            </span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-12">
                <div class="card-deck">
                    <div class="card">
                        <a href="comentariospendientesh.aspx" class="notification" style="text-decoration: none">

                            <h5 class="h5 mt-2">Comentarios</h5>
                            <p class="h6 mt-4">Comentarios Pendientes</p>
                            <% 
                                int cantidadNotificaciones = (Session["CantidadNotificaciones"] != null) ? (int)Session["CantidadNotificaciones"] : 0;
                                if (cantidadNotificaciones > 0)
                                {
                            %>
                            <span class="badgeCard"><%= cantidadNotificaciones %></span>
                            <% 
                                }
                            %>
                        </a>
                    </div>


                    <div class="card">
                        <% 
                            bool usuarioMiBanco = (Session["MiBancoUsuario"] != null) ? (bool)Session["MiBancoUsuario"] : false;

                            if (usuarioMiBanco)
                            {
                        %>
                        <a href="eliminarCuentaMiBanco.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Mi Banco</h5>
                                <p class="h6 mt-4">Proporciona tus datos de tu cuenta para poder hacer el pago.</p>
                            </span>
                        </a>
                        <% 
                            }
                            else
                            {
                        %>
                        <a href="agregarmibanco.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Mi Banco</h5>
                                <p class="h6 mt-4">Proporciona tus datos de tu cuenta para poder hacer el pago.</p>
                            </span>
                            <span class="badgeCard"><i class="fa-solid fa-triangle-exclamation"></i></span>
                        </a>
                        <% 
                            }
                        %>
                    </div>
                    <div class="card">
                        <a href="alojamientosvisitados.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Lugares Visitados</h5>
                                <p class="h6 mt-4">Mira los hermosos lugares que has visitado.</p>
                            </span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-12">

                <div class="card-deck">

                    <div class="card">
                        <a href="recepcionmensajes.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Mensajes</h5>
                                <p class="h6 mt-4">Conversa con los demas usuarios encargados de tu alojamiento.</p>
                            </span>
                        </a>
                    </div>



                    <div class="card">
                        <a href="recepciondedenuncias.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">
                                    <h5 class="h5 mt-2">Denuncias</h5>
                                    <p class="h6 mt-4">Realiza tus denuncias.</p>
                            </span>
                        </a>
                    </div>
                    <div class="card">
                        <a href="consultadenuncias.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Recepcion de denuncias</h5>
                                <p class="h6 mt-4">Aqui puedes ver las denuncias realizadas.</p>
                            </span>
                        </a>
                    </div>

                </div>
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-12">
                <div class="card-deck">

                    <div class="card">
                        <asp:LinkButton runat="server" ID="lbtnVId" Style="text-decoration: none" OnClick="lbtnVId_Click" CssClass="notification">
                            <span>
                                <h5 class="h5 mt-2">Verificar identificación</h5>
                                <p class="h6 mt-4">Confirma tu identidad con una foto de tu rostro y documento.</p>
                            </span>
                        </asp:LinkButton>
                    </div>
                    
                                <div class="card">
                                    <a href="cuponeshuesped.aspx" class="notification" style="text-decoration: none">
                                        <span>
                                            <h5 class="h5 mt-2">Cupones Disponibles</h5>
                                            <p class="h6 mt-4">Observa sí tienes algún cupon disponible.</p>
                                        </span>
                                    </a>
                                </div>
   

                    <div class="card">
                        <a href="pantallapoliticas.aspx" class="notification" style="text-decoration: none">
                            <span>
                                <h5 class="h5 mt-2">Politicas Travel Nest</h5>
                                <p class="h6 mt-4">Hecha un vistaso a las reglas y nomras de nuestra aplicacion.</p>
                            </span>
                        </a>
                    </div>
                    </div>
                </div>
            </div>

 




                </div>

                <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
                <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
                <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

                <script>
                    document.getElementById("miBanco").addEventListener("click", function () {

                        $('#miBancoModal').modal("show");

                    });
                </script>
    </span>
</asp:Content>
