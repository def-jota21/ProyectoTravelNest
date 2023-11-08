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
            <div class="col-12">
                <div class="card-deck">
                    <div class="card">
                        <a href="#" class="notification" style="text-decoration:none">
                            <span>
                            <h5 class="h5 mt-2">Datos Personales</h5>
                            <p class="h6 mt-4">Proporciona tus datos personales y como podemos contactarte.</p>
                            </span>
                            
                        </a>   
                    </div>
                    
                    
                    <div class="card">
                        <a href="#" class="notification" style="text-decoration:none">
                            <span>
                            <h5 class="h5 mt-2">Inicio de sesion y seguridad</h5>
                            <p class="h6 mt-4">Configura la forma que ingresas.</p>
                            </span>
                            <span class="badgeCard">1</span>
                        </a>   
                    </div>
                    <div class="card">
                        <a href="#" class="notification" style="text-decoration:none">
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
                        <a href="#" class="notification" style="text-decoration:none">
                            <span>
                            <h5 class="h5 mt-2">Notificaciones</h5>
                            <p class="h6 mt-4">Opinion de los anfitriones</p>
                            </span>
                            <span class="badgeCard">2</span>
                        </a>   
                    </div>
                    
                    
                    <div class="card">
                        <a id="miBanco" class="notification" style="text-decoration:none">
                            <span>
                            <h5 class="h5 mt-2">Mi Banco</h5>
                            <p class="h6 mt-4">Proporciona tus datos de tu cuenta para poder hacer el pago.</p>
                            </span>
                            <span class="badgeCard">1</span>
                        </a>   
                    </div>
                    <div class="card">
                        <a href="#" class="notification" style="text-decoration:none">
                            <span>
                            <h5 class="h5 mt-2">Lugares Visitados</h5>
                            <p class="h6 mt-4">Mira los hermosos lugares que has visitado.</p>
                            </span>
                        </a>   
                    </div>
                  </div>
            </div>
        </div>
            
    </div>
    

<!-- Modal Forma de pago -->
<div class="modal fade"  id="miBancoModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header bg-primary text-white">
                <h5 class="modal-title" id="exampleModalLabel">Forma de Pago</h5>
                <button type="button" class=" btn btn-primary" data-bs-dismiss="modal"><i class="fa-solid fa-x" style="color: #000000;"></i></button>
            </div>
            <div class="modal-body">
                <input id="txtid" type="hidden" value="0"/>
                <div class="row  g-2">
                    <div class="col-sm-6">
                        <label for="exampleFormControlInput1" class="form-label">Numero de cuenta</label>
                        <input type="text" class="form-control" id="txtnombres" autocomplete="off">
                    </div>
                    <div class="col-sm-6">
                        <label for="exampleFormControlInput1" class="form-label">Codigo de Seguridad</label>
                        <input type="text" class="form-control" id="txtapellidos" autocomplete="off">
                    </div>
                    
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-primary">Guardar</button>
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
</asp:Content>