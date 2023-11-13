<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="comentariosanfitrion.aspx.cs" Inherits="ProyectoTravelNest.pages.comentariosanfitrion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Favicon -->
    <link href="img/favicon.ico" rel="icon">

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;500;600;700&display=swap" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">

    <!-- Libraries Stylesheet -->
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>

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
    </style>


    <div class="container">
        <img src="../img/Comentarios2.jpg" class="img-fluid">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-12 col-sm-12 my-2">
                    <div class="col-lg-7 col-md-12 col-sm-12 my-2">
                    <div class="row">
                        <h3>Comentario público para el anfitrión</h3>
                        <p>Se publicará un comentario en el perfil a tu anfitrión</p>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtcomentarioPublico" TextMode="MultiLine" Rows="7"></asp:TextBox>
                        <div id="contadorPalabrasPublico">*100 palabras restantes</div>
                    </div>
                        </div>
                    <div class="col-lg-8 col-md-12 col-sm-12 my-2">
                        <h3>Comunicación</h3>
                        <p>¿El anfitrión ha mantenido el contacto en todo momento necesario?</p>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" CssClass="form-select" ID="ddlComunicacion" AppendDataBoundItems="true">
                                <asp:ListItem Text="1" Value="1" />
                                <asp:ListItem Text="2" Value="2" />
                                <asp:ListItem Text="3" Value="3" />
                                <asp:ListItem Text="4" Value="4" />
                                <asp:ListItem Text="5" Value="5" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-lg-8 col-md-12 col-sm-12 my-2">
                        <h3>¿Qué calificación le da al anfitrión?</h3>
                        <p>Selecciona una calificación</p>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" CssClass="form-select" ID="ddlCalificacionAnfitrion" AppendDataBoundItems="true">
                                <asp:ListItem Text="1" Value="1" />
                                <asp:ListItem Text="2" Value="2" />
                                <asp:ListItem Text="3" Value="3" />
                                <asp:ListItem Text="4" Value="4" />
                                <asp:ListItem Text="5" Value="5" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>



                <div class="col-lg-4 col-md-12 col-sm-12 my-2 d-flex align-items-center">
                    <div class="w-100">
                        <img src="../img/comentarios.jpg" alt="" class="img-fluid">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container my-3">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 my-2 text-center">
                <div class="col-lg-4 col-md-4 mx-auto">
                    <asp:Button class="btn btn-primary btn-block rounded" runat="server" name="btnEnviarComentario" OnClick="EnviarComentarioAnfitrion_Click" ID="btnEnviarComentario"
                        Style="height: 47px; margin-top: -2px;" Text="Enviar" />
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
    <script>
        function contarPalabrasPublico() {
            var comentario = document.getElementById('<%= txtcomentarioPublico.ClientID %>').value;
            var palabras = comentario.trim().split(/\s+/);
            var numPalabras = palabras.length;
            var palabrasRestantes = 100 - numPalabras;

            if (palabrasRestantes >= 0) {
                document.getElementById("contadorPalabrasPublico").innerHTML = "*" + palabrasRestantes + " palabras restantes";
            } else {
                document.getElementById("contadorPalabrasPublico.ClientID %>").innerHTML = "Límite de palabras alcanzado";
                document.getElementById('<%= txtcomentarioPublico.ClientID %>').value = comentario.split(/\s+/).slice(0, 100).join(" ");
            }
        }

        // Asociar las funciones a eventos de escritura en los campos de texto
        document.getElementById('<%= txtcomentarioPublico.ClientID %>').addEventListener("input", contarPalabrasPublico);
        
    </script>
</asp:Content>
