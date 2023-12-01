<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="elegirinmueble.aspx.cs" Inherits="ProyectoTravelNest.pages.elegirinmueble" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <div class="container" style="margin-top: 6vh;">
        <h1 runat="server" id="h1_titulo">Agregar, modificar o eliminar</h1>
        <h5>Seleccione el inmueble.</h5>

        <!-- Cartas -->

        <div class="container-fluid mt-5">
            <div class="row" id="row" runat="server">
                <asp:Repeater ID="rptAlojamientos" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 mb-4">
                            <a href='<%# Session["pagina"].ToString() %>.aspx?IdInmueble=<%# Eval("IdInmueble") %>' class='text-decoration-none' style='color: initial;'>
                                <div class="package-item bg-white mb-2">
                                    <asp:Image ID="imgMueble" CssClass="img-fluid" Style="min-height: 240px !important;" runat="server"
                                        src='<%# Eval("Imagen") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) : "/img/noimage.jpg" %>'
                                        AlternateText="Imagen del Inmueble" />
                                    <div class="p-4">
                                        <div class="d-flex justify-content-between mb-3">
                                            <small class="m-0"><i class="fa fa-map-marker-alt text-primary mr-2"></i>
                                                <asp:Label ID="lblUbicacion" runat="server" Text='<%# Eval("Direccion") %>'></asp:Label>
                                            </small>
                                        </div>
                                        <asp:Label ID="lnkDetalle" CssClass="h5 text-decoration-none" runat="server" NavigateUrl="#"><%# Eval("Nombre") %></asp:Label>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>


    </div>
</asp:Content>
