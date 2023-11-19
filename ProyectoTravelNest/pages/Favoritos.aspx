<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="favoritos.aspx.cs" Inherits="ProyectoTravelNest.pages.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="upd_Favoritos" UpdateMode="Conditional">
      
        <ContentTemplate>
            <link href="../Content/Favoritos.css" rel="stylesheet" />
            <link href="../Content/style.css" rel="stylesheet" />
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
            
            <style>
                .add-more-button {
                    position: fixed;
                    top: 30%;
                    right: 800px;
                    transform: translateY(-10%);
                }
            </style>
              <h1 class="h1">Mis Favoritos:</h1>
            <asp:Repeater ID="rptData" runat="server">
    <HeaderTemplate>
        <div class="row">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="package-item bg-white mb-2">
                <img class="img-fluid" src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) %>' alt="Imagen del inmueble" />
            </div>
            <div class="p-4">
                <div class="d-flex justify-content-between mb-3">
                    <small class="m-0"><i class="fa fa-map-marker-alt text-primary mr-2"></i><%# Eval("Direccion") %></small>
                    <asp:LinkButton runat="server" CssClass="btn m-0" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("IdInmueble") %>'>
                        <i class="fa fa-heart text-danger"></i> Favorito
                    </asp:LinkButton>
                    <small class="m-0"><i class="fa fa-user text-primary mr-2"></i><%# Eval("Cantidad_Huesped") %></small>
                </div>
                <a class="h5 text-decoration-none" href="#"><%# Eval("Nombre") %></a>
                <div class="border-top mt-4 pt-4">
                    <div class="d-flex justify-content-between">
                        <h6 class="m-0"><i class="fa fa-star text-primary mr-2"></i><%# Eval("Calificacion") %></h6>
                        <div>
                            <h5 class="m-0"><%# Eval("Precio") %></h5>
                            <p><b>por noche</b></p>
                        </div>
                    </div>
                </div>
                <div class="border-top mt-4 pt-4">
                    <div class="d-flex justify-content-between">
                        <asp:Button ID="btnVerInformacion" runat="server" Text="Ver Información" CssClass="btn btn-primary btn-block"
                            Style="height: 47px; margin-top: -2px" CommandName="VerInformacion"
                            CommandArgument='<%# $"{Eval("IdUsuario")},{Eval("IdInmueble")}" %>' OnCommand="btnVerInformacion_Command"
                            UseSubmitBehavior="false" />
                    </div>
                </div>
            </div> <!-- Cierre del div con clase p-4 -->
        </div> <!-- Cierre del div con clase col-lg-4 col-md-6 mb-4 -->
    </ItemTemplate>
    <FooterTemplate>
        </div> <!-- Cierre del div con clase row -->
    </FooterTemplate>
</asp:Repeater>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

