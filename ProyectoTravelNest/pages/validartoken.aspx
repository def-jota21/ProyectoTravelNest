<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="validartoken.aspx.cs" Inherits="ProyectoTravelNest.pages.validartoken" %>
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
            <h1 style="color: #7AB730;">&nbsp;&nbsp;Iniciar Sesión</h1>
        </div>
    </div>
    <div class="con">
        <div class="col-sm-12 col-lg-12">
            <img src="../img/logo2.png" alt="logo" class="img-fluid" />
        </div>

        <div class="col-sm-12 col-lg-12 mt-2 form-group">
            <asp:Label ID="lbltoken" runat="server" AssociatedControlID="txtToken" CssClass="form-label">Token</asp:Label>
            <asp:TextBox ID="txtToken" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"></asp:TextBox>
        </div>

        <div class="col-sm-12 col-lg-12 mt-2 form-group">
            <asp:Button ID="btnValidarToken" runat="server" Text="Validar Token" OnClick="btnValidarToken_Click" CssClass="btn btn-primary btn-block"
                Style="height: 44px; margin-top: -2px; background: #7AB730; border-color: #7AB730;"/>
        </div>
    </div>

   
</asp:Content>
