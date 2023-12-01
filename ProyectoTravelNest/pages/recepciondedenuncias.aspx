<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recepciondedenuncias.aspx.cs" Inherits="ProyectoTravelNest.pages.recepciondedenuncias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Formulario de Denuncias</title>
    <link href="../Content/Denuncias.css" rel="stylesheet" />

    <style>
        .form-container {
            display: flex;
            justify-content: space-between;
            max-width: 600px; /* Adjust the width as needed */
            margin: auto;
        }

        .form-column {
            flex: 1;
            margin-right: 10px; /* Adjust the spacing between columns as needed */
        }

        .form-group {
            margin-bottom: 10px;
        }
    </style>
   
</head>
<body>
    <div class="container mt-4">
     <h1>Formulario de Denuncias</h1>
    <div class="form-container">
        <div class="form-column">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtNombre">Nombre:</asp:Label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtApellidos">Apellidos:</asp:Label>
                <asp:TextBox runat="server" ID="txtApellidos" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtInmueble">Inmueble:</asp:Label>
                <asp:TextBox runat="server" ID="txtInmueble" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtMotivo">Motivo de Denuncia:</asp:Label>
                <asp:TextBox runat="server" ID="txtMotivo" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtSancion">Sanción:</asp:Label>
                <asp:TextBox runat="server" ID="txtSancion" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-column">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ddlTipoUsuario">Tipo de Usuario:</asp:Label>
                <asp:DropDownList runat="server" ID="ddlTipoUsuario" CssClass="form-control">
                    <asp:ListItem Text="Huésped" Value="huesped"></asp:ListItem>
                    <asp:ListItem Text="Anfitrión" Value="anfitrion"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtDescripcion">Descripción de Denuncia:</asp:Label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ddlEstado">Estado:</asp:Label>
                <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                    <asp:ListItem Text="Aprobado" Value="aprobado"></asp:ListItem>
                    <asp:ListItem Text="Rechazado" Value="rechazado"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="form-group">
        <asp:Button runat="server" ID="btnEnviarDenuncia" Text="Enviar Denuncia" OnClick="btnEnviarDenuncia_Click" CssClass="btn btn-primary" />
    </div>

</body>
</html>

</asp:Content>

