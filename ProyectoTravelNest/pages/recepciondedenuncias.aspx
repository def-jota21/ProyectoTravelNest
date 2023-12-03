<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recepciondedenuncias.aspx.cs" Inherits="ProyectoTravelNest.pages.recepciondedenuncias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    
        <meta charset="UTF-8">
        
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

        <asp:UpdatePanel runat="server" ID="UpdPanel_CRUDDenuncias" UpdateMode="Conditional">
            <ContentTemplate>
        <div class="container con mt-4">
            <h1>Formulario de Denuncias</h1>
            <div class="form-container">
                <div class="form-column">

                    <div id="divDdlHuespedes" class="form-group" runat="server" visible="false">
                        <asp:Label runat="server" AssociatedControlID="ddlHuesped">Huesped:</asp:Label>
                        <asp:DropDownList runat="server" ID="ddlHuesped" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div id="divDdlInmuebles" class="form-group" runat="server" visible="false">
                        <asp:Label runat="server" AssociatedControlID="ddlInmueble">Inmueble:</asp:Label>
                        <asp:DropDownList runat="server" ID="ddlInmueble" CssClass="form-control"></asp:DropDownList>
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
                            <asp:ListItem Text="Persona" Value="Persona"></asp:ListItem>
                            <asp:ListItem Text="Inmueble" Value="Inmueble"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtDescripcion">Descripción de Denuncia:</asp:Label>
                        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <asp:Button runat="server" ID="btnEnviarDenuncia" Text="Enviar Denuncia" OnClick="btnEnviarDenuncia_Click" CssClass="btn btn-primary" />
            </div>
              <%-- Notificacciones Toastr --%>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <link href="../Content/toastr.css" rel="stylesheet" />
    <script src="../Scripts/toastr.js"></script>
    <script src="../Scripts/WebForms/NotificacionesToastr.js"></script>
            </ContentTemplate>
        </asp:UpdatePanel>

  


</asp:Content>
