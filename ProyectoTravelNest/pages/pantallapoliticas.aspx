<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pantallapoliticas.aspx.cs" Inherits="ProyectoTravelNest.pages.Pantalla_Politicas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
       
        
        <link href="../Content/style.css" rel="stylesheet" />
       
 
        <div class="container mt-4">

            <h1>Políticas de TravelNest</h1>
            <asp:Button ID="btnInsert" runat="server" CssClass="btn btn-primary" Text="Insertar nueva politica" OnClick="btnInsertar_Click" />

            <asp:UpdatePanel runat="server" ID="updPanel_Editar" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="divFormulario" runat="server" style="display: block;" visible="false">
                        <asp:TextBox type="text" runat="server" ID="txtid" class="form-control mb-2" placeholder="ID" Visible="false"></asp:TextBox>
                        <asp:TextBox type="text" runat="server" ID="txtTitulo" class="form-control mb-2" placeholder="Título"></asp:TextBox>
                        <asp:TextBox ID="txtContenido" runat="server" class="form-control mb-2" placeholder="Contenido" TextMode="MultiLine"></asp:TextBox>
                        <asp:TextBox type="text" runat="server" ID="txtTextoAdicional" class="form-control mb-2" placeholder="Texto Adicional" TextMode="MultiLine"></asp:TextBox>
                        <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" OnClick="btnGuardar_Click" Visible="false" Text="Confirmar Inserción" />
                        <asp:Button ID="btnEditarInfo" runat="server" class="btn btn-warning mb-1" Text="Guardar" OnClick="btnEditarInfo_Click" />
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClientClick="ocultarFormulario()" OnClick="btnCancelar_Click" Visible="true" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel runat="server" ID="updPanel_Politicas" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="divTarjetas" runat="server" visible="true">
                        <asp:Repeater ID="rptTarjetas" runat="server" OnItemDataBound="rptTarjetas_ItemDataBound" OnItemCommand="rptTarjetas_ItemCommand">
                            <ItemTemplate>
                                <div class="card mb-3" id="tarjeta1">
                                    <div class="card-body">
                                        <h5 id="Titulo" class="card-title"><%# Eval("Titulo") %></h5>
                                        <p class="card-text"><%# Eval("Contenido") %></p>
                                        <p class="card-text" id='<%# "texto-adicional-" + Container.ItemIndex %>' style="display: none;"><%# Eval("TextoAdicional") %></p>
                                        <a href="#" class="btn btn-primary" onclick="toggleVerMas(<%# Container.ItemIndex %>); return false;">Ver más</a>
                                        <asp:Button ID="btnEditar" runat="server" class="btn btn-warning mb-1" Text="Modificar" CommandName="Editar" AutoPostBack="true" CommandArgument='<%# Eval("ID") %>'></asp:Button>
                                        <asp:Button ID="btnBorrar" runat="server" class="btn btn-danger" Text="Eliminar" CommandName="Borrar" CommandArgument='<%# Eval("ID") %>'></asp:Button>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <%-- Notificacciones Toastr --%>
        <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
        <link href="../Content/toastr.css" rel="stylesheet" />
        <script src="../Scripts/toastr.js"></script>
        <script src="../Scripts/WebForms/NotificacionesToastr.js"></script>

        <script type="text/javascript">

            function toggleVerMas(index) {
                var textoAdicional = document.getElementById('texto-adicional-' + index);
                if (textoAdicional.style.display === 'none' || textoAdicional.style.display === '') {
                    textoAdicional.style.display = 'block';
                } else {
                    textoAdicional.style.display = 'none';
                }
            }

            function ocultarFormulario() {
                // Ocultar formulario
                document.getElementById('formulario-insertar').style.display = 'none';
            }

        </script>
 

</asp:Content>
