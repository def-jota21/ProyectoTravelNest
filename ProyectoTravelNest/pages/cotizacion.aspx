<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cotizacion.aspx.cs" Inherits="ProyectoTravelNest.pages.cotizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <link href="../Content/style.css" rel="stylesheet" />
    <div class="container mt-5">
        <div class="row">
            
                <div class="col">
                    <h2>Confirma y Paga</h2>
                    <div class="form-group mt-4">
                        <label for="txtf_inicio" class="form-label">Fecha Inicio</label>
                        <asp:TextBox ID="txtf_inicio" runat="server" CssClass="form-control" ReadOnly="true" AutoComplete="off"></asp:TextBox>
                    </div>
                    <div class="form-group mt-2">
                        <label for="txtf_fin" class="form-label">Fecha Fin</label>
                        <asp:TextBox ID="txtf_fin" runat="server" CssClass="form-control" ReadOnly="true" AutoComplete="off"></asp:TextBox>
                    </div>
                    <div class="form-group mt-2">
                        <label for="txthuesped" class="form-label">Huespedes</label>
                        <asp:TextBox ID="txthuesped" runat="server" CssClass="form-control" ReadOnly="true" AutoComplete="off" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="form-group mt-2">
                        <label for="txtcupon" class="form-label">Cupon</label>
                        <asp:TextBox ID="txtcupon" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnPagar" runat="server" Text="Pagar" CssClass="btn btn-primary mt-4" OnClick="btnPagar_Click" />

                </div>
                <div class="col">
                    <div class="card border-light mb-3" style="max-width: 30rem;">
                        <div class="card-header">
                            <div class="container">
                                <div class="row">
                                    <div class="col-4">
                                       <asp:Repeater ID="RepeaterImagen" runat="server" OnItemDataBound="RepeaterImagen_ItemDataBound">
                                            <ItemTemplate>
                                                    <asp:Image ID="imgMueble" CssClass="card-img-top" runat="server" style="border-radius:8px;" alt="Card image cap"
                                                        ImageUrl='<%# Eval("Imagen") != DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) : "" %>'
                                                        AlternateText="Imagen del mueble" />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="col-8">
                                        <label for="exampleFormControlInput1" class="form-label mt-1"><asp:Label ID="lblCodigo" runat="server" /></label>
                                       
                                        <br />
                                         <label for="exampleFormControlInput1" class="form-label mt-2"><small><asp:Label ID="lblNombreInmueble" runat="server" /></small></label>
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                        <div class="card-body">
                          <h5 class="card-title">Informacion de Precio</h5>
                            <p class="card-text"><asp:Label ID="lblNoches" runat="server" /></p>
                            <p class="card-text">Tarifa de limpieza: <asp:Label ID="lblLimpieza" runat="server" /></p>
                            <p class="card-text">Tarifa por servicio de TravelNest: <asp:Label ID="lblServicio" runat="server" /></p>
                            <p class="card-text">Impuestos: <asp:Label ID="lblImpuestos" runat="server" /></p>
                            <hr />
                            <p><strong>Total (USD): <asp:Label ID="lblTotal" runat="server" /></strong></p>
                        </div>
                      </div>
                </div>
            
        </div>  
    </div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
