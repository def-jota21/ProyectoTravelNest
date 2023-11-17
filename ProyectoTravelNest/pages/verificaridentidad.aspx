<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verificaridentidad.aspx.cs" Inherits="ProyectoTravelNest.pages.verificaridentidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/stylesInmueble.css" rel="stylesheet" />
    <div class="container" style="margin-top: 6vh;">
        <h1>Verificar Identidad</h1>
        <div class="my-5">
            <h4>Identificación</h4>
            <asp:Label ID="lblIdentificacion" runat="server" Text="Error"></asp:Label>
        </div>
        <div class="container">
          <div class="row">
            <div class="col-sm-3 alert alert-danger" runat="server" id="cajaEstado" role="alert">
                <asp:Label ID="lblEstado" runat="server" Text="Estado: Error"></asp:Label>
            </div>
          </div>
        </div>
        
        <asp:UpdatePanel ID="updtPanel" runat="server">
            <ContentTemplate>
                <div class="my-5" style="width: 60%;">
                <h4>Subir documento</h4>
                <p>
                    Es importante subir un documento de identificación oficial para verificar la identidad. 
                    Esto ayuda a confirmar que los usuarios son quienes dicen ser, lo que a su vez fomenta 
                    la confianza y la seguridad en la comunidad.
                </p>
                <asp:FileUpload ID="Documento" runat="server" CssClass="btn btn-primary"/>
                </div>
                <div class="my-5" style="width: 60%;">
                    <h4>Subir foto del rostro</h4>
                    <p>
                        Subir una foto del rostro es otro paso crucial en el proceso de verificación. Al comparar 
                        la foto del rostro con la foto en el documento de identificación, se puede confirmar aún 
                        más la identidad del usuario. Esto también ayuda a asegurar a otros miembros de la comunidad 
                        que están interactuando con una persona real.
                    </p>
                    <asp:FileUpload ID="Rostro" runat="server" CssClass="btn btn-primary"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="btnVerificar" runat="server" OnClick="btnVerificar_Click" CssClass="btn-success btn ms-5" Text="Verificar identidad" />
    </div>
</asp:Content>
