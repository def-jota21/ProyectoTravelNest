<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="datospersonales.aspx.cs" Inherits="ProyectoTravelNest.pages.DatosPersonales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <div class="container mt-5">
        <h2>Informacion Personal</h2>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtid" CssClass="form-label mt-4">Identificacion</asp:Label>
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="txtid" CssClass="form-control" autocomplete="off" ReadOnly="true"></asp:TextBox>
                        <a href="#" id="editarIdentificacion" data-bs-toggle="modal" data-bs-target="#modalIdentificacion" class="text-danger mx-2">Modificar</a>
                    </div>

                    <asp:Label runat="server" AssociatedControlID="txtnombres" CssClass="form-label mt-2">Nombre</asp:Label>
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="txtnombres" CssClass="form-control" autocomplete="off" ReadOnly="true"></asp:TextBox>
                        <a href="#" id="editarnombres" data-bs-toggle="modal" data-bs-target="#modalNombre" class="text-danger mx-2">Modificar</a>
                    </div>
                    <asp:Label runat="server" AssociatedControlID="txtapellidos" CssClass="form-label mt-2">Apellidos</asp:Label>
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="txtapellidos" CssClass="form-control" autocomplete="off" ReadOnly="true"></asp:TextBox>
                        <a href="#" id="editarapellidos" data-bs-toggle="modal" data-bs-target="#modalApellidos" class="text-danger mx-2">Modificar</a>
                    </div>
                    <asp:Label runat="server" AssociatedControlID="txtcorreo" CssClass="form-label mt-2">Correo</asp:Label>
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="txtcorreo" CssClass="form-control" autocomplete="off" ReadOnly="true"></asp:TextBox>
                        <a href="#" id="editarcorreo" data-bs-toggle="modal" data-bs-target="#modalCorreo" class="text-danger mx-2">Modificar</a>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="txttelefono" CssClass="form-label mt-2">Telefono</asp:Label>
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" autocomplete="off" ReadOnly="true"></asp:TextBox>
                        <a href="#" id="editartelefono" data-bs-toggle="modal" data-bs-target="#modalTelefono" class="text-danger mx-2">Modificar</a>
                </div>

                <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-primary mt-4" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>


    <!-- Modal para Identificacion -->
    <div class="modal fade" id="modalIdentificacion" tabindex="-1" aria-labelledby="modalIdentificacionLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalIdentificacionLabel">Modificar Identificación</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <!-- Aquí va el formulario para modificar -->
                    <label for="modalTxtId" class="form-label">Identificación</label>
                    <input type="text" class="form-control" id="modalTxtId">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary"  data-bs-dismiss="modal">Aceptar</button>
                   
                </div>
            </div>
        </div>
    </div>

    <!-- Modal para Nombre -->
    <div class="modal fade" id="modalNombre" tabindex="-1" aria-labelledby="modalNombreLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalNombreLabel">Modificar Nombre</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <!-- Formulario para modificar el Nombre -->
                    <label for="modalTxtNombre" class="form-label">Nombre</label>
                    <input type="text" class="form-control" id="modalTxtNombre">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary"  data-bs-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal para Correo -->
    <div class="modal fade" id="modalCorreo" tabindex="-1" aria-labelledby="modalCorreoLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalCorreoLabel">Modificar Correo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <!-- Formulario para modificar el Correo -->
                    <label for="modalTxtCorreo" class="form-label">Correo Electrónico</label>
                    <input type="email" class="form-control" id="modalTxtCorreo">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Aceptar</button>
                   

                </div>
            </div>
        </div>
    </div>

    <!-- Modal para Teléfono -->
    <div class="modal fade" id="modalTelefono" tabindex="-1" aria-labelledby="modalTelefonoLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalTelefonoLabel">Modificar Teléfono</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <!-- Formulario para modificar el Teléfono -->
                    <label for="modalTxtTelefono" class="form-label">Número de Teléfono</label>
                    <input type="text" class="form-control" id="modalTxtTelefono">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Aceptar</button>
                    
                </div>
            </div>
        </div>
    </div>

    <!-- Modal para Apellidos -->
    <div class="modal fade" id="modalApellidos" tabindex="-1" aria-labelledby="modalApellidosLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalApellidosLabel">Modificar Apellidos</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <!-- Formulario para modificar la Dirección -->
                    <label for="modalTxtApellidos" class="form-label">Apellidos</label>
                    <textarea class="form-control" id="modalTxtApellidos"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script>
        document.getElementById("editarIdentificacion").addEventListener("click", function () {
            var TxtId = document.getElementById("<%= txtid.ClientID %>");
            $('#modalTxtId').val(TxtId.value);
        });

        document.getElementById("editarnombres").addEventListener("click", function () {
            var txtNombres = document.getElementById("<%= txtnombres.ClientID %>");
            $('#modalTxtNombre').val(txtNombres.value);
        });

        document.getElementById("editarapellidos").addEventListener("click", function () {
            var txtApellidos = document.getElementById("<%= txtapellidos.ClientID %>");
            $('#modalTxtApellidos').val(txtApellidos.value);
        });

        document.getElementById("editartelefono").addEventListener("click", function () {
            var TxtTelefono = document.getElementById("<%= txtTelefono.ClientID %>");
            $('#modalTxtTelefono').val(TxtTelefono.value);
        });

        // Agregar lógica para copiar los valores de vuelta al campo original al hacer clic en "Aceptar"
        $('#modalIdentificacion button.btn-primary').click(function () {
            var TxtId = document.getElementById("<%= txtid.ClientID %>");
            TxtId.value = $('#modalTxtId').val();
        });

        $('#modalApellidos button.btn-primary').click(function () {
            var TxtApellidos = document.getElementById("<%= txtapellidos.ClientID %>");
            TxtApellidos.value = $('#modalTxtApellidos').val();
        });

        $('#modalNombre button.btn-primary').click(function () {
            var txtNombres = document.getElementById("<%= txtnombres.ClientID %>");
            txtNombres.value = $('#modalTxtNombre').val();
        });

        $('#modalCorreo button.btn-primary').click(function () {
            var txtCorreo = document.getElementById("<%= txtcorreo.ClientID %>");
            txtCorreo.value = $('#modalTxtCorreo').val();
        });

        $('#modalTelefono button.btn-primary').click(function () {
            var TxtTelefono = document.getElementById("<%= txtTelefono.ClientID %>");
            TxtTelefono.value = $('#modalTxtTelefono').val();
        });
    </script>



</asp:Content>

