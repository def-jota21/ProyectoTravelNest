<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dashbord.aspx.cs" Inherits="ProyectoTravelNest.pages.dashbord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet">
    <link href="../Content/style.css" rel="stylesheet" />
    <div id="layoutSidenav_content">
        <main>
            <div class="container-fluid px-4">
                <h1 class="mt-4 mb-5">Dashboard</h1>
                <div class="row">
                    <div class="col-xl-4 col-md-6">
                        <div class="card bg-success text-white mb-4">
                            <div class="card-body">
                                <asp:Label ID="lblCantidadUsuario" Visible="false" runat="server" CssClass="h1 text-white"></asp:Label>
                                <p>Usuarios</p>
                            </div>
                            <div
                                class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link"
                                    href="gestionusuarios.aspx">Ver Usuarios</a>
                                <div class="small text-white">
                                    <i
                                        class="fas fa-angle-right"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-md-6">
                        <div class="card bg-success text-white mb-4">
                            <div class="card-body">
                                <asp:Label ID="Label1" Visible="false" runat="server" CssClass="h1 text-white"></asp:Label>
                                <p>Politicas</p>
                            </div>
                            <div
                                class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link"
                                    href="pantallapoliticas.aspx">Ver Politicas</a>
                                <div class="small text-white">
                                    <i
                                        class="fas fa-angle-right"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-md-6 ">
                        <div class="card bg-success text-white mb-4">
                            <div class="card-body">
                                <asp:Label ID="Label2" Visible="false" runat="server" CssClass="h1 text-white"></asp:Label>
                                <p>Cupones</p>
                            </div>
                            <div
                                class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link"
                                    href="vergenerarcupon.aspx">Ver Cupones</a>
                                <div class="small text-white">
                                    <i
                                        class="fas fa-angle-right"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-md-6">
                        <div class="card bg-success text-white mb-4 ">
                            <div class="card-body">
                                <asp:Label ID="Label3" Visible="false" runat="server" CssClass="h1 text-white"></asp:Label>
                                <p>Categorias</p>
                            </div>
                            <div
                                class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link"
                                    href="tiposalojamiento.aspx">Ver Categorias</a>
                                <div class="small text-white">
                                    <i
                                        class="fas fa-angle-right"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-md-6">
                        <div class="card bg-success text-white mb-4 ">
                            <div class="card-body">
                                <asp:Label ID="Label4" Visible="false" runat="server" CssClass="h1 text-white"></asp:Label>
                                <p>Politicas Inmuebles</p>
                            </div>
                            <div
                                class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link"
                                    href="politicasgestor.aspx">Ver Politicas</a>
                                <div class="small text-white">
                                    <i
                                        class="fas fa-angle-right"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-md-6">
                        <div class="card bg-success text-white mb-4 ">
                            <div class="card-body">
                                <asp:Label ID="Label5" Visible="false" runat="server" CssClass="h1 text-white"></asp:Label>
                                <p>Consulta de denuncias</p>
                            </div>
                            <div
                                class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link"
                                    href="consultadenuncias.aspx">Ver Denuncias</a>
                                <div class="small text-white">
                                    <i
                                        class="fas fa-angle-right"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-md-6">
                        <div class="card bg-success text-white mb-4 ">
                            <div class="card-body">
                                <asp:Label ID="Label6" Visible="false" runat="server" CssClass="h1 text-white"></asp:Label>
                                <p>Configurar Correos</p>
                            </div>
                            <div
                                class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link"
                                    href="configuracioncorreos.aspx">Configurar</a>
                                <div class="small text-white">
                                    <i
                                        class="fas fa-angle-right"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row mb-4 ">
                    <div class="container mt-5">
                        <div class="row mb-4">
                            <div class="col-md-4">
                                <h2 class="text-center">Distribución de Inmuebles</h2>
                                <div class="chart-container" style="position: relative; height: 30vh; width: 100%">
                                    <canvas id="pieChart"></canvas>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <h2 class="text-center">Distribución de Usuarios</h2>
                                <div class="chart-container" style="position: relative; height: 30vh; width: 100%">
                                    <canvas id="pieChartUsuarios"></canvas>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <h2 class="text-center">Distribución de Reservaciones</h2>
                                <div class="chart-container" style="position: relative; height: 30vh; width: 100%">
                                    <canvas id="pieChartReservaciones"></canvas>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="row mb-4 ">
                    <div class="chart-container" style="position: relative; height: 80vh; width: 100%">
                        <canvas id="myChartCategorias"></canvas>
                    </div>
                </div>

            </div>
        </main>

    </div>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"
        crossorigin="anonymous"></script>
    <script src="js/scripts.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/simple-datatables@7.1.2/dist/umd/simple-datatables.min.js"
        crossorigin="anonymous"></script>
    <script src="js/datatables-simple-demo.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <script>
        // Suponiendo que estas variables contienen los datos obtenidos desde el backend
        var contadorActivos = <%= ContadorActivos %>;
        var contadorInactivos = <%= ContadorInactivos %>;

        var ctx = document.getElementById('pieChart').getContext('2d');
        var myPieChart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: ['Inmuebles Activos', 'Inmuebles Inactivos'],
                datasets: [{
                    data: [contadorActivos, contadorInactivos],
                    backgroundColor: ['#007bff', '#dc3545'],
                    hoverBackgroundColor: ['#0056b3', '#c82333']
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
            }
        });
    </script>
    <script>
        var contadorUsuariosActivos = <%= UsuariosActivos %>;
        var contadorUsuariosInactivos = <%= UsuariosInactivos %>;

        var ctxUsuarios = document.getElementById('pieChartUsuarios').getContext('2d');
        var myPieChartUsuarios = new Chart(ctxUsuarios, {
            type: 'pie',
            data: {
                labels: ['Usuarios Activos', 'Usuarios Inactivos'],
                datasets: [{
                    data: [contadorUsuariosActivos, contadorUsuariosInactivos],
                    backgroundColor: ['#007bff', '#dc3545'],
                    hoverBackgroundColor: ['#0056b3', '#c82333']
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
            }
        });
    </script>
    <script>
        // Suponiendo que estas variables contienen los datos obtenidos desde el backend
        var contadorActivosReser = <%= ReserActivos %>;
        var contadorfinal = <%= ReserFinalizados %>;

        var ctxReservaciones = document.getElementById('pieChartReservaciones').getContext('2d');
        var myPieChartReservaciones = new Chart(ctxReservaciones, {
            type: 'pie',
            data: {
                labels: ['Reser. Activas', 'Reser. Finalizadas'],
                datasets: [{
                    data: [contadorActivosReser, contadorfinal],
                    backgroundColor: ['#007bff', '#dc3545'],
                    hoverBackgroundColor: ['#0056b3', '#c82333']
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
            }
        });
    </script>
    <script>
        var nombresCategorias = <%= NombresCategoriasJson %>;
        var cantidadesCategorias = <%= CantidadesCategoriasJson %>;

        var ctxCategorias = document.getElementById('myChartCategorias').getContext('2d');
        var myChartCategorias = new Chart(ctxCategorias, {
            type: 'bar', // Puedes cambiar a 'line', 'pie', etc., según tus preferencias
            data: {
                labels: nombresCategorias,
                datasets: [{
                    label: 'Cantidad de Inmuebles',
                    data: cantidadesCategorias,
                    backgroundColor: '#7AB730',
                    borderColor: '#7AB730',
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    </script>

</asp:Content>
