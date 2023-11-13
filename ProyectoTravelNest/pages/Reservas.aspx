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
      
      <asp:Label ID="NombreLabel" runat="server" AssociatedControlID="NombreTextBox" CssClass="colocar_nombre">Nombre
        <span class="obligatorio">*</span>
      </asp:Label>
      <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Escribe tu nombre" Required="true" Enabled="false"></asp:TextBox>

      <asp:Label ID="NombreInmuebleLabel" runat="server" AssociatedControlID="NombreInmuebleTextBox" CssClass="colocar_email">Nombre Inmueble
        <span class="obligatorio">*</span>
      </asp:Label>
      <asp:TextBox ID="NombreInmuebleTextBox" runat="server" CssClass="form-control" placeholder="Escribe el nombre del inmueble" Required="true" Enabled="false"></asp:TextBox>

      <asp:Label ID="FechaInicioLabel" runat="server" AssociatedControlID="FechaInicioTextBox" CssClass="colocar_telefono">Fecha Inicio la reservación
      </asp:Label>
      <asp:TextBox ID="FechaInicioTextBox" runat="server" CssClass="form-control" placeholder="Escribe la fecha de inicio" Enabled="false"></asp:TextBox>

      <asp:Label ID="FechaFinalizaLabel" runat="server" AssociatedControlID="FechaFinalizaTextBox" CssClass="colocar_website">Fecha Finaliza la reservación
      </asp:Label>
      <asp:TextBox ID="FechaFinalizaTextBox" runat="server" CssClass="form-control" placeholder="Escribe la fecha de finalización" Enabled="false"></asp:TextBox>

      <asp:Label ID="EstadoLabel" runat="server" AssociatedControlID="EstadoTextBox" CssClass="Estado">Estado
        <span class="obligatorio">*</span>
      </asp:Label>
      <asp:TextBox ID="EstadoTextBox" runat="server" CssClass="form-control" placeholder="Estado Actual" Required="true" Enabled="false"></asp:TextBox>

      <asp:Button ID="VerHistorialButton" runat="server" Text="Ver Historial" CssClass="btn btn-primary btn-block" OnClick="VerHistorialButton_Click" />

    </div>  
  </div>
</body>
</html>


</asp:Content>
