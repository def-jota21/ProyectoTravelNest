<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sesionyseguridad.aspx.cs" Inherits="ProyectoTravelNest.pages.sesionyseguridad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
                <h2>Inicio Sesión y Seguridad</h2>
                <asp:Label runat="server" AssociatedControlID="txtcontraseña" CssClass="form-label mt-4">Contraseña</asp:Label>
                <div class="input-group">
                    <asp:TextBox runat="server" ID="txtcontraseña" CssClass="form-control" autocomplete="off" TextMode="Password" ReadOnly="false" placeholder="Ingrese nueva contraseña"></asp:TextBox>
                    <a href="#" id="editarContraseña" data-bs-toggle="modal" data-bs-target="#modalContraseña" class="text-danger mx-2">Modificar</a>

                </div>

                <label for="exampleFormControlInput1" class="form-label mt-2">Ultima Actualizacion hace 23 dias</label>
                <h4 class="mt-4">Historial del Dispositivo</h4>
                <label for="exampleFormControlInput1" class="form-label mt-2">Nombre del Dispositivo</label>
                <h4 class="mt-4">Cuenta</h4>
                <label for="exampleFormControlInput1" class="form-label mt-4">Desactivar la cuenta</label>
                <a href="#" id="desactivarcuenta" data-bs-toggle="modal" data-bs-target="#modalDesactivarCuenta" class="stretched-link text-danger mx-5" style="position: relative;">Desactivar</a>
            </div>

        </div>
        <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-primary mt-4" Text="Guardar" OnClick="btnGuardar_Click" />

    </div>




    <!-- Modal para Contraseña -->
    <div class="modal fade" id="modalContraseña" tabindex="-1" aria-labelledby="modalContraseñaLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalContraseñaLabel">Modificar Contraseña</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <!-- Aquí va el formulario para modificar -->
                    <label for="modalTxtContraseñaActual" class="form-label">Nueva Contraseña:</label>
                    <input type="text" class="form-control" id="modalTxtContraseñaActual">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
        </div>
        <!-- Modal para Desactivar Cuenta -->
        <div class="modal fade" id="modalDesactivarCuenta" tabindex="-1" aria-labelledby="modalDesactivarCuentaLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalDesactivarCuentaLabel">Desactivar Cuenta</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                         <p>¿Estás seguro de que deseas desactivar tu cuenta?.</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <asp:Button ID="btnConfirmarDesactivacion" runat="server" CssClass="btn btn-danger" OnClick="btnConfirmarDesactivacion_Click" Text="Desactivar Cuenta" />
                    </div>
                </div>
            </div>
        </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#editarContraseña").on("click", function () {
                var TxtContraseña = $("#<%= txtcontraseña.ClientID %>").val();
                $('#modalTxtContraseñaActual').val(TxtContraseña);
            });

            $('#modalContraseña').on('click', 'button.btn-primary', function () {
                var updatedContraseña = $('#modalTxtContraseñaActual').val();
                $("#<%= txtcontraseña.ClientID %>").val(updatedContraseña);
          });
        });


    </script>

</asp:Content>
