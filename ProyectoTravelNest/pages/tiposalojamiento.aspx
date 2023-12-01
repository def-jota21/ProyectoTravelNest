<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tiposalojamiento.aspx.cs" Inherits="ProyectoTravelNest.pages.tiposalojamiento" %>

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
            <h1 style="color: #7AB730;">Agregar Tipos de Alojamientos</h1>
            <p style="color: dimgrey;">Podrá presionar el botón agregar si desea agregar una nueva categoria.</p>
            <a style="margin-bottom: 4px !important;" href="#"><i class="fa fa-arrow-left text-primary mr-2"></i>Regresar</a>
            <div class="row">
                <div class="col-lg-8 col-md-12 col-sm-12 my-2">
                    <div class="row" style="margin-top: 5px; margin-bottom: 15px; max-width: 200px; margin-left: 2px;">
                        <button onclick="prepararAgregar(); return false;" class="btn btn-primary">Agregar Categoría&nbsp;<i class="fa-solid fa-plus" style="color: white;"></i></button>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="table table-responsive-md table-responsive-lg table-bordered border-dark table-hover text-center">
                                <thead>
                                    <tr class="table-dark table-active text-white">
                                        <th scope="col">Identificador</th>
                                        <th scope="col">Categoria</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptCategorias" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("idCategoria") %></td>
                                                <td><%# Eval("Nombre") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <div class="col-lg-8 col-md-12 col-sm-12 my-2">
                                <div id="seccionAgregar" style="display: none; color: black">
                                   

                                    <div class="row">
                                        <asp:Label ID="Label3" runat="server" AssociatedControlID="TextBox2" CssClass="form-label">Categoría</asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="TextBox2" Rows="7" MaxLength="60"></asp:TextBox>
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
            



            function prepararAgregar() {
                // Asigna el valor de identificación al campo oculto del modal

                mostrarSeccionAgregar();
                // Llama al controlador genérico para obtener los datos del usuario
            }

            function mostrarSeccionAgregar() {
                document.getElementById('seccionAgregar').style.display = 'block';
            }

            function ocultarSeccionAgregar() {
                document.getElementById('seccionAgregar').style.display = 'none';
            }

        </script>

</asp:Content>
