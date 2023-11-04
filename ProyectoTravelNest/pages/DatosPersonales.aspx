<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatosPersonales.aspx.cs" Inherits="ProyectoTravelNest.pages.DatosPersonales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div style="color: #000000">
            <h1>
                <asp:Label ID="lblTitulo" runat="server">Editar Información Personal</asp:Label>
                <link href="../Content/DatosPersonales.css" rel="stylesheet" />
            </h1>
        </div>
<div class="row">
    <div class="col-md-4 mb-2">
        <label for="TxtIdentificacion" class="label-title">Identificación</label>
        <asp:TextBox ID="TxtIdentificacion" runat="server" type="text" class="form-control" required="required"></asp:TextBox>
    </div>
    <div class="col-md-6 mb-6"> <!-- Increase the width of the Dirección textbox -->
        <label for="TxtDireccion" class="label-title">Dirección</label>
        <asp:TextBox ID="TxtDireccion" type="text" class="form-control" runat="server" required="required"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-md-4 mb-2">
        <label for="TxtNombre" class="label-title">Nombre</label>
        <asp:TextBox ID="TxtNombre" runat="server" type="text" class="form-control" required="required"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-md-4 mb-5">
        <label for "TxtApellidos" class="label-title">Apellidos</label>
        <asp:TextBox ID="TxtApellidos" runat="server" type="text" class="form-control" required="required"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-md-4 mb-4">
        <label for "TxtTelefono" class="label-title">Teléfono</label>
        <asp:TextBox ID="TxtTelefono" type="text" class="form-control" runat="server" required="required"></asp:TextBox>
    </div>
</div>
        <div class="row">
            <div class="col-md-4 mb-2">
                <div class="d-flex justify-content-end">
                    <asp:Button ID="btnGuardar" CssClass="btn btn-datospersonales" Text="Guardar" runat="server" />
                </div>
            </div>
        </div>
        <div class="alert alert-danger" role="alert" id="lblMensaje" runat="server" visible="false"></div>
</asp:Content>

