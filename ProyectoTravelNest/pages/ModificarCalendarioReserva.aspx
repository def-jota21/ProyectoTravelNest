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
        <asp:UpdatePanel runat="server" ID="UpdPanel_Modificar" UpdateMode="Conditional">
            <ContentTemplate>
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
                                <asp:DropDownList ID="estadiaMínima" runat="server" CssClass="input-text">
                                    <asp:ListItem Text="Seleciona Opcion" Value="0" />
                                    <asp:ListItem Text="1 día" Value="1" />
                                    <asp:ListItem Text="5 días" Value="2" />
                                    <asp:ListItem Text="10 días" Value="3" />
                                </asp:DropDownList>
                            </div>
                            <div class="label-group">
                                <label for="estadiaMaxima">Estadía Máxima:</label>
                                <asp:DropDownList ID="estadíaMáxima" runat="server" CssClass="input-text">
                                    <asp:ListItem Text="Seleciona Opcion" Value="0" />
                                    <asp:ListItem Text="1 semana" Value="7" />
                                    <asp:ListItem Text="3 meses" Value="14" />
                                    <asp:ListItem Text="1 año" Value="30" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <h2>Anticipación de reserva de los huéspedes.</h2>
                        <div class="form-group">
                            <div class="label-group">
                                <label for="Inmueble">Inmueble:</label>
                                <asp:DropDownList ID="ddlInmueble" runat="server" CssClass="input-text">
                                </asp:DropDownList>
                            </div>
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

                    <div class="label-group">
                        <label for="ddlInmuebles">Selecciona tu Inmueble:</label>
                        <asp:DropDownList ID="ddlInmuebles" runat="server" CssClass="input-text" OnSelectedIndexChanged="ddlConsultarPrecio_Click">
                        </asp:DropDownList>
                        <asp:Button ID="btnConsultarPrecio" runat="server" CssClass="btn btn-success btn-lg" Text="Consultar Precio" OnClick="ddlConsultarPrecio_Click" />
                    </div>

                </div>

                <div class="form-group">
                    <div class="label-group">
                        <label for="PrecioporNoche">Precio por Noche:</label>
                        <asp:TextBox ID="PrecioporNoche" runat="server" CssClass="input-text" placeholder="Precio por Noche"></asp:TextBox>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success btn-lg" OnClick="btnGuardar_Click" OnClientClick="return validatePrecioForm();" />
                <%--<img src="../img/gestionUsuarios.jpg" alt="Imagen" class="right-image" />--%>
                    </div>

                    <div class="message">
                        <asp:Label ID="lblMessage" runat="server" CssClass="success-message" Visible="false" />
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </body>
    </html>

</asp:Content>




