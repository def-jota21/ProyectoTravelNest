<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="datospersonales.aspx.cs" Inherits="ProyectoTravelNest.pages.DatosPersonales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
        <div class="container mt-5">
        <h2>Informacion Personal</h2>
        <div class="row">
                <div class="col">
                    
                    <label for="exampleFormControlInput1" class="form-label mt-4">Identificacion</label>
                    <input type="number" class="form-control" id="txtid" autocomplete="off">
                    <label for="exampleFormControlInput1" class="form-label mt-2">Nombre</label>
                    <input type="text" class="form-control" id="txtnombres"  autocomplete="off">
                    <label for="exampleFormControlInput1" class="form-label mt-2">Correo</label>
                    <input type="email" class="form-control" id="txtcorreo" autocomplete="off">
                    <label for="exampleFormControlInput1" class="form-label mt-2">Telefono</label>
                    <input type="text" class="form-control" id="txttelefono" autocomplete="off">
                    
                </div>
                <div class="col">
                    <label for="exampleFormControlInput1" class="form-label mt-4">Direccion</label>
                    <textarea type="text" class="form-control" id="txtdireccion" autocomplete="off"></textarea>
                    <button type="button" class="btn btn-primary mt-4" >Guardar</button>
                </div>
            
        </div>  
    </div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>

