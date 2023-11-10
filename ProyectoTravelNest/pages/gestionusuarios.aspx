<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gestionusuarios.aspx.cs" Inherits="ProyectoTravelNest.pages.gestionusuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta charset="utf-8">
    <title>TRAVELER - Free Travel Website Template</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta content="Free HTML Templates" name="keywords">
    <meta content="Free HTML Templates" name="description">

    <!-- Favicon -->
    <link href="img/favicon.ico" rel="icon">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;500;600;700&display=swap" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css"
        integrity="sha512-z3gLpd7yknf1YoNbCzqRKc4qyor8gaKU1qmn+CShxbuBusANI9QpRohGBreCFkKxLhei6S9CQXFEbbKuqLg0DA=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />

    <!-- Libraries Stylesheet -->
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>

    <link href="../Content/styleComentariosPendientes.css" rel="stylesheet" />

    <!-- Customized Bootstrap Stylesheet -->
    <style>
        .center-content {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        .btn-primary {
            color: #fff;
            background-color: #7AB730;
            border-color: #7AB730;
        }

        #txtcomentarioPrivado {
            resize: none;
        }

        #txtcomentarioPublico {
            resize: none;
        }

        .center-cont {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: auto;
            color: black;
        }
    </style>
    <div class="container">
        <img src="../img/covergestionusuarios.jpg" alt="" class="img-fluid">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-12 col-sm-12 my-2">
                    <table class="table table-responsive-md table-bordered border-dark table-hover text-center">
                        <thead>
                            <tr class="table-dark table-active text-white">
                                <th scope="col">Identificador</th>
                                <th scope="col">Nombre</th>
                                <th scope="col">Estado</th>
                                <th scope="col">Acción</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptDatosUsuarios" runat="server">
                                <ItemTemplate>
                                    <td><%# Eval("IdUsuario") %></td>
                                    <td><%# Eval("Nombre") %></td>
                                    <td><%# Eval("Estado") %></td>
                                    <td>
                                        <div style="text-align: center">
                                            <asp:LinkButton runat="server" ID="btnAbrirModalEditar" CssClass="btn" OnClientClick='<%# Eval("IdUsuario", "return mostrarModalEditar(\"{0}\"); return false;") %>'>
                                                <i class="fa-solid fa-pen-to-square" style="color: #7AB730;"></i>
                                            </asp:LinkButton>


                                        </div>
                                    </td>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

                <div class="col-lg-4 col-md-12 col-sm-12 my-2 d-flex align-items-center">
                    <div class="w-100">
                        <img src="../img/gestionUsuarios.jpg" alt="" class="img-fluid">
                    </div>
                </div>
            </div>
        </div>



    </div>


    <!-- Modal Editar Datos-->
    <div class="modal fade" id="editarDatosModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true"
        data-bs-backdrop="static">
        <div class="modal-dialog" style="z-index: 2000;">
            <div class="modal-content ">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="ModalCrearCuenta">Editar Datos</h5>
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">
                        <i class="fa-solid fa-x"
                            style="color: #000000;"></i>
                    </button>
                </div>
                <div class="modal-body center-cont">
                    <div class="row col-lg-12 col-sm-12 text-center">
                        <div class="col-sm-12 col-lg-12">
                            <img src="../img/logo2.png" alt="logo" class="img-fluid">
                        </div>
                        <asp:HiddenField runat="server" ID="hiddenFieldIdentificacion" />
                        <div class="col-sm-12 col-lg-6 mt-2">
                            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" CssClass="form-label">Nombre</asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" AutoComplete="off" placeholder="Nombre"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                ErrorMessage="El campo Nombre es requerido." Display="Dynamic" CssClass="text-danger" />
                        </div>

                        <div class="col-sm-12 col-lg-6 mt-2">
                            <asp:Label ID="lblCorreoElectronico" runat="server" AssociatedControlID="txtCorreoElectronico" CssClass="form-label">Correo Electrónico</asp:Label>
                            <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control" AutoComplete="off" placeholder="alguien@ejemplo.com"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCorreoElectronico" runat="server" ControlToValidate="txtCorreoElectronico"
                                ErrorMessage="El campo Correo Electrónico es requerido." Display="Dynamic" CssClass="text-danger" />
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            
                      
                            <asp:Label ID="lblIdentificacion" runat="server" AssociatedControlID="txtIdentificacion" CssClass="form-label">Identificación</asp:Label>
                            <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control" MaxLength="11" aria-describedby="idHelp"
                                placeholder="1-1111-1111"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdentificacion" runat="server" ControlToValidate="txtIdentificacion"
                                ErrorMessage="El campo Identificación es requerido." Display="Dynamic" CssClass="text-danger" />
                            <small id="idHelpIdentificacion" class="form-text text-muted">El formato debe ser #-####-####</small>
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <asp:Label ID="lblApellidos" runat="server" AssociatedControlID="txtApellidos" CssClass="form-label">Apellidos</asp:Label>
                            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" AutoComplete="off" placeholder="Apellidos"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvApellidos" runat="server" ControlToValidate="txtApellidos"
                                ErrorMessage="El campo Apellidos es requerido." Display="Dynamic" CssClass="text-danger" />
                        </div>

                        <div class="col-sm-6 col-lg-6 mt-2">
                            <asp:Label ID="lblTelefono" runat="server" AssociatedControlID="txtTelefono" CssClass="form-label">Teléfono</asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" AutoComplete="off" placeholder="88888888"
                                pattern="[0-9]{4}[0-9]{4}"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono"
                                ErrorMessage="El campo Teléfono es requerido." Display="Dynamic" CssClass="text-danger" />
                            <small id="idHelp" class="form-text text-muted">El formato debe ser ########</small>
                        </div>
                        <div class="col-sm-12 col-lg-6 mt-2">
                            <asp:Label ID="lblEstado" runat="server" AssociatedControlID="ddlEstado" CssClass="form-label">Estado</asp:Label>
                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                                <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-12 col-lg-12">
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary btn-block"
                                Style="height: 47px; margin-top: -2px;" OnClick="btnEditar_Click" />
                        </div>


                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- JavaScript Libraries -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"
        crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.7.0.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
    <!-- Contact Javascript File -->
    <script src="mail/jqBootstrapValidation.min.js"></script>
    <script src="mail/contact.js"></script>

    <!-- Template Javascript -->
    <script src="js/main.js"></script>


    <script type="text/javascript">
        function mostrarModalEditar(idUsuario) {
            // Asigna el valor de identificación al campo oculto del modal
            document.getElementById('<%= hiddenFieldIdentificacion.ClientID %>').value = idUsuario;

            // Llama al controlador genérico para obtener los datos del usuario
            $.ajax({
                type: "GET",
                url: "../obtenerdatousuario.ashx?idUsuario=" + idUsuario,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    // Verifica si hay al menos un objeto en el array
                    if (data.length > 0) {
                        // Accede al primer objeto del array
                        var usuario = data[0];

                        // Llena los campos del modal con los datos obtenidos
                        document.getElementById('<%= txtNombre.ClientID %>').value = usuario.Nombre;
                        document.getElementById('<%= txtCorreoElectronico.ClientID %>').value = usuario.Correo;
                        document.getElementById('<%= txtIdentificacion.ClientID %>').value = usuario.IdUsuario;
                        document.getElementById('<%= txtApellidos.ClientID %>').value = usuario.Apellidos;
                        document.getElementById('<%= txtTelefono.ClientID %>').value = usuario.Telefono;
                        // ... repite para otros campos

                        // Selecciona el valor correcto en el DropDownList
                        var ddlEstado = document.getElementById('<%= ddlEstado.ClientID %>');
                        for (var i = 0; i < ddlEstado.options.length; i++) {
                            if (ddlEstado.options[i].value === usuario.Estado) {
                                ddlEstado.options[i].selected = true;
                                break;
                            }
                        }

                        // Muestra el modal
                        $('#editarDatosModal').modal("show");
                    } else {
                        console.log("No se encontraron datos para el usuario con ID " + idUsuario);
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
    </script>





</asp:Content>
