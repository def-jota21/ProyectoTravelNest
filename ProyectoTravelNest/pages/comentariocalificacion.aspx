<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="comentariocalificacion.aspx.cs" Inherits="ProyectoTravelNest.pages.comentariocalificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/stylesInmueble.css" rel="stylesheet" />
    <div class="container" style="margin-top: 6vh;">
        <div class="row">
            <div class="col-md-8 my-5">
                <asp:Repeater ID="rptImagen" runat="server">
                    <ItemTemplate>
                        <div id="user-image">
                            <img src='<%# Eval("Rostro") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Rostro")) : "../img/user.png" %>' style="width: 6%;">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                

                <div style="width: 90%;" id="user-info" class="ms-4">
                    <asp:Label runat="server" ID="lblNombreDestinatario" Text="Nombre Completo Destinatario" CssClass="h3"></asp:Label>
                    <br />
                    <div class="rate r-1" style="margin-bottom: 40px;" id="divCalificacionDestinatario" runat="server">
                    </div>
                </div>
                <hr style="clear: both;">

                <asp:Repeater ID="RepeaterComentarios" runat="server">
                    <ItemTemplate>
                        <div class="my-5" style="clear: both;" id="comentario">
                            <div id="user-image">
                                <asp:Image ID="imgRostro" CssClass="img-fluid" runat="server"
                                           src='<%# Eval("Rostro") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Rostro")) : "../img/user.png" %>'
                                           style="width: 30px; height: 30px; object-fit: cover; border-radius: 100px;" />
                            </div>
                            <div style="width: 60%;" id="user-info" class="ms-4">
                                <a href="?IdUsuario=<%# Eval("Autor") %>" style="text-decoration: none; color: #212529;">
                                    <asp:Label runat="server" Text='<%# Eval("NombreCompleto") %>' CssClass="h5"></asp:Label>
                                </a>
                                <br />
                                <div class="rate r-2" style="margin-top: -15px; margin-bottom: -8px;">
                                    <%# generarCalificacion(Convert.ToInt32(Eval("Calificacion"))) %>
                                </div><br>
                                <label style="font-size: 15px; margin-bottom: 40px;">
                                    <%# Eval("Comentario") %>
                                </label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>