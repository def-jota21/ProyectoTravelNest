<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dashbord.aspx.cs" Inherits="ProyectoTravelNest.pages.dashbord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/style.css" rel="stylesheet" />
    <div id="layoutSidenav_content">
        <main>
            <div class="container-fluid px-4">
                <h1 class="mt-4 mb-5">Dashboard</h1>
                <div class="row">
                    <div class="col-xl-4 col-md-6">
                        <div class="card bg-primary text-white mb-4">
                            <div class="card-body">
                                <asp:Label ID="lblCantidadUsuario" visible="false" runat="server" CssClass="h1 text-white"></asp:Label>
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
                        <div class="card bg-warning text-white mb-4">
                            <div class="card-body">
                                <asp:Label ID="Label1" visible="false" runat="server" CssClass="h1 text-white"></asp:Label>
                                <p>Politicas</p>
                            </div>
                            <div
                                class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link"
                                    href="gestionusuarios.aspx">Ver Politicas</a>
                                <div class="small text-white">
                                    <i
                                        class="fas fa-angle-right"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                </div>
                <div class="row">
                    <div class="col-xl-6">
                                <div class="card mb-4">
                                    <div class="card-header">
                                        <i class="fas fa-chart-area me-1"></i>
                                        Area Chart Example
                                    </div>
                                    <div class="card-body"><canvas id="myAreaChart" width="100%" height="40"></canvas></div>
                                </div>
                            </div>
                            <div class="col-xl-6">
                                <div class="card mb-4">
                                    <div class="card-header">
                                        <i class="fas fa-chart-bar me-1"></i>
                                        Bar Chart Example
                                    </div>
                                    <div class="card-body"><canvas id="myBarChart" width="100%" height="40"></canvas></div>
                                </div>
                            </div>
                </div>
                <div class="row">
                    <div class="col-xl-4">
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fa-solid fa-cake-candles fa-sm"></i>
                                Celebraciones
                                                               
                            </div>
                            <div class="card-body">
                                <p><b>Próximos Cumpleaños</b></p>
                                <ul class="list-group">
                                    <li
                                        class="list-group-item d-flex justify-content-between align-items-center">
                                        <a class="small text stretched-link"
                                            href="#">Ana Cristina
                                                                                                Fuentes Arroyo</a>
                                        <span
                                            class="badge bg-primary rounded-pill"><i
                                                class="fa-solid fa-calendar-days fa-xs"></i>
                                            Ago, 27 - Ago, 28</span>
                                    </li>
                                    <li
                                        class="list-group-item d-flex justify-content-between align-items-center">
                                        <a class="small text stretched-link"
                                            href="#">Atticus
                                                                                                Lincoln</a>
                                        <span
                                            class="badge bg-primary rounded-pill"><i
                                                class="fa-solid fa-calendar-days fa-xs"></i>
                                            Ago, 27 - Ago, 28</span>
                                    </li>
                                </ul>

                            </div>
                        </div>
                    </div>

                    <div class="col-xl-4">
                        <div class="card mb-4">
                            <div class="card-header">
                                <i
                                    class="fa-solid fa-right-from-bracket fa-sm"></i>
                                Quién está fuera
                                                               
                            </div>
                            <div class="card-body">
                                <p><b>Durante este mes</b></p>
                                <ul class="list-group">
                                    <li
                                        class="list-group-item d-flex justify-content-between align-items-center">
                                        <a class="small text stretched-link"
                                            href="#">Ana Cristina
                                                                                                Fuentes Arroyo</a>
                                        <span
                                            class="badge bg-primary rounded-pill"><i
                                                class="fa-solid fa-calendar-days fa-xs"></i>
                                            Ago, 27 - Ago, 28</span>
                                    </li>
                                    <li
                                        class="list-group-item d-flex justify-content-between align-items-center">
                                        <a class="small text stretched-link"
                                            href="#">Atticus
                                                                                                Lincoln</a>
                                        <span
                                            class="badge bg-primary rounded-pill"><i
                                                class="fa-solid fa-calendar-days fa-xs"></i>
                                            Ago, 27 - Ago, 28</span>
                                    </li>
                                </ul>

                            </div>
                        </div>
                    </div>

                    <div class="col-xl-4">
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fa-solid fa-hourglass-end fa-sm"></i>
                                A punto de Terminar
                                                               
                            </div>
                            <div class="card-body">
                                <p><b>Empleados Contractuales</b></p>
                                <p>No se han encontrado empleados</p>

                                <p><b>Empleados en Prácticas</b></p>
                                <ul class="list-group">
                                    <li
                                        class="list-group-item d-flex justify-content-between align-items-center">
                                        <a class="small text stretched-link"
                                            href="#">Ana Cristina
                                                                                                Fuentes Arroyo</a>
                                        <span
                                            class="badge bg-primary rounded-pill">Ago,
                                                                                                27</span>
                                    </li>
                                    <li
                                        class="list-group-item d-flex justify-content-between align-items-center">
                                        <a class="small text stretched-link"
                                            href="#">Atticus
                                                                                                Lincoln</a>
                                        <span
                                            class="badge bg-primary rounded-pill">Ago,
                                                                                                27</span>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="card mb-4">
                    <div class="card-header">
                        <i class="fa-solid fa-microphone fa-sm"></i>
                        Últimos Anuncios
                                               
                    </div>
                    <div class="card-body">
                        <ol class="list-group list-group-numbered">
                            <li
                                class="list-group-item d-flex justify-content-between align-items-start">
                                <div class="ms-2 me-auto">
                                    <div class="fw-bold">
                                        26 de Julio,
                                                                                        Feriado
                                    </div>
                                    Se traslada el feriado del 25 de julio
                                                                                por la Anexión del Partido de Nicoya, al
                                                                                Lunes 26 de Julio.
                                                                       
                                </div>
                                <span
                                    class="badge bg-primary rounded-pill">5-08-2023</span>
                            </li>
                        </ol>
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
    <script src="assets/demo/chart-area-demo.js"></script>
    <script src="assets/demo/chart-bar-demo.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
    
    <script src="https://cdn.jsdelivr.net/npm/simple-datatables@7.1.2/dist/umd/simple-datatables.min.js"
        crossorigin="anonymous"></script>
    <script src="js/datatables-simple-demo.js"></script>

    <script>
        // Set new default font family and font color to mimic Bootstrap's default styling
        Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
        Chart.defaults.global.defaultFontColor = '#292b2c';

        // Bar Chart Example
        var ctx = document.getElementById("myBarChart");
        var myLineChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ["January", "February", "March", "April", "May", "June"],
                datasets: [{
                    label: "Revenue",
                    backgroundColor: "rgba(2,117,216,1)",
                    borderColor: "rgba(2,117,216,1)",
                    data: [4215, 5312, 6251, 7841, 9821, 14984],
                }],
            },
            options: {
                scales: {
                    xAxes: [{
                        time: {
                            unit: 'month'
                        },
                        gridLines: {
                            display: false
                        },
                        ticks: {
                            maxTicksLimit: 6
                        }
                    }],
                    yAxes: [{
                        ticks: {
                            min: 0,
                            max: 15000,
                            maxTicksLimit: 5
                        },
                        gridLines: {
                            display: true
                        }
                    }],
                },
                legend: {
                    display: false
                }
            }
        });

        Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
        Chart.defaults.global.defaultFontColor = '#292b2c';

        // Area Chart Example
        var ctx = document.getElementById("myAreaChart");
        var myLineChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["Mar 1", "Mar 2", "Mar 3", "Mar 4", "Mar 5", "Mar 6", "Mar 7", "Mar 8", "Mar 9", "Mar 10", "Mar 11", "Mar 12", "Mar 13"],
                datasets: [{
                    label: "Sessions",
                    lineTension: 0.3,
                    backgroundColor: "rgba(2,117,216,0.2)",
                    borderColor: "rgba(2,117,216,1)",
                    pointRadius: 5,
                    pointBackgroundColor: "rgba(2,117,216,1)",
                    pointBorderColor: "rgba(255,255,255,0.8)",
                    pointHoverRadius: 5,
                    pointHoverBackgroundColor: "rgba(2,117,216,1)",
                    pointHitRadius: 50,
                    pointBorderWidth: 2,
                    data: [10000, 30162, 26263, 18394, 18287, 28682, 31274, 33259, 25849, 24159, 32651, 31984, 38451],
                }],
            },
            options: {
                scales: {
                    xAxes: [{
                        time: {
                            unit: 'date'
                        },
                        gridLines: {
                            display: false
                        },
                        ticks: {
                            maxTicksLimit: 7
                        }
                    }],
                    yAxes: [{
                        ticks: {
                            min: 0,
                            max: 40000,
                            maxTicksLimit: 5
                        },
                        gridLines: {
                            color: "rgba(0, 0, 0, .125)",
                        }
                    }],
                },
                legend: {
                    display: false
                }
            }
        });
    </script>
</asp:Content>
