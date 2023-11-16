<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="comentariocalificacion.aspx.cs" Inherits="ProyectoTravelNest.pages.comentariocalificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/stylesInmueble.css" rel="stylesheet" />
    <div class="container" style="margin-top: 6vh;">
        <div class="row">
            <div class="col-md-8 my-5">
                <div id="user-image">
                    <img src="../img/user.png" style="width: 6%;">
                </div>

                <div style="width: 90%;" id="user-info" class="ms-4">
                    <asp:Label runat="server" ID="lblNombreDestinatario" Text="Nombre Completo Destinatario" CssClass="h3"></asp:Label>
                    <%--<label>
                        Como un viajero apasionado y ávido lector, siempre estoy buscando nuevas experiencias
                        y oportunidades para aprender. Me encanta sumergirme en la cultura local y descubrir los
                        secretos ocultos de cada lugar que visito.
                    </label>--%>
                    <br />
                    <div class="rate r-1" style="margin-bottom: 40px;" id="divCalificacionDestinatario" runat="server">
                        <%--<label id="colorStar">★</label>
                        <label id="colorStar">★</label>
                        <label id="halfStar">★</label>
                        <label>★</label>
                        <label>★</label>
                        <label style="color: rgb(255, 204, 65); font-size: 35px;">(2,5)</label>--%>
                    </div>
                </div>
                <hr style="clear: both;">

                <asp:Repeater ID="RepeaterComentarios" runat="server">
                    <ItemTemplate>
                        <div class="my-5" style="clear: both;" id="comentario">
                            <div id="user-image">
                                <img src="../img/user.png" style="width: 3%;">
                            </div>
                            <div style="width: 60%;" id="user-info" class="ms-4">
                                <a href="?IdUsuario=<%# Eval("Autor") %>" style="text-decoration: none; color: #212529;">
                                    <asp:Label runat="server" Text='<%# Eval("NombreCompleto") %>' CssClass="h5"></asp:Label>
                                </a>
                                <br />
                                <div class="rate r-2" style="margin-top: -15px; margin-bottom: -8px;">
                                    <%# generarCalificacion(Convert.ToInt32(Eval("Calificacion"))) %>
                                </div><br>
                                <label style="font-size: 15px; margin-bottom: 60px;">
                                    <%# Eval("Comentario") %>
                                </label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <%--<div class="col-md-4 my-5 detalles">
                <div class="d-flex" style="height: 80%; padding-left: 6%;">
                    <div class="vr"></div>
                </div>
                <div style="display: block;">
                    <h2 style="text-align: center; flex-grow: 1;">Detalles</h2>
                    <div class="detalles-info">
                        <div>
                            <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 384 512">
                                <path d="M144 56c0-4.4 3.6-8 8-8h80c4.4 0 8 3.6 8 8v72H144V56zm176 
                                72H288V56c0-30.9-25.1-56-56-56H152C121.1 0 96 25.1 96 56v72H64c-35.3 0-64 28.7-64 64V416c0 35.3 28.7 
                                64 64 64c0 17.7 14.3 32 32 32s32-14.3 32-32H256c0 17.7 14.3 32 32 32s32-14.3 32-32c35.3 0 64-28.7 
                                64-64V192c0-35.3-28.7-64-64-64zM112 224H272c8.8 0 16 7.2 16 16s-7.2 16-16 16H112c-8.8 0-16-7.2-16-16s7.2-16 
                                16-16zm0 128H272c8.8 0 16 7.2 16 16s-7.2 16-16 16H112c-8.8 0-16-7.2-16-16s7.2-16 16-16z"/></svg>
                            <label>Ha realizado 9 reservas</label>
                        </div>
                        <div>
                            <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 640 512">
                                <path d="M96 128a128 128 0 1 1 256 0A128 128 0 1 1 96 128zM0 482.3C0 
                                383.8 79.8 304 178.3 304h91.4C368.2 304 448 383.8 448 482.3c0 16.4-13.3 29.7-29.7 29.7H29.7C13.3 512 0 
                                498.7 0 482.3zM625 177L497 305c-9.4 9.4-24.6 9.4-33.9 0l-64-64c-9.4-9.4-9.4-24.6 0-33.9s24.6-9.4 33.9 
                                0l47 47L591 143c9.4-9.4 24.6-9.4 33.9 0s9.4 24.6 0 33.9z"/></svg>
                            <label>Identidad verificada</label>
                        </div>
                        <div>
                            <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 512 512">
                                <path d="M211 7.3C205 1 196-1.4 187.6 .8s-14.9 8.9-17.1 17.3L154.7 80.6l-62-17.5c-8.4-2.4-17.4 0-23.5 
                                6.1s-8.5 15.1-6.1 23.5l17.5 62L18.1 170.6c-8.4 2.1-15 8.7-17.3 17.1S1 205 7.3 211l46.2 45L7.3 301C1 307-1.4 
                                316 .8 324.4s8.9 14.9 17.3 17.1l62.5 15.8-17.5 62c-2.4 8.4 0 17.4 6.1 23.5s15.1 8.5 23.5 6.1l62-17.5 15.8 
                                62.5c2.1 8.4 8.7 15 17.1 17.3s17.3-.2 23.4-6.4l45-46.2 45 46.2c6.1 6.2 15 8.7 23.4 6.4s14.9-8.9 17.1-17.3l15.8-62.5 
                                62 17.5c8.4 2.4 17.4 0 23.5-6.1s8.5-15.1 6.1-23.5l-17.5-62 62.5-15.8c8.4-2.1 15-8.7 17.3-17.1s-.2-17.3-6.4-23.4l-46.2-45 
                                46.2-45c6.2-6.1 8.7-15 6.4-23.4s-8.9-14.9-17.3-17.1l-62.5-15.8 17.5-62c2.4-8.4 0-17.4-6.1-23.5s-15.1-8.5-23.5-6.1l-62 
                                17.5L341.4 18.1c-2.1-8.4-8.7-15-17.1-17.3S307 1 301 7.3L256 53.5 211 7.3z"/></svg>
                            <label>Superanfitrión</label>
                        </div>
                        <div>
                            <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 640 512">
                                <path d="M0 128C0 92.7 28.7 64 64 64H256h48 16H576c35.3 0 64 28.7 64 64V384c0 35.3-28.7 64-64 64H320 304 256 64c-35.3 
                                0-64-28.7-64-64V128zm320 0V384H576V128H320zM178.3 175.9c-3.2-7.2-10.4-11.9-18.3-11.9s-15.1 4.7-18.3 11.9l-64 144c-4.5 
                                10.1 .1 21.9 10.2 26.4s21.9-.1 26.4-10.2l8.9-20.1h73.6l8.9 20.1c4.5 10.1 16.3 14.6 26.4 10.2s14.6-16.3 10.2-26.4l-64-144zM160 
                                233.2L179 276H141l19-42.8zM448 164c11 0 20 9 20 20v4h44 16c11 0 20 9 20 20s-9 20-20 20h-2l-1.6 4.5c-8.9 24.4-22.4 46.6-39.6 
                                65.4c.9 .6 1.8 1.1 2.7 1.6l18.9 11.3c9.5 5.7 12.5 18 6.9 27.4s-18 12.5-27.4 6.9l-18.9-11.3c-4.5-2.7-8.8-5.5-13.1-8.5c-10.6 
                                7.5-21.9 14-34 19.4l-3.6 1.6c-10.1 4.5-21.9-.1-26.4-10.2s.1-21.9 10.2-26.4l3.6-1.6c6.4-2.9 12.6-6.1 
                                18.5-9.8l-12.2-12.2c-7.8-7.8-7.8-20.5 0-28.3s20.5-7.8 28.3 0l14.6 14.6 .5 .5c12.4-13.1 22.5-28.3 29.8-45H448 376c-11 
                                0-20-9-20-20s9-20 20-20h52v-4c0-11 9-20 20-20z"/>
                            </svg>
                            <label>Español e Inglés</label>
                        </div>
                    </div>
                </div>
            </div>--%>

        </div>
    </div>
</asp:Content>
