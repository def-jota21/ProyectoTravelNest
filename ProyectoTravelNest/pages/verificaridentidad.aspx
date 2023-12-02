<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verificaridentidad.aspx.cs" Inherits="ProyectoTravelNest.pages.verificaridentidad" Async="true" %>
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
            <div class="col-sm-6 alert alert-danger" runat="server" id="cajaEstado" role="alert">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblEstado" runat="server" Text="Estado: Error"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
          </div>
        </div>
        
        <asp:UpdatePanel ID="updtPanel" runat="server">
            <ContentTemplate>
                <div class="row my-5">
                    <div class="col-md-8 col-lg-6 mb-4">
                        <h4>Subir documento</h4>
                        <p>
                            Es importante subir un documento de identificación oficial para verificar la identidad. 
                            Esto ayuda a confirmar que los usuarios son quienes dicen ser, lo que a su vez fomenta 
                            la confianza y la seguridad en la comunidad.
                        </p>
                        <p class="h6">
                            Se recomienda que la imagen se presente en horizontal y que no exceda los 2 MB de peso.
                        </p>
                        <asp:FileUpload ID="Documento" runat="server" CssClass="btn btn-primary"/>
                    </div>

                    <div class="col-md-8 col-lg-6">
                        <h4>Subir foto del rostro</h4>
                        <p>
                            Subir una foto del rostro es otro paso crucial en el proceso de verificación. Al comparar 
                            la foto del rostro con la foto en el documento de identificación, se puede confirmar aún 
                            más la identidad del usuario. Esto también ayuda a asegurar a otros miembros de la comunidad 
                            que están interactuando con una persona real.
                        </p>
                        <p class="h6">
                            Se recomienda que la imagen no exceda los 2 MB de peso.
                        </p>
                        <asp:FileUpload ID="Rostro" runat="server" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="position: relative; display: inline-block;">
            <asp:Button ID="btnVerificar" runat="server" OnClick="btnVerificar_Click" CssClass="btn-success btn ms-5"
                        Text="Verificar identidad" OnClientClick="mostrarGIF();"/>
            <div id="cargandoImagen" runat="server" style="display:none; position:absolute; top: 0; left: 100%; margin-left:10px; margin-top: -36%; width: 130px;">
                <asp:Image runat="server" ID="imagenCargando" ImageUrl="~/img/loading-1.gif" AlternateText="Cargango..." Visible="true"/>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function mostrarGIF() {
            var gif = document.getElementById('cargandoImagen');
            gif.style.display = 'inline-block';
            return true;
        }
    </script>
</asp:Content>
