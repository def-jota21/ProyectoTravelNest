<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificarcalendarioreserva.aspx.cs" Inherits="ProyectoTravelNest.pages.ModificarCalendarioReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html lang="es">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link href="../Content/ModificarCalendarioReserva.css" rel="stylesheet" />
        <!-- Agregar scripts de Bootstrap y jQuery -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
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
                        <asp:TextBox ID="estadiaMinima" runat="server" CssClass="input-text" placeholder="Ingresar estadía mínima"></asp:TextBox>
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
                        <asp:DropDownList ID="reservaMinima" runat="server" CssClass="input-text">
                            <asp:ListItem Text="Seleciona Opcion" Value="0" />
                            <asp:ListItem Text="1 día" Value="1" />
                            <asp:ListItem Text="5 días" Value="2" />
                            <asp:ListItem Text="10 días" Value="3" />
                        </asp:DropDownList>
                    </div>
                    <div class="label-group">
                        <label for="reservaMaxima">Reserva Máxima:</label>
                        <asp:DropDownList ID="reservaMaxima" runat="server" CssClass="input-text">
                            <asp:ListItem Text="Seleciona Opcion" Value="0" />
                            <asp:ListItem Text="1 semana" Value="7" />
                            <asp:ListItem Text="1 semanas" Value="14" />
                            <asp:ListItem Text="3 mes" Value="30" />
                        </asp:DropDownList>
                    </div>

                    <div style="margin-top: 1rem;">
                        <asp:Button ID="btn_saveTiempo" runat="server" Text="Guardar" CssClass="btn btn-success btn-lg" OnClick="btn_saveTiempo_Click" OnClientClick="return validateTiempoForm();" />
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <h1 class="title">Configura datos calendario de tu Inmueble</h1>
            <h3 class="subtitle">Cambia algunos datos de tu espacio.</h3>

            <%--<div class="label-group">
                <label for="ddlInmuebles">Selecciona tu Inmueble:</label>
                <asp:DropDownList ID="ddlInmuebles" runat="server" CssClass="input-text" OnSelectedIndexChanged="ddlInmuebles_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>--%>

        </div>
        <div class="form-group">
            <div class="label-group">
                <label for="PrecioporNoche">Precio por Noche:</label>
                <asp:TextBox ID="PrecioporNoche" runat="server" CssClass="input-text" placeholder="Precio por Noche"></asp:TextBox>
            </div>
            <div class="text-center">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success btn-lg" OnClick="btnGuardar_Click" OnClientClick="return validatePrecioForm();" />
                <img src="../img/gestionUsuarios.jpg" alt="Imagen" class="right-image" />
            </div>
            <div class="message">
                <asp:Label ID="lblMessage" runat="server" CssClass="success-message" Visible="false" />
            </div>
        </div>
        </div>

    <script>
        function validateTiempoForm() {
            var estadiaMinima = document.getElementById('<%= estadiaMinima.ClientID %>').value;
            var estadiaMaxima = document.getElementById('<%= estadiaMaxima.ClientID %>').value;
            var reservaMinima = document.getElementById('<%= reservaMinima.ClientID %>').value;
            var reservaMaxima = document.getElementById('<%= reservaMaxima.ClientID %>').value;

            // Expresión regular para permitir solo números y letras
            var alphanumericRegex = /^[a-zA-Z0-9]+$/;

            if (estadiaMinima.trim() === '' || estadiaMaxima.trim() === '' || reservaMinima.trim() === '' || reservaMaxima.trim() === '') {
                alert('Todos los campos son obligatorios. Por favor, complete todos los campos.');
                return false;
            } else if (!alphanumericRegex.test(estadiaMinima) || !alphanumericRegex.test(estadiaMaxima) || !alphanumericRegex.test(reservaMinima) || !alphanumericRegex.test(reservaMaxima)) {
                alert('Ingrese solo números y letras en los campos de estadía y reserva.');
                return false;
            }


            function validatePrecioForm() {
                var precioPorNoche = document.getElementById('<%= PrecioporNoche.ClientID %>').value;

                // Regular expression to allow only numbers
                var numberRegex = /^\d+$/;

                if (precioPorNoche.trim() === '') {
                    alert('El campo Precio por Noche es obligatorio. Por favor, complételo.');
                    return false;
                } else if (!numberRegex.test(precioPorNoche)) {
                    alert('Ingrese solo números en el campo Precio por Noche.');
                    return false;
                }

                return true;
            }



    </script>


    </body>
    </html>

</asp:Content>




