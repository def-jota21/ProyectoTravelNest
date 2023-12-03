<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="anunciospublicados.aspx.cs" Inherits="ProyectoTravelNest.pages.anunciospublicados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <!--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">-->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">

    <div class="container-fluid">
        <div class="container pt-5 pb-3">
            <div class="mb-3 pb-3">
                <h2>Anuncios Publicados</h2>
            </div>
            <div class="row">
                <asp:Repeater ID="rptAlojamientos" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 mb-4">
                            <div class="package-item bg-white mb-2">
                                <asp:Image ID="imgMueble" CssClass="img-fluid" Style="min-height: 240px !important;" runat="server"
                                    src='<%# Eval("Imagen") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) : "" %>'
                                    AlternateText="Imagen del mueble" />
                                <div class="p-4">
                                    <div class="d-flex justify-content-between mb-3">
                                        <small class="m-0"><i class="fa fa-map-marker-alt text-primary mr-2"></i>
                                            <asp:Label ID="lblUbicacion" runat="server" Text='<%# Eval("Direccion") %>'></asp:Label></small>

                                    </div>
                                    <asp:Label ID="lnkDetalle" CssClass="h5 text-decoration-none" runat="server" NavigateUrl="#"><%# Eval("Nombre") %></asp:Label>
                                    <div class="border-top mt-4 pt-4">
                                        <div class="d-flex justify-content-between">
                                            <asp:Button ID="btnVerInformacion" runat="server" Text="Ver Información" CssClass="btn btn-primary btn-block"
                                                Style="height: 47px; margin-top: -2px;" CommandName="VerInformacion" CommandArgument='<%# $"{Eval("IdUsuario")},{Eval("IdInmueble")}" %>' OnCommand="btnVerInformacion_Command" />
                                        </div>
                                        <div class="d-flex justify-content-between mt-2">
                                            <asp:Button ID="btnModificar" runat="server" Text="Guardar" CssClass="btn btn-info btn-block"
                                                Style="height: 47px; margin-top: -2px;" CommandName="Modificar" CommandArgument='<%# $"{Eval("idUsuario")},{Eval("IdInmueble")}" %>' OnCommand="btnModificar_Command" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <%--<script>
        $(document).ready(function () {
            // Encuentra todas las tarjetas en el repeater
            var cards = $(".package-item");

            // Encuentra la altura máxima entre todas las tarjetas
            var maxHeight = 0;
            cards.each(function () {
                var cardHeight = $(this).outerHeight();
                if (cardHeight > maxHeight) {
                    maxHeight = cardHeight;
                }
            });

            // Establece la misma altura máxima para todas las tarjetas
            cards.css("height", maxHeight + "px");
        });</script> --%>

</asp:Content>
