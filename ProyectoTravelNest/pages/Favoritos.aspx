<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="favoritos.aspx.cs" Inherits="ProyectoTravelNest.pages.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="upd_Favoritos" UpdateMode="Conditional">

        <ContentTemplate>
            <link href="../Content/Favoritos.css" rel="stylesheet" />
            <link href="../Content/styleComentariosPendientes.css" rel="stylesheet" />
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
                            <asp:Image ID="imgMueble" CssClass="img-fluid" runat="server" Style="min-height: 240px !important;"
                                src='<%# Eval("Imagen") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) : "" %>'
                                AlternateText="Imagen del mueble" />

                            <div class="p-4">
                                <div class="d-flex justify-content-between mb-3">
                                    <small class="m-0"><i class="fa fa-map-marker-alt text-primary mr-2"></i>
                                        <asp:Label ID="lblUbicacion" runat="server"
                                            Text='<%# Eval("Direccion").ToString().Length > 12 ? Eval("Direccion").ToString().Substring(0, 12) + "..." : Eval("Direccion") %>'>
                                        </asp:Label></small>

                                    <small class="m-0"><i class="fa fa-heart text-danger"></i>
                                        <asp:LinkButton runat="server" CssClass="m-0" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("IdInmueble") %>'>
Favorito
                                        </asp:LinkButton>
                                    </small>
                                    <small class="m-0"><i class="fa fa-user text-primary mr-2"></i>
                                        <asp:Label ID="lblPersonas" runat="server" Text='<%# Eval("Cantidad_Huesped") %>'></asp:Label></small>



                                </div>
                                <a class="h5 text-decoration-none" href="#"><%# Eval("Nombre") %></a>
                                <div class="border-top mt-4 pt-4">
                                    <div class="d-flex justify-content-between">
                                        <div class="d-flex justify-content-between">
                                            <h5 class="m-0" style="margin-right: 5px;">$<%# Math.Round(Convert.ToDecimal(Eval("Precio")), 2) %></h5>
                                            <p class="m-0"><b>&nbsp;por noche</b></p>
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
                            </div>
                        </div>
                    </div>
                    </div>
                    </div>


                   
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                    <!-- Cierre del div con clase row -->
                </FooterTemplate>
            </asp:Repeater>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

