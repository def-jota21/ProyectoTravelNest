<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reservas.aspx.cs" Inherits="ProyectoTravelNest.pages.Reservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Formulario de contacto</title>
  <link href="../Content/Reservaciones.css" rel="stylesheet" />

</head>
<body>  
  <div class="contact_form">
    <div class="formulario">      
      <h1>Datos De Tu Reservación</h1>
      <h3>Aquí te mostramos los datos de tu reservación más reciente</h3>
      <form action="submeter-formulario.php" method="post">       
        <p>
          <label for="Nombre" class="colocar_nombre">Nombre
            <span class="obligatorio">*</span>
          </label>
          <input type="text" name="Nombre" id="Nombre" required="obligatorio" placeholder="Escribe tu nombre">
        </p>
        <p>
          <label for="NombreInmueble" class="colocar_email">Nombre Inmueble
            <span class="obligatorio">*</span>
          </label>
          <input type="text" name= "NombreInmueble" id="NombreInmueble" required="obligatorio" placeholder="Escribe el nombre del inmueble">
        </p>
        <p>
          <label for="FechaInicio" class="colocar_telefono">Fecha Inicio la reservación
          </label>
          <input type="text" name="FechaInicio" id="FechaInicio" placeholder="Escribe la fecha de inicio">
        </p>    
        <p>
          <label for="FechaFinaliza" class="colocar_website">Fecha Finaliza la reservación
          </label>
          <input type="text" name="FechaFinaliza" id="FechaFinaliza" placeholder="Escribe la fecha de finalización">
        </p>    
        <p>
          <label for="Estado" class="Estado">Estado
            <span class="obligatorio">*</span>
          </label>
          <input type="text" name="Estado" id="Estado" required="obligatorio" placeholder="Estado Actual">
        </p>
        <button type="submit" name="VerHistorial" id="VerHistorial"><p>Ver Historial</p></button>         
      </form>
    </div>  
  </div>
</body>
</html>
</asp:Content>
