<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCalendarioReserva.aspx.cs" Inherits="ProyectoTravelNest.pages.ModificarCalendarioReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
<div class="container">
  <h1 class="title">Configura tu calendario</h1>
    <link href="../Content/ModificarCalendarioReserva.css" rel="stylesheet" />
      </head>
    <body>
  <h3 class="subtitle">Utiliza la configuración de disponibilidad para personalizar cómo y cuándo quieres compartir tu espacio.</h3>

<div class="row">
  <div class="col-md-6">
    <h2>Tiempo de estadía</h2>
    <div class="form-group">
      <div class="label-group">
        <label for="estadiaMinima">Estadía Mínima:</label>
        <input type="text" class="input-text" id="estadiaMinima" placeholder="Ingresar estadía mínima">
      </div>
      <div class="label-group">
        <label for="estadiaMaxima">Estadía Máxima:</label>
        <input type="text" class="input-text" id="estadiaMaxima" placeholder="Ingresar estadía máxima">
      </div>
    </div>
  </div>
  <div class="col-md-6">
    <h2>Anticipacion de reserva de los huespedes.</h2>
    <div class="form-group">
      <div class="label-group">
        <label for="reservaMinima">Reserva Mínima:</label>
        <select class="input-text" id="reservaMinima">
          <option>1 día</option>
          <option>2 días</option>
          <option>3 días</option>
        </select>
      </div>
      <div class="label-group">
        <label for="reservaMaxima">Reserva Máxima:</label>
        <select class="input-text" id="reservaMaxima">
          <option>1 semana</option>
          <option>2 semanas</option>
          <option>1 mes</option>
        </select>
      </div>
    </div>
  </div>
</div>
    <div class="p-link">
    <h2>Configura fechas especificas.</h2>
      <p>Ir a calendario: <a href="ruta_del_calendario">Calendario</a></p>
    </div>
  </div>
  <div class="text-center">
    <button type="submit" class="btn btn-success btn-lg" id="btnGuardar">Guardar</button>
  </div>
  </body>
 </html>
</asp:Content>
