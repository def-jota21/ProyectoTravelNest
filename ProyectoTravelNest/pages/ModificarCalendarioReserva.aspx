﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificarcalendarioreserva.aspx.cs" Inherits="ProyectoTravelNest.pages.ModificarCalendarioReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link href="../Content/ModificarCalendarioReserva.css" rel="stylesheet" />
    </head>
    <body>
        <div class="container">
            <h1 class="title">Configura calendario de tu Inmueble</h1>
        </div>
        <h3 class="subtitle">Utiliza la configuración de disponibilidad para personalizar cómo y cuándo quieres compartir tu espacio.</h3>

        <div class="row">
            <div class="col-md-6">
                <h2>Tiempo de estadía</h2>
                <div class="form-group">
                    <div class="label-group">
                        <label for="estadiaMinima">Estadía Mínima:</label>
                        <asp:TextBox ID="estadiaMinima" runat="server" CssClass="input-text" placeholder="Ingresar estadía mínima" OnTextChanged="estadiaMinima_TextChanged"></asp:TextBox>
                    </div>
                    <div class="label-group">
                        <label for="estadiaMaxima">Estadía Máxima:</label>
                        <asp:TextBox ID="estadiaMaxima" runat="server" CssClass="input-text" placeholder="Ingresar estadía máxima"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <h2>Anticipación de reserva de los huéspedes.</h2>
                <div class="form-group">
                    <div class="label-group">
                        <label for="reservaMinima">Reserva Mínima:</label>
                        <asp:DropDownList ID="reservaMinima" runat="server" CssClass="input-text" OnSelectedIndexChanged="reservaMinima_SelectedIndexChanged">
                             <asp:ListItem Text="Seleciona Opcion" Value="0" />
                            <asp:ListItem Text="1 día" Value="1" />
                            <asp:ListItem Text="2 días" Value="2" />
                            <asp:ListItem Text="3 días" Value="3" />
                        </asp:DropDownList>
                    </div>
                    <div class="label-group">
                        <label for="reservaMaxima">Reserva Máxima:</label>
                        <asp:DropDownList ID="reservaMaxima" runat="server" CssClass="input-text">
                            <asp:ListItem Text="Seleciona Opcion" Value="0" />
                            <asp:ListItem Text="1 semana" Value="7" />
                            <asp:ListItem Text="2 semanas" Value="14" />
                            <asp:ListItem Text="1 mes" Value="30" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <h1 class="title">Configura datos calendario de tu Inmueble</h1>
            <h3 class="subtitle">Cambia algunos datos de tu espacio.</h3>

            <div class="form-group">
                <div class="label-group">
                    <label for="PrecioporNoche">Precio por Noche:</label>
                    <asp:TextBox ID="PrecioporNoche" runat="server" CssClass="input-text" placeholder="Precio por Noche" OnTextChanged="PrecioporNoche_TextChanged"></asp:TextBox>
                </div>
                <div class="label-group">
                    <label for="Descuento">Descuento:</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input-text" OnSelectedIndexChanged="Descuento_SelectedIndexChanged">
                        <asp:ListItem Text="Seleciona Opcion" Value="0" />
                        <asp:ListItem Text="15%" Value="1" />
                        <asp:ListItem Text="25%" Value="2" />
                        <asp:ListItem Text="50%" Value="3" />
                    </asp:DropDownList>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success btn-lg" OnClick="btnGuardar_Click" />
                </div>
                <div class="message">
                    <asp:Label ID="lblMessage" runat="server" CssClass="success-message" Visible="false" />
                </div>
            </div>
        </div>
    </body>
</html>
</asp:Content>



