<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pantalla Politicas.aspx.cs" Inherits="ProyectoTravelNest.pages.Pantalla_Politicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html>
<head>
  <title>Prueba de Bootstrap 4</title> 
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="../Content/Politicas.css" rel="stylesheet" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body>
   
  <div class="container center-content" style="font-family: 'Comfortaa';">
    <h1>Información de Nuestras Políticas:</h1>
    
    <div class="row">
      <!-- Primera fila con 2 tarjetas arriba -->
      <div class="col-lg-6 col-md-6 col-sm-12">
          <div class="card rounded custom-card" style="background: rgba(149, 207, 72, 0.4); border: 1px solid #ddd;">
            <div class="card-body">
              <h4 class="card-title">Mi Banco</h4>
              <p class="card-text">
                Tomamos medidas contra los infractores para proteger la 
                integridad de la plataforma de Airbnb y mitigar los riesgos y
                las pérdidas en relación con el fraude, la estafa y el abuso.
                <span id="texto-adicional-mi-banco" style="display: none;">
                   Lo que no permitimos:
                        Extorsión: los anfitriones y los huéspedes no deben usar amenazas directas o 
                        indirectas para coaccionar a un individuo o grupo para 
                        obtener un resultado deseado (por ejemplo, un pago, una reseña, etc.).
                        Actividad fuera de la plataforma: los anfitriones y los huéspedes no pueden comunicarse, 
                        compartir información de contacto personal, pagar ni solicitar el 
                        pago de una reservación o experiencia fuera de la plataforma de Airbnb.
                        Abuso de cupones y invitaciones: los anfitriones y los huéspedes no deben intentar hacer un 
                        uso indebido del programa de cupones e invitaciones de Airbnb.
                        Reembolsos no fraudulentos: los anfitriones y los huéspedes no deben intentar hacer un uso
                        indebido o realizar afirmaciones falsas para obtener un reembolso.
                </span>
                <a href="#" class="btn btn-primary" id="ver-mas-mi-banco">Ver más</a>
              </p>
            </div>
          </div>          
      </div>

      <div class="col-lg-6 col-md-6 col-sm-12">        
        <div class="card rounded custom-card" style="background: rgba(149, 207, 72, 0.4); border: 1px solid #ddd;">
            <div class="card-body">
                <h4 class="card-title">Contenido y reseñas</h4>
                <p class="card-text">
                    Teniendo en consideración a todos los miembros de nuestra comunidad, 
                    restringimos cierto contenido en línea. Esto se aplica a descripciones
                    e imágenes de alojamientos y Experiencias. Esta página ofrece 
                    pautas generales sobre las políticas de la comunidad de Airbnb 
                    y no cubre todos los escenarios posibles.
                    
                    <span id="texto-adicional-contenido-reseñas" style="display: none;">
                     Escribir reseñas relevantes e imparciales
                     Queremos que confíes en que las reseñas que lees en Airbnb son auténticas,
                     confiables y útiles. Las reseñas son útiles si las personas que evalúan 
                        cuentan con precisión su experiencia y 
                        brindan opiniones honestas, ya sean positivas o negativas.
                     Lo que no permitimos
                    Manipulación de reseñas: intentar influir en la reseña de un huésped o
                        de un anfitrión mediante amenazas o incentivos está prohibido en nuestra comunidad.
                    Reseñas de la competencia: los competidores conocidos de un anfitrión
                        específico no pueden dejar una reseña negativa con la intención de disuadir a los huéspedes
                        de reservar el alojamiento o la Experiencia de ese anfitrión.
                    Conflicto de intereses: no se aceptan reservaciones creadas solo para intentar manipular 
                        el sistema de evaluaciones con reseñas y calificaciones falsas.
                    Evaluaciones irrelevantes o sesgadas: podemos eliminar las reseñas sesgadas, 
                        vengativas o que no incluyan información relevante o útil.
                    Infracción de contenido: está prohibido en nuestra comunidad cualquier otro 
                        contenido que no cumpla con la Política sobre el contenido de Airbnb.  
                    </span>
                    <a href="#" class="btn btn-primary" id="ver-mas-contenido-reseñas">Ver más</a>
                </p>
            </div>
        </div>          
    </div>
    </div>
  
    <!-- Segunda fila con 2 tarjetas abajo -->
    <div class="row">
      <div class="col-lg-6 col-md-6 col-sm-12">        
          <div class="card rounded custom-card" style="background: rgba(149, 207, 72, 0.4); border: 1px solid #ddd;">
            <div class="card-body">
              <h4 class="card-title">Seguridad</h4>
              <p class="card-text">
                Para ayudar a garantizar estadías, experiencias e interacciones seguras, 
                no se permiten ciertas actividades y comportamientos en nuestra comunidad.
                 Defensa personal: si alguna vez te atacan físicamente durante una estadía o experiencia, 
                  puedes defenderte con fuerza proporcional hasta que el peligro haya cesado.
                <span id="texto-adicional-seguridad" style="display: none;">
                  Armas permitidas: con excepción de los dispositivos explosivos o incendiarios y las armas de asalto, 
                  como huésped, solo puedes traer armas de propiedad legal o armas no letales si 
                  las guardas de forma segura e le informas al anfitrión antes de llegar. 
                  Como anfitrión, puedes mantener armas de propiedad legal en tu alojamiento
                  siempre que estén guardadas de forma segura. 
                  Es necesario informar a los huéspedes sobre las armas que 
                  se encuentren a la vista o en un lugar donde puedan encontrarlas.
                </span>
                <a href="#" class="btn btn-primary" id="ver-mas-seguridad">Ver más</a>
              </p>
            </div>
          </div>          
      </div>

      <div class="col-lg-6 col-md-6 col-sm-12">        
          <div class="card rounded custom-card" style="background: rgba(149, 207, 72, 0.4); border: 1px solid #ddd;">
            <div class="card-body">
              <h4 class="card-title">Cancelaciones y reembolsos</h4>
              <p class="card-text">
                Esta Política de reembolso y asistencia para cambio de reservación explica cómo ayudaremos al huésped 
                  a encontrar un alojamiento alternativo y cómo gestionamos los reembolsos cuando un anfitrión cancela
                  una reservación o cuando un Contratiempo de Viaje impide el correcto desarrollo de una estadía.
                <span id="texto-adicional-cancelaciones" style="display: none;">
               ¿Qué sucede si un anfitrión cancela la reservación antes del check-in?
                  Si un anfitrión cancela una reservación antes del check-in, el huésped recibirá automáticamente un reembolso total.
                    Además, si el anfitrión cancela cuando falten 30 días o menos antes del check-in y el huésped se
                    comunica con nosotros, lo ayudaremos a encontrar un alojamiento similar o mejor.
               ¿Qué ocurre si otro Contratiempo de Viaje afecta mi estadía?
                    El resto de los Contratiempos de Viaje se nos deben informar, a más tardar, en un plazo de 72
                    horas desde que se tenga constancia de ellos. Si determinamos que un Contratiempo de Viaje ha 
                    impedido el correcto desarrollo de la estadía, tramitaremos un reembolso completo o parcial y, en función de
                    las circunstancias, podremos prestar asistencia al huésped para que encuentre un alojamiento similar o mejor. 
                    El monto del reembolso depende de la gravedad del Contratiempo de Viaje, las repercusiones para el huésped, la 
                    fracción de la estadía que se haya visto afectada y si el huésped abandona o no el alojamiento.
                    Si el huésped decide abandonar el alojamiento debido al Contratiempo de Viaje y se comunica con nosotros, 
                    le ofreceremos asistencia para que encuentre otro alojamiento similar o mejor donde hospedarse durante 
                    las noches restantes de su estadía.
                </span>
                <a href="#" class="btn btn-primary" id="ver-mas-cancelaciones">Ver más</a>
              </p>
            </div>
          </div>          
      </div>
    </div>
  </div>
</div>
  <script>
      document.addEventListener("DOMContentLoaded", function () {
          const verMasBtnMiBanco = document.getElementById("ver-mas-mi-banco");
          const textoAdicionalMiBanco = document.getElementById("texto-adicional-mi-banco");
          verMasBtnMiBanco.addEventListener("click", function (event) {
              event.preventDefault();
              if (textoAdicionalMiBanco.style.display === "none") {
                  textoAdicionalMiBanco.style.display = "block";
                  verMasBtnMiBanco.textContent = "Ver menos";
              } else {
                  textoAdicionalMiBanco.style.display = "none";
                  verMasBtnMiBanco.textContent = "Ver más";
              }
          });

          const verMasBtnContenidoResenas = document.getElementById("ver-mas-contenido-reseñas");
          const textoAdicionalContenidoResenas = document.getElementById("texto-adicional-contenido-reseñas");
          verMasBtnContenidoResenas.addEventListener("click", function (event) {
              event.preventDefault();
              if (textoAdicionalContenidoResenas.style.display === "none") {
                  textoAdicionalContenidoResenas.style.display = "block";
                  verMasBtnContenidoResenas.textContent = "Ver menos";
              } else {
                  textoAdicionalContenidoResenas.style.display = "none";
                  verMasBtnContenidoResenas.textContent = "Ver más";
              }
          });

          const verMasBtnSeguridad = document.getElementById("ver-mas-seguridad");
          const textoAdicionalSeguridad = document.getElementById("texto-adicional-seguridad");
          verMasBtnSeguridad.addEventListener("click", function (event) {
              event.preventDefault();
              if (textoAdicionalSeguridad.style.display === "none") {
                  textoAdicionalSeguridad.style.display = "block";
                  verMasBtnSeguridad.textContent = "Ver menos";
              } else {
                  textoAdicionalSeguridad.style.display = "none";
                  verMasBtnSeguridad.textContent = "Ver más";
              }
          });

          const verMasBtnCancelaciones = document.getElementById("ver-mas-cancelaciones");
          const textoAdicionalCancelaciones = document.getElementById("texto-adicional-cancelaciones");
          verMasBtnCancelaciones.addEventListener("click", function (event) {
              event.preventDefault();
              if (textoAdicionalCancelaciones.style.display === "none") {
                  textoAdicionalCancelaciones.style.display = "block";
                  verMasBtnCancelaciones.textContent = "Ver menos";
              } else {
                  textoAdicionalCancelaciones.style.display = "none";
                  verMasBtnCancelaciones.textContent = "Ver más";
              }
          });
      });
  </script>
</body>
</html>
</asp:Content>
