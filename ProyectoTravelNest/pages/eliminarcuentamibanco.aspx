<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="eliminarcuentamibanco.aspx.cs" Inherits="ProyectoTravelNest.pages.eliminarCuentaMiBanco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="Content/style.css" rel="stylesheet" />
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
        <h1 style="color: #7AB730;">&nbsp;&nbsp;Eliminar Cuenta MiBanco</h1>
    </div>
</div>
<div class="con">
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
            Style="height: 44px; margin-top: -2px; border-color: #7AB730;" OnClick="btnEliminarMiBanco_Click"/>
    </div>

</div>
</asp:Content>
