<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consultadenuncias.aspx.cs" Inherits="ProyectoTravelNest.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPanel_ConsultaDenuncias" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <link href="../Content/Favoritos.css" rel="stylesheet" />
            <link href="../Content/consultadenuncias.css" rel="stylesheet" />
            <h1 class="h1">Recepcion de denuncias</h1>
            <div id="divformCambiarEstado" runat="server" class="form" role="dialog" aria-labelledby="modalCambiarEstadoLabel" visible="false" aria-hidden="true">
    <div class="form-dialog" role="document">
        <div class="form-content">
            <div class="form-header">
                <h5 class="form-title" id="CambiarEstadoLabel">Cambiar Estado</h5>
            </div>
            <div class="form-body">
                <div class="form-group" runat="server" visible="true">
                    <asp:TextBox runat="server" ID="txtIdDenuncia" ReadOnly="true" visible="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ddlNuevoEstado">Nuevo Estado:</label>
                    <asp:DropDownList ID="ddlNuevoEstado" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Declinada" Value="DECLINADA" />
                        <asp:ListItem Text="Pendiente" Value="PENDIENTE" />
                        <asp:ListItem Text="Aprobada" Value="APROBADA" />
                    </asp:DropDownList>
                </div>
                <div style="margin-top: 1rem;"></div>
                <asp:Button runat="server" ID="btnCancelar" class="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                <asp:Button ID="btnGuardarEstado" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardarEstado_Click" />
            </div>
        </div>
    </div>
</div>


            <asp:Repeater ID="rptDenuncias" runat="server" OnItemDataBound="rptDenuncias_ItemDataBound">
                <HeaderTemplate>
                    <div class="row">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-lg-4 col-md-6 mb-4">
                        <div class="package-item bg-white mb-2">
                            <div class="p-4">
                                <h5 class="mb-3"><%# Eval("MotivoDenuncia") %></h5>
                                <div class="d-flex justify-content-between mb-3">
                                    <small class="m-0"><i class="fa fa-user text-primary mr-2"></i>
                                        <asp:Label ID="lblDenunciante" runat="server" Text='<%# Eval("Denunciante") %>'></asp:Label>
                                    </small>
                                    <small runat="server" class="m-0"><i class="fa fa-info-circle text-warning mr-2"></i>
                                        <asp:Label ID="lblEstadoDenuncia" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                                    </small>
                                </div>

                                <div class="mb-3">
                                    <h6>Descripción de la denuncia:</h6>
                                    <p><%# Eval("DescripcionDenuncia") %></p>
                                </div>

                                <asp:Button
                                    ID="BtnCambiarEstado"
                                    runat="server"
                                    class="btn btn-warning btn-sm"
                                    Text="Cambiar Estado"
                                    Visible="false"
                                    CommandArgument='<%#Eval("IdDenuncia") %>'
                                    OnClick="BtnCambiarEstado_Click"
                                    AutoPostBack="true" />

                                <div class="border-top mt-4 pt-4">
                                    <h6>Detalles adicionales:</h6>
                                    <p><strong>Denunciado:</strong> <%# Eval("Denunciado") %></p>
                                    <p><strong>Tipo de Usuario:</strong> <%# Eval("TipoUsuario") %></p>
                                    <!-- Información de la sanción -->
                                    <p><strong>Sanción:</strong> <%# Eval("Sancion") %></p>
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

                 <%-- Notificacciones Toastr --%>
        <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
        <link href="../Content/toastr.css" rel="stylesheet" />
        <script src="../Scripts/toastr.js"></script>
        <script src="../Scripts/WebForms/NotificacionesToastr.js"></script>

</asp:Content>
