<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recepcionmensajes.aspx.cs" Inherits="ProyectoTravelNest.pages.RecepcionMensajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/RecepcionMensajes.css" rel="stylesheet" />
       
        <asp:UpdatePanel runat="server" ID="UpdPanel_Page" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="container">
                    <div class="row">
                        <div class="col-md-4">
                            <h2>Mensajeria</h2>
                            <div class="btn-group" role="group">
                                <button class="btn btn-secondary category-button" id="category-messages">Bandeja de Mensajes</button>
                                <%--<button class="btn btn-secondary category-button" id="category-reports">Denuncias</button>--%>
                            </div>

                            <asp:Repeater ID="rptAnfitriones" runat="server">
                                <ItemTemplate>
                                    <div class="form-group mt-3">
                                        <asp:Button
                                            runat="server"
                                            class="btn btn-secondary user-button"
                                            ID="btnAnfitrion"
                                            Text='<%# Eval("Nombre") %>'
                                            OnClick="btnAnfitrion_Click"
                                            CommandArgument='<%# Eval("Id") %>'></asp:Button>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                        <div class="col-md-8" runat="server">
                            <h2 id="chat-title">Mensajes</h2>
                            <div class="chat-section" id="chat-box">
                                <asp:Repeater runat="server" ID="rpt_Mensajes">
                                    <ItemTemplate>
                                        <div class="message">
                                            <%# Eval("FechaEnvio")%><br />
                                            <%# Eval("Descripcion") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="input-group mt-3">
                                <input type="text" id="messageinput" name="message_input" class="form-control" placeholder="Escribe un mensaje...">
                                <div class="input-group-append">
                                    <asp:Button runat="server" ID="btnSend" class="btn btn-success" Text="Enviar Mensaje" OnClick="btnSend_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


             <%-- Notificacciones Toastr --%>
        <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
        <link href="../Content/toastr.css" rel="stylesheet" />
        <script src="../Scripts/toastr.js"></script>
        <script src="../Scripts/WebForms/NotificacionesToastr.js"></script>

                <script>
                    // Esta función desplaza la ventana del chat al final
                    function scrollToChatBottom() {
                        var chatBox = document.getElementById("chat-box");
                        chatBox.scrollTop = chatBox.scrollHeight;
                    }
                </script>

            </ContentTemplate>
        </asp:UpdatePanel>
   
</asp:Content>
