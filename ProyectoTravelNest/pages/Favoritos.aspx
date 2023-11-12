<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="favoritos.aspx.cs" Inherits="ProyectoTravelNest.pages.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="upd_Favoritos" UpdateMode="Conditional">
        <ContentTemplate>
            <head>
                <meta charset="utf-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
                <link href="../Content/Favoritos.css" rel="stylesheet" />
                <link href="../Content/style.css" rel="stylesheet" />
                <style>
                    .add-more-button {
                        position: fixed;
                        top: 30%;
                        right: 800px;
                        transform: translateY(-10%);
                    }
                </style>
            </head>
            <asp:Repeater ID="rptData" runat="server">
                <ItemTemplate>
                    <div class="col-lg-4 col-md-6 mb-4">
                        <div class="package-item bg-white mb-2">
                            <img class="img-fluid" src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) %>' />
                        </div>
                        <div class="p-4">
                            <div class="d-flex justify-content-between mb-3">
                                <small class="m-0"><i class="fa fa-map-marker-alt text-primary mr-2"></i><%# Eval("Direccion") %></small>
                                <asp:LinkButton runat="server" CssClass="btn m-0" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("IdInmueble") %>'>
                                    <ItemTemplate>
                                        <i class="fa fa-heart text-danger"></i> Favorito
                                    </ItemTemplate>
                                </asp:LinkButton>
                                <small class="m-0"><i class="fa fa-user text-primary mr-2"></i><%# Eval("Cantidad_Huesped") %></small>
                            </div>
                            <a class="h5 text-decoration-none" href="#"><%# Eval("Nombre") %></a>
                            <div class="border-top mt-4 pt-4">
                                <div class="d-flex justify-content-between">
                                    <h6 class="m-0"><i class="fa fa-star text-primary mr-2"></i><%# Eval("Calificacion") %></h6>
                                    <h5 class="m-0"><%# Eval("Precio") %></h5>
                                    <p><b>por noche</b></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
