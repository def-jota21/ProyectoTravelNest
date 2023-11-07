<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="promociones.aspx.cs" Inherits="ProyectoTravelNest.pages.promociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/stylesInmueble.css" rel="stylesheet" />
    <div class="container" style="margin-top: 6vh;">
        <h1>Agregar promoción</h1>
        <h5>Ingrese, modifique o elimine una promoción según sea necesario.</h5>

        <div class="container-fluid mt-5">
            <div class="row">
                <!-- Carta -->
                <div class="flex-row-reverse d-flex justify-content-around">
                    <div class="col-lg-3 col-md-5 p-0 mb-5 me-4 bg-white rounded">
                        <div class="bg-white mb-2">
                            <img class="img-fluid" src="../img/inmueble.jpg" style="border-radius: 7px;">
                            <div style="clear: both;">
                                <h5 class="ms-1">Islas Canarias</h5>
                                <label class="text-muted">Lorem ipsum dolor sit amet consectetur adipisicing elit. Vero
                                    quae ipsum quas accusantium eum, consectetur...</label>
                                <div class="border-top mt-4 pt-4">
                                    <div class="d-flex justify-content-around">
                                        <h6 class="m-0"><i class="fa fa-star text-primary"></i>4.5 <small>(250)</small>
                                        </h6>
                                        <h5 class="m-0">$350</h5>
                                        <p><b>por noche</b></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="col-md-5">
                        <!-- Promoción #1 -->
                        <div style="background-color: #F9F9F9;" class="p-3 mb-3 rounded-3">
                            <div class="d-flex justify-content-between">
                                <h5>1. Promoción</h5>
                                <div style="right: 0; display: inline-flex; margin-top: -6px;">
                                    <button style="color: transparent; background-color: transparent; border: none; height: 0; margin: 0;">
                                        <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 512 512">
                                            <path d="M471.6 21.7c-21.9-21.9-57.3-21.9-79.2 0L362.3 51.7l97.9 97.9 30.1-30.1c21.9-21.9 21.9-57.3 0-79.2L471.6 21.7zm-299.2 220c-6.1 6.1-10.8 13.6-13.5 21.9l-29.6 88.8c-2.9 8.6-.6 18.1 5.8 24.6s15.9 8.7 24.6 5.8l88.8-29.6c8.2-2.7 15.7-7.4 21.9-13.5L437.7 172.3 339.7 74.3 172.4 241.7zM96 64C43 64 0 107 0 160V416c0 53 43 96 96 96H352c53 0 96-43 96-96V320c0-17.7-14.3-32-32-32s-32 14.3-32 32v96c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V160c0-17.7 14.3-32 32-32h96c17.7 0 32-14.3 32-32s-14.3-32-32-32H96z"/>
                                        </svg>
                                    </button>
                                    
                                    <button style="color: transparent; background-color: transparent; border: none; height: 0; margin: 0;">
                                        <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 448 512">
                                            <path d="M64 32C28.7 32 0 60.7 0 96V416c0 35.3 28.7 64 64 64H384c35.3 0 64-28.7 64-64V173.3c0-17-6.7-33.3-18.7-45.3L352 50.7C340 38.7 323.7 32 306.7 32H64zm0 96c0-17.7 14.3-32 32-32H288c17.7 0 32 14.3 32 32v64c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V128zM224 288a64 64 0 1 1 0 128 64 64 0 1 1 0-128z"/>
                                        </svg>
                                    </button>

                                    <button style="color: transparent; background-color: transparent; border: none; height: 0; margin: 0;">
                                        <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 448 512">
                                            <path d="M135.2 17.7C140.6 6.8 151.7 0 163.8 0H284.2c12.1 0 23.2 6.8 28.6 17.7L320 32h96c17.7 0 32 14.3 32 32s-14.3 32-32 32H32C14.3 96 0 81.7 0 64S14.3 32 32 32h96l7.2-14.3zM32 128H416V448c0 35.3-28.7 64-64 64H96c-35.3 0-64-28.7-64-64V128zm96 64c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16zm96 0c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16zm96 0c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16z"/>
                                        </svg>
                                    </button>
                                </div>
                            </div>
                            <label>
                                Lorem ipsum dolor sit amet consectetur, adipisicing elit. Quisquam, sequi deleniti.
                                Voluptates voluptate ipsum velit exercitationem.
                            </label>
                        </div>
                        
                        <!-- Promoción #2 -->
                        <div style="background-color: #F9F9F9;" class="p-3 mb-3 rounded-3">
                            <div class="d-flex justify-content-between">
                                <h5>2. Promoción</h5>
                                <div style="right: 0; display: inline-flex; margin-top: -6px;">
                                    <button style="color: transparent; background-color: transparent; border: none; height: 0; margin: 0;">
                                        <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 512 512">
                                            <path d="M471.6 21.7c-21.9-21.9-57.3-21.9-79.2 0L362.3 51.7l97.9 97.9 30.1-30.1c21.9-21.9 21.9-57.3 0-79.2L471.6 21.7zm-299.2 220c-6.1 6.1-10.8 13.6-13.5 21.9l-29.6 88.8c-2.9 8.6-.6 18.1 5.8 24.6s15.9 8.7 24.6 5.8l88.8-29.6c8.2-2.7 15.7-7.4 21.9-13.5L437.7 172.3 339.7 74.3 172.4 241.7zM96 64C43 64 0 107 0 160V416c0 53 43 96 96 96H352c53 0 96-43 96-96V320c0-17.7-14.3-32-32-32s-32 14.3-32 32v96c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V160c0-17.7 14.3-32 32-32h96c17.7 0 32-14.3 32-32s-14.3-32-32-32H96z"/>
                                        </svg>
                                    </button>
                                    
                                    <button style="color: transparent; background-color: transparent; border: none; height: 0; margin: 0;">
                                        <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 448 512">
                                            <path d="M64 32C28.7 32 0 60.7 0 96V416c0 35.3 28.7 64 64 64H384c35.3 0 64-28.7 64-64V173.3c0-17-6.7-33.3-18.7-45.3L352 50.7C340 38.7 323.7 32 306.7 32H64zm0 96c0-17.7 14.3-32 32-32H288c17.7 0 32 14.3 32 32v64c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V128zM224 288a64 64 0 1 1 0 128 64 64 0 1 1 0-128z"/>
                                        </svg>
                                    </button>

                                    <button style="color: transparent; background-color: transparent; border: none; height: 0; margin: 0;">
                                        <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 448 512">
                                            <path d="M135.2 17.7C140.6 6.8 151.7 0 163.8 0H284.2c12.1 0 23.2 6.8 28.6 17.7L320 32h96c17.7 0 32 14.3 32 32s-14.3 32-32 32H32C14.3 96 0 81.7 0 64S14.3 32 32 32h96l7.2-14.3zM32 128H416V448c0 35.3-28.7 64-64 64H96c-35.3 0-64-28.7-64-64V128zm96 64c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16zm96 0c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16zm96 0c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16z"/>
                                        </svg>
                                    </button>
                                </div>
                            </div>
                            <label>
                                Lorem ipsum dolor sit amet consectetur, adipisicing elit. Quisquam, sequi deleniti.
                                Voluptates voluptate ipsum velit exercitationem.
                            </label>
                        </div>

                        <!-- Agregar Promoción -->
                        <div class="p-3 mb-3 rounded-3">
                            <div class="d-flex justify-content-center">
                                <button style="width: 100%; height: 100%; padding: 10px 0px;" class="align-items-center rounded-3" id="agregar-promocion">
                                    <svg style="fill: #9e9e9e" xmlns="http://www.w3.org/2000/svg" height="4em" viewBox="0 0 448 512">
                                        <path d="M256 80c0-17.7-14.3-32-32-32s-32 14.3-32 32V224H48c-17.7 0-32 14.3-32 32s14.3 32 32 32H192V432c0 17.7 14.3 32 32 32s32-14.3 32-32V288H400c17.7 0 32-14.3 32-32s-14.3-32-32-32H256V80z"/>
                                    </svg>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
