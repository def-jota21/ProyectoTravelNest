<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="descuentos.aspx.cs" Inherits="ProyectoTravelNest.pages.descuentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/stylesInmueble.css" rel="stylesheet" />
    <link href="../Content/styleComentariosPendientes.css" rel="stylesheet" />
    <style>
        @media (max-width: 400px) {
            .btn-group .btnModificar, .btn-group .btnGuardar, .btn-group .btnEliminar {
                font-size: 0.875rem;
                margin-left: -150%
            }
        }
        @media (max-width: 380px) {
            .btn-group .btnModificar, .btn-group .btnGuardar, .btn-group .btnEliminar {
                margin-left: -320%
            }
        }
        @media (max-width: 350px) {
            .btn-group .btnModificar, .btn-group .btnGuardar, .btn-group .btnEliminar {
                margin-left: -600%
            }
        }
    </style>
    <div class="container" style="margin-top: 6vh;">
        <h1>Agregar descuento</h1>
        <h5>Ingrese, modifique o elimine un descuento según sea necesario.</h5>

        <div class="container-fluid mt-5">
            <div class="container" runat="server" id="error" visible="false">
                <div class="row">
                    <div class="col-sm-3 alert alert-danger" runat="server" id="cajaEstado" role="alert">
                        <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row flex-column-reverse flex-md-row">
                <div class="col-md-7 mb-5 mb-md-0" id="Lista" runat="server">
                    <!-- Cargar descuentos -->
                    <asp:Repeater ID="Repeater" runat="server">
                        <ItemTemplate>
                            <div style="background-color: #F9F9F9;" class="p-3 mb-3 rounded-3">
                                <div class="d-flex justify-content-between">
                                    <asp:TextBox ID="txtPorcentaje" runat="server" Text='<%# Eval("Porcentaje") %>' 
                                                AutoCompleteType ="Disabled" CssClass="h5" MaxLength="5" ReadOnly="true"
                                                style="border: none; background-color: transparent; outline: none;">
                                    </asp:TextBox>
                                    <!-- Botones -->
                                    <div class="d-flex justify-content-end" style="margin-top: -6px;">
                                        <div class="btn-group" role="group">
                                            <div style="margin: 0px 5px" runat="server" id="divbtnModificar" visible="true">
                                                <asp:LinkButton ID="btnModificar" runat="server" CssClass="btnModificar"
                                                            CommandArgument='<%# Eval("IdDescuento") %>' OnClick="btnModificar_Click">
                                                    <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 512 512">
                                                        <path d="M471.6 21.7c-21.9-21.9-57.3-21.9-79.2 0L362.3 51.7l97.9 97.9 30.1-30.1c21.9-21.9 21.9-57.3 0-79.2L471.6 21.7zm-299.2 220c-6.1 6.1-10.8 13.6-13.5 21.9l-29.6 88.8c-2.9 8.6-.6 18.1 5.8 24.6s15.9 8.7 24.6 5.8l88.8-29.6c8.2-2.7 15.7-7.4 21.9-13.5L437.7 172.3 339.7 74.3 172.4 241.7zM96 64C43 64 0 107 0 160V416c0 53 43 96 96 96H352c53 0 96-43 96-96V320c0-17.7-14.3-32-32-32s-32 14.3-32 32v96c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V160c0-17.7 14.3-32 32-32h96c17.7 0 32-14.3 32-32s-14.3-32-32-32H96z"/>
                                                    </svg>
                                                </asp:LinkButton>
                                            </div>
                                            
                                            <div style="margin: 0px 5px" runat="server" id="divbtnGuardar" visible="false">
                                                <asp:LinkButton ID="btnGuardar" runat="server" CssClass="btnGuardar"
                                                            CommandArgument='<%# Eval("IdDescuento") %>' OnClick="btnGuardar_Click">
                                                    <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 448 512">
                                                        <path d="M64 32C28.7 32 0 60.7 0 96V416c0 35.3 28.7 64 64 64H384c35.3 0 64-28.7 64-64V173.3c0-17-6.7-33.3-18.7-45.3L352 50.7C340 38.7 323.7 32 306.7 32H64zm0 96c0-17.7 14.3-32 32-32H288c17.7 0 32 14.3 32 32v64c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V128zM224 288a64 64 0 1 1 0 128 64 64 0 1 1 0-128z"/>
                                                    </svg>
                                                </asp:LinkButton>
                                            </div>

                                            <div style="margin: 0px 5px" runat="server" id="divbtnEliminar" visible="true">
                                                <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btnEliminar"
                                                            CommandArgument='<%# Eval("IdDescuento") %>' OnClick="btnEliminar_Click">
                                                    <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 448 512">
                                                        <path d="M135.2 17.7C140.6 6.8 151.7 0 163.8 0H284.2c12.1 0 23.2 6.8 28.6 17.7L320 32h96c17.7 0 32 14.3 32 32s-14.3 32-32 32H32C14.3 96 0 81.7 0 64S14.3 32 32 32h96l7.2-14.3zM32 128H416V448c0 35.3-28.7 64-64 64H96c-35.3 0-64-28.7-64-64V128zm96 64c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16zm96 0c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16zm96 0c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16z"/>
                                                    </svg>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <!-- Agregar Descuento -->
                    <div class="p-3 mb-3 rounded-3">
                        <div class="d-flex justify-content-center">
                            <asp:LinkButton runat="server" style="width: 100%; height: 100%; padding: 10px 0px; display: flex; justify-content: center; align-items: center;"
                                            class="align-items-center rounded-3" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="agregar_promocion">
                                <svg style="fill: #9e9e9e" xmlns="http://www.w3.org/2000/svg" height="4em" viewBox="0 0 448 512">
                                    <path d="M256 80c0-17.7-14.3-32-32-32s-32 14.3-32 32V224H48c-17.7 0-32 14.3-32 32s14.3 32 32 32H192V432c0 17.7 14.3 32 32 32s32-14.3 32-32V288H400c17.7 0 32-14.3 32-32s-14.3-32-32-32H256V80z"/>
                                </svg>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-5 p-0 mb-5 me-4 bg-white rounded" runat="server" id="cartaInmueble">
                    <!-- Inmueble -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>