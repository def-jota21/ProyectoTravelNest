<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gestionpoliticas.aspx.cs" Inherits="ProyectoTravelNest.pages.gestionpoliticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

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

        #seccionEdicion {
            display: none;
            color: black;
            border: 2px dotted #7AB730; /* Color del borde */
            padding: 20px; /* Espacio interior para que no esté pegado el contenido al borde */
            margin-top: 20px; /* Espacio exterior superior */
            border-radius: 10px; /* Bordes redondeados */
            background-color: #f9f9f9; /* Color de fondo */
        }

        #seccionAgregar {
            display: none;
            color: black;
            border: 2px dotted #7AB730; /* Color del borde */
            padding: 20px; /* Espacio interior para que no esté pegado el contenido al borde */
            margin-top: 20px; /* Espacio exterior superior */
            border-radius: 10px; /* Bordes redondeados */
            background-color: #f9f9f9; /* Color de fondo */
        }
    </style>

    <div class="container">
        <h1 style="color: #7AB730;">Administrar Políticas</h1>
        <p style="color: dimgrey;">En la tabla se le muestran las polítcas de su alojamiento, podrá editarlas.</p>
        <p style="color: dimgrey;">Podrá presionar el botón agregar si desea agregar una nueva política.</p>
        <div class="row">
            <div class="col-lg-8 col-md-12 col-sm-12 my-2">
                <div class="row" style="margin-top: 5px; margin-bottom: 15px; max-width: 200px; margin-left: 2px;">
                    <button onclick="prepararAgregar(); return false;" class="btn btn-primary">Agregar Política&nbsp;<i class="fa-solid fa-plus" style="color: white;"></i></button>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="table table-responsive-md table-responsive-lg table-bordered border-dark table-hover text-center">
                            <thead>
                                <tr class="table-dark table-active text-white">
                                    <th scope="col">Identificador</th>
                                    <th scope="col">Política</th>
                                    <th scope="col">Comentario</th>
                                    <th scope="col">Acción</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptPoliticas" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("idPoliticaxInmueble") %></td>
                                            <td><%# Eval("Nombre") %></td>
                                            <td><%# Eval("Comentario") %></td>
                                            <td>
                                                <div style="text-align: center">
                                                    <button onclick="prepararEdicion('<%# Eval("idPoliticaxInmueble") %>'); return false;" class="btn btn-primary"><i class="fa-solid fa-pen-to-square" style="color: white;"></i></button>
                                                </div>

                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div class="col-lg-8 col-md-12 col-sm-12 my-2">
                            <div id="seccionEdicion" style="display: none; color: black">
                                <!-- Formulario de Edición -->

                                <!-- Agrega más campos según sea necesario -->
                                <div class="row justify-content-center">
                                    <asp:HiddenField ID="hiddenField1" runat="server" />
                                    <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" CssClass="form-label">Nombre de la politica</asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" Rows="7" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                </div>

                                <div class="row">
                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtComentario" CssClass="form-label">Comentario de la politica</asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtComentario" TextMode="MultiLine" Rows="7" MinLength="10" MaxLength="60"></asp:TextBox>

                                </div>

                                <div class="row" style="margin-top: 5px; margin-bottom: 5px;">
                                    <asp:Button ID="btnEliminar" runat="server" AutoPostBack="false" Text="Eliminar Política" OnClick="btnEliminar_Click" CssClass="btn btn-danger me-2" />

                                </div>
                                <div class="row" style="margin-top: 5px; margin-top: 10px;">
                                    <asp:Button ID="Button1" AutoPostBack="false" runat="server" Text="Guardar Cambios" OnClick="btnGuardarCambios_Click" CssClass="btn btn-primary me-2" />

                                </div>
                                <div class="row" style="margin-top: 5px; margin-top: 10px;">
                                    <button type="button" onclick="ocultarSeccionEdicion()" class="btn btn-secondary">Cancelar</button>
                                </div>
                            </div>

                            <div id="seccionAgregar" style="display: none; color: black">
                                <asp:HiddenField ID="hfIDinmueble" runat="server" />
                                <div class="row">
                                    <asp:Label ID="lblEstado" runat="server" AssociatedControlID="ddlPolitica" CssClass="form-label">Seleccione la política</asp:Label>
                                    <asp:DropDownList ID="ddlPolitica" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Chek-In" Value="Chek-In"></asp:ListItem>
                                        <asp:ListItem Text="Salida" Value="Salida"></asp:ListItem>
                                        <asp:ListItem Text="CantidadMaximaHuespedes" Value="CantidadMaximaHuespedes"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="row">
                                    <asp:Label ID="Label3" runat="server" AssociatedControlID="TextBox2" CssClass="form-label">Comentario de la politica</asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="TextBox2" TextMode="MultiLine" Rows="7" MinLength="10" MaxLength="60"></asp:TextBox>

                                </div>

                                <div class="row" style="margin-top: 5px; margin-bottom: 5px;">
                                    <asp:Button ID="Button2" runat="server" Text="Agregar" AutoPostBack="false" OnClick="btnAgregar_Click" CssClass="btn btn-primary me-2" />

                                </div>
                                <div class="row" style="margin-top: 5px; margin-top: 10px;">

                                    <button type="button" onclick="ocultarSeccionAgregar()" class="btn btn-secondary">Cancelar</button>
                                </div>

                            </div>
                        </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>


                <div class="col-lg-4 col-md-12 col-sm-12 my-2 d-flex align-items-center">
                    <div class="w-100">
                        <img src="../img/politicas.jpg" alt="" class="img-fluid">
                    </div>
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
        function prepararEdicion(idPolitica) {
            // Asigna el valor de identificación al campo oculto del modal
            document.getElementById('<%= hiddenField1.ClientID %>').value = idPolitica;
            mostrarSeccionEdicion();
            // Llama al controlador genérico para obtener los datos del usuario
            $.ajax({
                type: "GET",
                url: "../obtenerdatopolitica.ashx?idPolitica=" + idPolitica,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    // Verifica si hay al menos un objeto en el array
                    if (data.length > 0) {

                        var politica = data[0];

                        // Llena los campos del modal con los datos obtenidos
                        document.getElementById('<%= txtNombre.ClientID %>').value = politica.Nombre;
                        document.getElementById('<%= txtComentario.ClientID %>').value = politica.Comentario;

                    } else {
                        console.log("No se encontraron datos para el usuario con ID " + idUsuario);
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }



        function prepararAgregar() {
            // Asigna el valor de identificación al campo oculto del modal

            mostrarSeccionAgregar();
            // Llama al controlador genérico para obtener los datos del usuario
            $.ajax({
                type: "GET",
                url: "../politicasnoasociadas.ashx?idInmueble=" + document.getElementById('<%= hfIDinmueble.ClientID %>').value,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    // Verifica si hay al menos un objeto en el array
                    if (data.length > 0) {
                        <%--var ddlPolitica = document.getElementById('<%= ddlPolitica.ClientID %>');



                        // Crear un objeto para realizar un seguimiento de las opciones existentes
                        var opcionesExistentes = {};

                        // Recorre los datos y agrega opciones al DropDownList
                        for (var i = 0; i < data.length; i++) {
                            var nombrePolitica = data[i].Nombre;

                            // Verifica si la opción ya existe en el DropDownList
                            if (!opcionesExistentes[nombrePolitica]) {
                                var opt = document.createElement('option');
                                opt.value = nombrePolitica; // Valor y texto son iguales
                                opt.innerHTML = nombrePolitica;
                                ddlPolitica.appendChild(opt);

                                // Agrega la opción a las opciones existentes
                                opcionesExistentes[nombrePolitica] = true;
                            } else {
                                // Si la opción ya existe, puedes eliminarla
                                var opciones = ddlPolitica.options;
                                for (var j = 0; j < opciones.length; j++) {
                                    if (opciones[j].value === nombrePolitica) {
                                        ddlPolitica.removeChild(opciones[j]);
                                        break; // Termina el bucle una vez eliminada la opción
                                    }
                                }
                            }
                        }--%>
                    } else {
                        console.log("No se encontraron datos.");
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }

        function mostrarSeccionEdicion() {
            document.getElementById('seccionEdicion').style.display = 'block';
        }

        function ocultarSeccionEdicion() {
            document.getElementById('seccionEdicion').style.display = 'none';
        }

        function mostrarSeccionAgregar() {
            document.getElementById('seccionAgregar').style.display = 'block';
        }

        function ocultarSeccionAgregar() {
            document.getElementById('seccionAgregar').style.display = 'none';
        }

    </script>
</asp:Content>
