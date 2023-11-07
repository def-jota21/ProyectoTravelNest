<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crearalojamiento.aspx.cs" Inherits="ProyectoTravelNest.pages.crearalojamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <style>
*{
    padding: 0;
    margin: 0;
    box-sizing: border-box;
    font-family: "Rubik",sans-serif;
}
body{
    background-color: #f5f8ff;
}
.containerimg{
    background-color: #ffffff;
    width: 60%;
    min-width: 450px;
    position: relative;
    margin:  50px auto;
    padding: 50px 20px;
    border-radius: 7px;
    box-shadow: 0 20px 35px rgba(0,0,0,0.05);
}
input[type="file"]{
    display: none;
}

.container p{
    text-align: center;
    margin: 20px 0 30px 0;
}
#images{
    width: 90%;
    position: relative;
    margin: auto;
    display: flex;
    justify-content: space-evenly;
    gap: 20px;
    flex-wrap: wrap;
}
figure{
    width: 45%;
}
img{
    width: 100%;
}
figcaption{
    text-align: center;
    font-size: 2.4vmin;
    margin-top: 0.5vmin;
}
</style>
    <div class="container mt-5">
        <div class="row">
            
                <div class="col">
                    <h2>Crear Alojamiento</h2>
                    <label for="exampleFormControlInput1" class="form-label mt-4">Ubicacion</label>
                    <input type="text" class="form-control" id="txtubicacion" autocomplete="off">
                    <label for="exampleFormControlInput1" class="form-label mt-2">Categoria</label>
                    <select name="opcion" class="form-control" id="categoria">
                        <option value="opcion1">Opción 1</option>
                        <option value="opcion2">Opción 2</option>
                        <option value="opcion3">Opción 3</option>
                    </select>
                    <label for="exampleFormControlInput1" class="form-label mt-2">Precio/Noche</label>
                    <input type="number" step="0.01" class="form-control" id="txtprecio" autocomplete="off">
                    <label for="exampleFormControlInput1" class="form-label mt-2">Huespedes</label>
                    <input type="number" class="form-control" id="txthuespedes" autocomplete="off">
                    <label for="exampleFormControlInput1" class="form-label mt-4">Servicios</label>
                    <a href="#" id="editarServicios" class="stretched-link text-danger " style="position: relative; margin-left: 25rem;" >Editar</a>
                    <br>
                    <label for="exampleFormControlInput1" class="form-label mt-4">Politicas</label>
                    <a href="#" id="editarPoliticas" class="stretched-link text-danger " style="position: relative;margin-left: 25.3rem;">Editar</a>
                    <br>
                    <label for="exampleFormControlInput1" class="form-label mt-4">Amenidades</label>
                    <a href="#" id="editarAmenidades" class="stretched-link text-danger " style="position: relative;margin-left: 23.5rem;">Editar</a>
                    <br>
                    <label for="exampleFormControlInput1" class="form-label mt-4">Descuentos</label>
                    <select name="opcion" class="form-control" id="descuentos">
                        <option value="opcion1">Opción 1</option>
                        <option value="opcion2">Opción 2</option>
                        <option value="opcion3">Opción 3</option>
                    </select>
                    <input type="file" id="file-input" accept="image/png, image/jpeg, image/jpg" onchange="preview()" multiple>
                    <label for="file-input">
                        <i  type="button" class="btn btn-primary mt-4">Cargar imagenes</i>
                    </label>
                    <div class="containerimg">
                        
                        <p id="num-of-files">Niguna Imagen Seleccionada</p>
                        <div id="images"></div>
                    </div>
                    <button type="button" class="btn btn-primary lx mt-4" >Publicar Alojamiento</button>
                </div>
                <div class="col">
                    <img class="img-fluid" src="../img/about-1.jpg" alt="">

                    <div class="container-fluid py-5">
                        <div class="container pt-5">
                            <div class="row">
                                <div class="col-lg-6" style="min-height: 300px;">
                                    <div class="position-relative h-100">
                                        <img class="position-absolute w-90 h-90" src="../img/about.jpg" style="object-fit: cover;">
                                    </div>
                                </div>
                                <div class="col-lg-6 pt-5 pb-lg-5">
                                    <div class="about-text bg-white p-4 p-lg-5 my-lg-5">
                                        <h2 class="mb-3">Crea una experiencia para los huespedes</h2>
                                        <p>Los huespedes son tus clientes brindales el mejor servicio para tener exito.</p>
                                        <div class="row mb-4">
                                            <div class="col-6">
                                                <img class="img-fluid" src="../img/destination-1.jpg" alt="">
                                            </div>
                                            <div class="col-6">
                                                <img class="img-fluid" src="../img/destination-2.jpg" alt="">
                                            </div>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                </div>
                
        </div>  
    </div>
<!--Modal Servicios-->
    <div class="modal fade"  id="serviciosModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static" style="height: auto;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="exampleModalLabel">Servicios</h5>
                    <button type="button" class=" btn btn-primary" data-bs-dismiss="modal"><i class="fa-solid fa-x" style="color: #000000;"></i></button>
                </div>
                <div class="modal-body">
                    <input id="txtid" type="hidden" value="0"/>
                    <div class="row  g-2">
                        <div class="col">
                            <select id="selectElement" class="form-control">
                                <option value="opcion1">Opción 1</option>
                                <option value="opcion2">Opción 2</option>
                                <option value="opcion3">Opción 3</option>
                            </select>
                            
                              
                            <button type="button" class="btn btn-primary mt-4 mb-3" onclick="agregarElemento()">Agregar</button>
                            
                            <!-- Lista para mostrar los elementos seleccionados -->
                            <ul id="listaElementos"style="max-height: 200px; overflow-y: auto;"></ul>


                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <!--Modal Politicas-->
    <div class="modal fade"  id="politicasModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static" style="height: auto;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="exampleModalLabel">Politicas</h5>
                    <button type="button" class=" btn btn-primary" data-bs-dismiss="modal"><i class="fa-solid fa-x" style="color: #000000;"></i></button>
                </div>
                <div class="modal-body">
                    <input id="txtid" type="hidden" value="0"/>
                    <div class="row  g-2">
                        <div class="col">
                            <select id="selectElementPoliticas" class="form-control">
                                <option value="opcion1">Opción 1</option>
                                <option value="opcion2">Opción 2</option>
                                <option value="opcion3">Opción 3</option>
                            </select>
                            
                              
                            <button type="button" class="btn btn-primary mt-4 mb-3" onclick="agregarElementoPoliticas()">Agregar</button>
                            
                            <!-- Lista para mostrar los elementos seleccionados -->
                            <ul id="listaElementosPoliticas"style="max-height: 200px; overflow-y: auto;"></ul>


                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <!--Modal Amenidades-->
    <div class="modal fade"  id="amenidadesModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static" style="height: auto;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="exampleModalLabel">Amenidades</h5>
                    <button type="button" class=" btn btn-primary" data-bs-dismiss="modal"><i class="fa-solid fa-x" style="color: #000000;"></i></button>
                </div>
                <div class="modal-body">
                    <input id="txtid" type="hidden" value="0"/>
                    <div class="row  g-2">
                        <div class="col">
                            <select id="selectElementAmenidades" class="form-control">
                                <option value="opcion1">Opción 1</option>
                                <option value="opcion2">Opción 2</option>
                                <option value="opcion3">Opción 3</option>
                            </select>
                            
                              
                            <button type="button" class="btn btn-primary mt-4 mb-3" onclick="agregarElementoAmenidades()">Agregar</button>
                            
                            <!-- Lista para mostrar los elementos seleccionados -->
                            <ul id="listaElementosAmenidades"style="max-height: 200px; overflow-y: auto;"></ul>


                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary">Guardar</button>
                </div>
            </div>
        </div>
    </div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
<script>

    document.getElementById("editarServicios").addEventListener("click", function () {
        
        $('#serviciosModal').modal("show");

    });
    document.getElementById("editarPoliticas").addEventListener("click", function () {
        
        $('#politicasModal').modal("show");

    });
    document.getElementById("editarAmenidades").addEventListener("click", function () {
        
        $('#amenidadesModal').modal("show");

    });

    let fileInput = document.getElementById("file-input");
    let imageContainer = document.getElementById("images");
    let numOfFiles = document.getElementById("num-of-files");

    function preview(){
        imageContainer.innerHTML = "";
        numOfFiles.textContent = `${fileInput.files.length} Imagenes Seleccionadas`;

        for(i of fileInput.files){
            let reader = new FileReader();
            let figure = document.createElement("figure");
            let figCap = document.createElement("figcaption");
            figCap.innerText = i.name;
            figure.appendChild(figCap);
            reader.onload=()=>{
                let img = document.createElement("img");
                img.setAttribute("src",reader.result);
                figure.insertBefore(img,figCap);
            }
            imageContainer.appendChild(figure);
            reader.readAsDataURL(i);
        }
    }
</script>

<script>
    function agregarElemento() {
      // Obtener el elemento select y la opción seleccionada
      var select = document.getElementById("selectElement");
      var opcionSeleccionada = select.options[select.selectedIndex];
      
      // Crear un nuevo elemento de lista
      var nuevoElemento = document.createElement("li");
      nuevoElemento.textContent = opcionSeleccionada.text;
      
      // Botón para eliminar el elemento
      var botonEliminar = document.createElement("button");
      botonEliminar.className = "btn btn-danger mt-2";
      botonEliminar.style.fontSize = "12px";
      botonEliminar.style.position = "relative";
      botonEliminar.style.marginLeft = "3rem";
      
      var icono = document.createElement("i");
      icono.className = "fa-solid fa-x";
      icono.style.color = "#f5f5f5";

      botonEliminar.appendChild(icono);

      botonEliminar.onclick = function() {
        nuevoElemento.remove(); // Eliminar el elemento de la lista al hacer clic en el botón
      };

      // Agregar el botón de eliminar al elemento de la lista
      nuevoElemento.appendChild(botonEliminar);
      
      // Agregar el elemento a la lista
      document.getElementById("listaElementos").appendChild(nuevoElemento);
    }

    function agregarElementoPoliticas() {
        // Obtener el elemento select y la opción seleccionada
        var selectPoliticas = document.getElementById("selectElementPoliticas");
        var opcionSeleccionadaPoliticas = selectPoliticas.options[selectPoliticas.selectedIndex];
        
        // Crear un nuevo elemento de lista para políticas
        var nuevoElementoPoliticas = document.createElement("li");
        nuevoElementoPoliticas.textContent = opcionSeleccionadaPoliticas.text;
        
        // Botón para eliminar el elemento de políticas
        var botonEliminarPoliticas = document.createElement("button");
        botonEliminarPoliticas.className = "btn btn-danger mt-2";
        botonEliminarPoliticas.style.fontSize = "12px";
        botonEliminarPoliticas.style.position = "relative";
        botonEliminarPoliticas.style.marginLeft = "3rem";
        
        var iconoPoliticas = document.createElement("i");
        iconoPoliticas.className = "fa-solid fa-x";
        iconoPoliticas.style.color = "#f5f5f5";

        botonEliminarPoliticas.appendChild(iconoPoliticas);

        botonEliminarPoliticas.onclick = function() {
            nuevoElementoPoliticas.remove(); // Eliminar el elemento de políticas de la lista al hacer clic en el botón
        };

        // Agregar el botón de eliminar al elemento de políticas
        nuevoElementoPoliticas.appendChild(botonEliminarPoliticas);
        
        // Agregar el elemento de políticas a la lista
        document.getElementById("listaElementosPoliticas").appendChild(nuevoElementoPoliticas);
    }
    function agregarElementoAmenidades() {
        // Obtener el elemento select y la opción seleccionada
        var selectAmenidades = document.getElementById("selectElementAmenidades");
        var opcionSeleccionadaAmenidades = selectAmenidades.options[selectAmenidades.selectedIndex];
        
        // Crear un nuevo elemento de lista para amenidades
        var nuevoElementoAmenidades = document.createElement("li");
        nuevoElementoAmenidades.textContent = opcionSeleccionadaAmenidades.text;
        
        // Botón para eliminar el elemento de amenidades
        var botonEliminarAmenidades = document.createElement("button");
        botonEliminarAmenidades.className = "btn btn-danger mt-2";
        botonEliminarAmenidades.style.fontSize = "12px";
        botonEliminarAmenidades.style.position = "relative";
        botonEliminarAmenidades.style.marginLeft = "3rem";
        
        var iconoAmenidades = document.createElement("i");
        iconoAmenidades.className = "fa-solid fa-x";
        iconoAmenidades.style.color = "#f5f5f5";

        botonEliminarAmenidades.appendChild(iconoAmenidades);

        botonEliminarAmenidades.onclick = function() {
            nuevoElementoAmenidades.remove(); // Eliminar el elemento de amenidades de la lista al hacer clic en el botón
        };

        // Agregar el botón de eliminar al elemento de amenidades
        nuevoElementoAmenidades.appendChild(botonEliminarAmenidades);
        
        // Agregar el elemento de amenidades a la lista
        document.getElementById("listaElementosAmenidades").appendChild(nuevoElementoAmenidades);
        }


</script>
</asp:Content>
