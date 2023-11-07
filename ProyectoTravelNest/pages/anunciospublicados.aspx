<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="anunciospublicados.aspx.cs" Inherits="ProyectoTravelNest.pages.anunciospublicados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <link href="../Content/style.css" rel="stylesheet" />
      <!--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">-->
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">

      <div class="container-fluid">
        <div class="container pt-5 pb-3">
            <div class="mb-3 pb-3">
                <h2>Anuncios Publicados</h2>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-6 mb-4">
                    <div class="package-item bg-white mb-2">
                        <img class="img-fluid" src="img/package-1.jpg" alt="">
                        <div class="p-4">
                            <div class="d-flex justify-content-between mb-3">
                                <small class="m-0"><i
                                        class="fa fa-map-marker-alt text-primary mr-2"></i>Thailand</small>
                                <small class="m-0"><i class="fa fa-user text-primary mr-2"></i>2 Person</small>
                            </div>
                            <a class="h5 text-decoration-none" href="">Islas Canarias</a>
                            <div class="border-top mt-4 pt-4">
                                <div class="d-flex justify-content-between">
                                    <h6 class="m-0"><i class="fa fa-star text-primary mr-2"></i>4.5 <small>(16)</small>
                                    </h6>
                                    <h5 class="m-0">$350</h5>
                                    <p><b>por noche</b></p>
                                </div>
                            </div>
                            <div class="border-top mt-4 pt-4">
                                <div class="d-flex justify-content-between">
                                    <button class="btn btn-primary btn-block" id="showModalButton"
                                        style="height: 47px; margin-top: -2px;" data-bs-toggle="modal" data-bs-target="#InicioSesion">Ver Información</button>
                                        
                                </div>
                                <div class="d-flex justify-content-between mt-2">
                                    
                                        <button class="btn btn-info btn-block" id="showModalButton"
                                        style="height: 47px; margin-top: -2px;" data-bs-toggle="modal" data-bs-target="#InicioSesion">Modificar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 mb-4">
                  <div class="package-item bg-white mb-2">
                      <img class="img-fluid" src="img/blog-1.jpg" alt="">
                      <div class="p-4">
                          <div class="d-flex justify-content-between mb-3">
                              <small class="m-0"><i
                                      class="fa fa-map-marker-alt text-primary mr-2"></i>Costa Rica</small>
                              <small class="m-0"><i class="fa fa-user text-primary mr-2"></i>2 Person</small>
                          </div>
                          <a class="h5 text-decoration-none" href="">Playa Conchal</a>
                          <div class="border-top mt-4 pt-4">
                              <div class="d-flex justify-content-between">
                                  <h6 class="m-0"><i class="fa fa-star text-primary mr-2"></i>4.5 <small>(8)</small>
                                  </h6>
                                  <h5 class="m-0">$280</h5>
                                  <p><b>por noche</b></p>
                              </div>
                          </div>
                          <div class="border-top mt-4 pt-4">
                              <div class="d-flex justify-content-between">
                                  <button class="btn btn-primary btn-block" id="showModalButton"
                                      style="height: 47px; margin-top: -2px;" data-bs-toggle="modal" data-bs-target="#InicioSesion">Ver Información</button>
                              </div>
                              <div class="d-flex justify-content-between mt-2">
                                    
                                <button class="btn btn-info btn-block" id="showModalButton"
                                style="height: 47px; margin-top: -2px;" data-bs-toggle="modal" data-bs-target="#InicioSesion">Modificar</button>
                        </div>
                          </div>

                      </div>
                  </div>
              </div>
              <div class="col-lg-4 col-md-6 ">
                <div class="package-item bg-white ">
                    <div class="p-4">
                        <div class="mt-4 mb-4">
                            <div class="d-flex justify-content-between">
                                <button class="btn btn-primary btn-block" id="showModalButton"
                                    style="height: 47px; margin-top: -2px;" data-bs-toggle="modal" data-bs-target="#InicioSesion">Agregar Anuncio</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
              
            </div>
        </div>
    </div>
</asp:Content>
