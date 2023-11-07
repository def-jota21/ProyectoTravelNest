<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cotizacion.aspx.cs" Inherits="ProyectoTravelNest.pages.cotizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <link href="../Content/style.css" rel="stylesheet" />
    <div class="container mt-5">
        <div class="row">
            
                <div class="col">
                    <h2>Confirma y Paga</h2>
                    <label for="exampleFormControlInput1" class="form-label mt-4">Fecha Inicio</label>
                    <input type="date" class="form-control" id="txtf_inicio" readonly autocomplete="off">
                    <label for="exampleFormControlInput1" class="form-label mt-2">Fecha Fin</label>
                    <input type="date" class="form-control" id="txtf_fin" readonly autocomplete="off">
                    <label for="exampleFormControlInput1" class="form-label mt-2">Huespedes</label>
                    <input type="number" class="form-control" id="txthuesped" autocomplete="off">
                    <label for="exampleFormControlInput1" class="form-label mt-2">Cupon</label>
                    <input type="text" class="form-control" id="txtcupon" autocomplete="off">
                    <button type="button" class="btn btn-primary mt-4" >Pagar</button>
                </div>
                <div class="col">
                    <div class="card border-light mb-3" style="max-width: 30rem;">
                        <div class="card-header">
                            <div class="container">
                                <div class="row">
                                    <div class="col-4">
                                       
                                        <img class="card-img-top" src="../img/destination-4.jpg" alt="Card image cap" style="border-radius:8px;">
                                    </div>
                                    <div class="col-8">
                                        <label for="exampleFormControlInput1" class="form-label mt-4"><small>Casa de campo entero</small></label>
                                        <label for="exampleFormControlInput1" class="form-label mt-4">Le chaga(#CITQ 297627)</label>
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                        <div class="card-body">
                          <h5 class="card-title">Informacion de Precio</h5>
                          <p class="card-text">$217.98 x 3 noches</p>
                          <p class="card-text">Tarifa de limpieza</p>
                          <p class="card-text">Tarifa por servicio de TravelNest</p>
                          <p class="card-text">Impuestos</p>
                          <hr>
                          <p><strong>Total(USD)</strong></p>
                        </div>
                      </div>
                </div>
            
        </div>  
    </div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
