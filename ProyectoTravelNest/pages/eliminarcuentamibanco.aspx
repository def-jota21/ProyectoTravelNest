<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="eliminarcuentamibanco.aspx.cs" Inherits="ProyectoTravelNest.pages.eliminarCuentaMiBanco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <style>
        .con {
            border: 2px dashed #ccc;
            padding: 20px;
            text-align: center;
            margin: 0 auto;
            width: 80%;
            border: 2px dotted #7AB730; /* Color del borde */
        }


        .form-group {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin: 10px 0;
        }

        .form-label {
            margin-bottom: 5px;
        }

        .form-control {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
        }

        .inputfile {
            display: none;
        }

        /* Estilos para el contenedor personalizado */
        .custom-file-upload {
            position: relative;
        }

            /* Estilos para el botón personalizado */
            .custom-file-upload label {
                background-color: #7AB730;
                color: #fff;
                padding: 10px 15px;
                border-radius: 5px;
                cursor: pointer;
            }

        /* Estilos para el texto del nombre del archivo seleccionado */
        #selectedFileName {
            margin-top: 5px;
            display: block;
            font-style: italic;
        }

        body {
            background-color: #f9f9f9;
        }
    </style>

    <div class="container">

        <div class="row col-lg-12 col-sm-12 text-center">
            <h1 class="mx-5" style="color: #7AB730;">Eliminar Cuenta MiBanco</h1>
        </div>

    </div>

    <div class="con mb-5">
        <div class="col-sm-12 col-lg-12">
            <img src="../img/logo2.png" alt="logo" class="img-fluid" />
        </div>

        <div class="col-sm-12 col-lg-12 mt-2 form-group">
            <label for="txtNumeroCuenta" class="form-label">Número de cuenta</label>
            <asp:TextBox ID="txtNumeroCuenta" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
        </div>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <div class="col-sm-12 col-lg-12 mt-2 form-group">
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Cuenta" CssClass="btn btn-danger btn-block"
                Style="height: 44px; margin-top: -2px; border-color: #7AB730;" OnClick="btnEliminarMiBanco_Click" />
        </div>
    </div>
    <div class="container">
        <div class="row col-lg-2 col-sm-2 text-right ms-auto">

            <a id="datosMiBanco"
                class="btn btn-light"
                style="height: 40px; margin-top: -2px; border-color: #7AB730;">Ver Info. MiBanco</a>
        </div>
    </div>
    <div class="modal fade" id="MiBanco" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static" style="height: auto;">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header text-white" style="background-color: #7AB730;">
                    <h5 class="modal-title" id="exampleModalLabel">Datos de Mi Banco</h5>
                    <button type="button" class=" btn" style="background-color: #7AB730;" data-bs-dismiss="modal"><i class="fa-solid fa-x" style="color: #000000;"></i></button>
                </div>
                <div class="modal-body">
                    <input id="txtid" type="hidden" value="0" />
                    <div class="row  g-2">
                        <div class="col">
                            <asp:Label ID="lblnombre" runat="server" AssociatedControlID="txtcuenta" CssClass="form-label mt-4">Nombre</asp:Label>
                            <asp:TextBox ID="txtnombre" runat="server" type="text" CssClass="form-control mt-2" ReadOnly="true"></asp:TextBox>
                            <asp:Label ID="lblCuenta" runat="server" AssociatedControlID="txtcuenta" CssClass="form-label mt-4">Cuenta</asp:Label>
                            <asp:TextBox ID="txtcuenta" runat="server" type="text" CssClass="form-control mt-2" ReadOnly="true"></asp:TextBox>
                            <asp:Label ID="lblsaldo" runat="server" AssociatedControlID="txtcuenta" CssClass="form-label mt-4">Saldo Disponible</asp:Label>
                            <asp:TextBox ID="txtsaldo" runat="server" type="text" CssClass="form-control mt-2" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <a href="https://tiusr21pl.cuc-carrera-ti.ac.cr/mibancoapi/"
                        id="btnIrMiBanco"
                        class="btn btn-light"
                        style="height: 40px; margin-top: -2px; border-color: #7AB730;"
                        target="_blank">Ir a Mi Banco</a>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script>
        document.getElementById("datosMiBanco").addEventListener("click", function () {

            $('#MiBanco').modal("show");

        });
    </script>
</asp:Content>
