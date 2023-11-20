<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crearalojamiento.aspx.cs" Inherits="ProyectoTravelNest.pages.crearalojamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <style>
        * {
            padding: 0;
            margin: 0;
            box-sizing: border-box;
            font-family: "Rubik",sans-serif;
        }

        body {
            background-color: #f5f8ff;
        }

        .containerimg {
            background-color: #ffffff;
            width: 60%;
            min-width: 450px;
            position: relative;
            margin: 50px auto;
            padding: 50px 20px;
            border-radius: 7px;
            box-shadow: 0 20px 35px rgba(0,0,0,0.05);
        }

        input[type="file"] {
            display: none;
        }

        .container p {
            text-align: center;
            margin: 20px 0 30px 0;
        }

        images {
            width: 90%;
            position: relative;
            margin: auto;
            display: flex;
            justify-content: space-evenly;
            gap: 20px;
            flex-wrap: wrap;
        }

        figure {
            width: 45%;
        }

        img {
            width: 100%;
        }

        figcaption {
            text-align: center;
            font-size: 2.4vmin;
            margin-top: 0.5vmin;
        }

        /* Estilo para las imágenes previsualizadas */
        .image-preview {
            display: inline-block;
            margin: 10px;
            position: relative;
        }

        /* Estilo para el botón de eliminar */
        .delete-button {
            position: absolute;
            top: 5px;
            right: 5px;
            background-color: red;
            color: white;
            border: none;
            padding: 3px 8px;
            cursor: pointer;
            border-radius: 4px;
        }

        /* Establecer el tamaño máximo de las imágenes previsualizadas */
        .image-preview img {
            max-width: 200px;
            max-height: 200px;
        }

        .delete-icon {
            position: absolute;
            top: 5px;
            right: 5px;
            color: red; /* Color del ícono de eliminación */
            cursor: pointer;
            font-size: 20px; /* Tamaño del ícono de eliminación */
        }
    </style>
    <div class="container mt-5">
        <div class="row">

            <div class="col">
                <h2>Crear Inmueble</h2>
                <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtnombre" CssClass="form-label mt-4">Nombre</asp:Label>
                <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                <asp:Label ID="lblErrorNombre" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblUbicacion" runat="server" AssociatedControlID="txtubicacion" CssClass="form-label mt-4">Ubicación</asp:Label>
                <asp:TextBox ID="txtubicacion" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                <asp:Label ID="lblErrorUbicacion" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <label for="exampleFormControlInput1" class="form-label mt-2">Categoria</label>
                <asp:DropDownList ID="categoria" runat="server" CssClass="form-control" DataTextField="Nombre" DataValueField="IdCategoria">
                </asp:DropDownList>
                <asp:Label ID="lblPrecio" runat="server" CssClass="form-label mt-2" AssociatedControlID="txtprecio">Precio/Noche</asp:Label>
                <asp:TextBox ID="txtprecio" runat="server" type="number" step="0.01" CssClass="form-control" autocomplete="off"></asp:TextBox>
                <asp:Label ID="lblErrorPrecio" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblHuespedes" runat="server" CssClass="form-label mt-2" AssociatedControlID="txthuespedes">Huespedes</asp:Label>
                <asp:TextBox ID="txthuespedes" runat="server" type="number" CssClass="form-control" autocomplete="off"></asp:TextBox>
                <asp:Label ID="lblErrorHuespedes" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblHabitaciones" runat="server" CssClass="form-label mt-2" AssociatedControlID="txthabitaciones">Habitaciones</asp:Label>
                <asp:TextBox ID="txthabitaciones" runat="server" type="number" CssClass="form-control" autocomplete="off"></asp:TextBox>
                <asp:Label ID="lblErrorHabitaciones" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblBaños" runat="server" CssClass="form-label mt-2" AssociatedControlID="txtbaños">Baños</asp:Label>
                <asp:TextBox ID="txtbaños" runat="server" type="number" CssClass="form-control" autocomplete="off"></asp:TextBox>
                <asp:Label ID="lblErrorBanhos" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <label for="exampleFormControlInput1" class="form-label mt-4">Servicios</label>
                 <a href="#" id="editarServicios" class="stretched-link text-danger " style="position: relative; margin-left: 25rem;">Editar</a>
                <label for="exampleFormControlInput1" class="form-label mt-4">Politicas</label>
                <a id="editarPoliticas" class="stretched-link text-danger " style="position: relative; margin-left: 25.3rem;">Editar</a>
                <br>
                <label for="exampleFormControlInput1" class="form-label mt-4">Amenidades</label>
                <a id="editarAmenidades" class="stretched-link text-danger " style="position: relative; margin-left: 23.5rem;">Editar</a>
                <br>
                <label for="exampleFormControlInput1" class="form-label mt-4">Descuentos</label>
                <asp:DropDownList ID="descuentos" runat="server" CssClass="form-control">
                    <asp:ListItem Value="opcion1">Opción 1</asp:ListItem>
                    <asp:ListItem Value="opcion2">Opción 2</asp:ListItem>
                    <asp:ListItem Value="opcion3">Opción 3</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="Label1" runat="server" CssClass="form-label mt-2" AssociatedControlID="txtbaños">Descripcion</asp:Label>
                <asp:TextBox ID="descripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" autocomplete="off"></asp:TextBox>
                <asp:Label ID="lblErrorDescripcion" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <asp:Button ID="btnPublicar" runat="server" CssClass="btn btn-primary btn-lg mt-4" Text="Publicar Alojamiento" OnClick="btnPublicar_Click" />
                <br />


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
        <div class="row">
            <%--<input type="file" id="file-input" accept="image/png, image/jpeg, image/jpg" onchange="preview()" multiple>--%>

            <asp:FileUpload type="file" accept="image/png, image/jpeg, image/jpg" onchange="preview()" ID="fileUpload" runat="server" AllowMultiple="true" />

            <label for="fileUpload">
                <i type="button" id="cargarImagenesButton" class="btn btn-primary mt-4">Cargar imágenes</i>
            </label>
            <asp:Label CssClass="text-center" ID="lblErrorImagenes" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <div class="containerimg">

                <p id="num-of-files">Ninguna Imagen Seleccionada</p>
                <div id="images" class="text-center"></div>
            </div>
        </div>
    </div>
    <!--Modal Servicios-->
    <div class="modal fade" id="serviciosModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static" style="height: auto;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="exampleModalLabel">Servicios</h5>
                    <button type="button" class=" btn btn-primary" data-bs-dismiss="modal"><i class="fa-solid fa-x" style="color: #000000;"></i></button>
                </div>
                <div class="modal-body">
                    <input id="txtid" type="hidden" value="0" />
                    <div class="row  g-2">
                        <div class="col">

                            <asp:DropDownList ID="selectElement" runat="server" CssClass="form-control" DataTextField="Nombre" DataValueField="IdServicio">
                            </asp:DropDownList>
                            <button type="button" class="btn btn-primary mt-4 mb-3" onclick="agregarElemento()">Agregar</button>
                            <asp:HiddenField ID="hiddenElementos" runat="server" />


                            <!-- Lista para mostrar los elementos seleccionados -->
                            <ul id="listaElementos" style="max-height: 200px; overflow-y: auto;"></ul>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" id="guardarServicios" class="btn btn-primary">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <!--Modal Politicas-->
    <div class="modal fade" id="politicasModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static" style="height: auto;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="exampleModalLabel">Politicas</h5>
                    <button type="button" class=" btn btn-primary" data-bs-dismiss="modal"><i class="fa-solid fa-x" style="color: #000000;"></i></button>
                </div>
                <div class="modal-body">
                    <input id="txtid" type="hidden" value="0" />
                    <div class="row  g-2">
                        <div class="col">
                            <asp:DropDownList ID="selectElementPoliticas" runat="server" CssClass="form-control" DataTextField="Nombre" DataValueField="IdPolitica">
                            </asp:DropDownList>
                            <asp:TextBox ID="descripcionPolitica" runat="server" type="text" CssClass="form-control mt-2" autocomplete="off" MinLength="10" MaxLength="60"></asp:TextBox>
                            <button type="button" class="btn btn-primary mt-4 mb-3" onclick="agregarElementoPoliticas()">Agregar</button>

                            <!-- Lista para mostrar los elementos seleccionados -->
                            <ul id="listaElementosPoliticas" style="max-height: 200px; overflow-y: auto;"></ul>
                            <asp:HiddenField ID="hiddenIdsPoliticas" runat="server" />
                            <asp:HiddenField ID="hiddenDescripcionesPoliticas" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" id="guardarPoliticas" class="btn btn-primary">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <!--Modal Amenidades-->
    <div class="modal fade" id="amenidadesModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static" style="height: auto;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="exampleModalLabel">Amenidades</h5>
                    <button type="button" class=" btn btn-primary" data-bs-dismiss="modal"><i class="fa-solid fa-x" style="color: #000000;"></i></button>
                </div>
                <div class="modal-body">
                    <input id="txtid" type="hidden" value="0" />
                    <div class="row  g-2">
                        <div class="col">

                            <asp:DropDownList ID="selectElementAmenidades" runat="server" CssClass="form-control" DataTextField="Nombre" DataValueField="IdAmenidades">
                            </asp:DropDownList>


                            <button type="button" class="btn btn-primary mt-4 mb-3" onclick="agregarElementoAmenidades()">Agregar</button>
                            <asp:HiddenField ID="elementosAmenidades" runat="server" />
                            <!-- Lista para mostrar los elementos seleccionados -->
                            <ul id="listaElementosAmenidades" style="max-height: 200px; overflow-y: auto;"></ul>


                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" id="guardarAmenidades" class="btn btn-primary">Guardar</button>
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

        document.getElementById("cargarImagenesButton").addEventListener("click", function () {
            // Simular clic en el control de carga de archivos
            document.getElementById("<%= fileUpload.ClientID %>").click();
    });



        document.getElementById("guardarServicios").addEventListener("click", function () {
            var listaElementos = document.getElementById("listaElementos").getElementsByTagName("li");

            var idsServicios = [];
            for (var i = 0; i < listaElementos.length; i++) {
                var idServicio = listaElementos[i].getAttribute("data-idservicio");
                idsServicios.push(idServicio);
            }

            // Convertir el array de IDs a una cadena separada por comas
            var idsSeparadosPorComas = idsServicios.join(',');

            // Almacenar los IDs en el HiddenField
            var hiddenElementos = document.getElementById('<%= hiddenElementos.ClientID %>');
        hiddenElementos.value = idsSeparadosPorComas;

        var modal = document.getElementById('serviciosModal');
        $('#serviciosModal').modal('hide');
    });


        document.getElementById("guardarAmenidades").addEventListener("click", function () {
            var listaElementos = document.getElementById("listaElementosAmenidades").getElementsByTagName("li");

            var datos = [];
            for (var i = 0; i < listaElementos.length; i++) {

                var idAmenidad = listaElementos[i].getAttribute("data-idamenidad");
                datos.push(idAmenidad);
            }

            // Convertir el array a una cadena separada por comas
            var datosSeparadosPorComas = datos.join(',');

            // Almacenar los datos en el HiddenField
            var hiddenElementos = document.getElementById('<%= elementosAmenidades.ClientID %>');
        hiddenElementos.value = datosSeparadosPorComas;
        $('#amenidadesModal').modal('hide');
    });

        document.getElementById("guardarPoliticas").addEventListener("click", function () {
            var listaElementos = document.getElementById("listaElementosPoliticas").getElementsByTagName("li");

            var idsPoliticas = [];
            var descripcionesPoliticas = [];
            for (var i = 0; i < listaElementos.length; i++) {

                var idPolitica = listaElementos[i].getAttribute("data-idservicio"); // Asegúrate de que este atributo esté configurado correctamente
                var descripcionPolitica = listaElementos[i].getAttribute("data-descripcion"); // Este es el atributo de descripción que hemos agregado
                idsPoliticas.push(idPolitica);
                descripcionesPoliticas.push(descripcionPolitica);

            }

            // Convertir los arrays a cadenas separadas por comas
            var idsSeparadosPorComas = idsPoliticas.join(',');
            var descripcionesSeparadasPorComas = descripcionesPoliticas.join(',');

            // Almacenar los IDs y las descripciones en HiddenFields
            var hiddenIdsPoliticas = document.getElementById('<%= hiddenIdsPoliticas.ClientID %>');
        var hiddenDescripcionesPoliticas = document.getElementById('<%= hiddenDescripcionesPoliticas.ClientID %>');

        hiddenIdsPoliticas.value = idsSeparadosPorComas;
        hiddenDescripcionesPoliticas.value = descripcionesSeparadasPorComas;

        // Cerrar el modal (si estás usando Bootstrap)
        var modal = document.getElementById('politicasModal');
        $('#politicasModal').modal('hide');
    });

        // Obtener referencias a los elementos HTML
        var fileUpload = document.getElementById('<%= fileUpload.ClientID %>');
    var numOfFiles = document.getElementById("num-of-files");
    var imageContainer = document.getElementById("images");

    // Escuchar el evento de cambio del control de carga de archivos
    fileUpload.addEventListener("change", function () {
        // Limpiar el contenedor de imágenes
        imageContainer.innerHTML = "";

        // Verificar si se seleccionaron archivos
        if (fileUpload.files.length > 0) {
            numOfFiles.textContent = fileUpload.files.length + " Imágenes Seleccionadas";

            // Recorrer los archivos seleccionados
            for (var i = 0; i < fileUpload.files.length; i++) {
                var file = fileUpload.files[i];
                var imageDiv = document.createElement("div");
                imageDiv.className = "image-preview"; // Aplicar clase CSS
                var image = document.createElement("img");
                image.src = URL.createObjectURL(file); // Obtener la URL temporal de la imagen

                // Recorrer los archivos seleccionados
                for (var i = 0; i < fileUpload.files.length; i++) {
                    var file = fileUpload.files[i];
                    var imageDiv = document.createElement("div");
                    imageDiv.className = "image-preview";
                    var image = document.createElement("img");
                    image.src = URL.createObjectURL(file);

                    imageDiv.appendChild(image);

                    var deleteIcon = document.createElement("i");
                    deleteIcon.className = "fa-solid fa-trash delete-icon";

                    // Envolver la lógica de eliminación en una función inmediatamente invocada
                    (function (imageDiv) {
                        deleteIcon.addEventListener("click", function () {
                            imageDiv.remove(); // Elimina el div de imagen correcto
                            fileUpload.value = ""; // Restablece el control de carga de archivos

                            // Actualizar el contador de imágenes seleccionadas
                            numOfFiles.textContent = (fileUpload.files.length > 0) ? fileUpload.files.length + " Imágenes Seleccionadas" : "Ninguna Imagen Seleccionada";
                        });
                    })(imageDiv);

                    imageDiv.appendChild(deleteIcon);
                    imageContainer.appendChild(imageDiv);
                }
            }
        } else {
            numOfFiles.textContent = "Ninguna Imagen Seleccionada";
        }
    });

</script>

<script>
    function agregarElemento() {
        // Obtener el DropDownList y la opción seleccionada
        var ddlSelectElement = document.getElementById("<%= selectElement.ClientID %>");
        var opcionSeleccionada = ddlSelectElement.options[ddlSelectElement.selectedIndex];

        // Crear un nuevo elemento de lista
        var nuevoElemento = document.createElement("li");
        nuevoElemento.style.display = "flex"; // Utilizar flexbox

        // Almacenar el IdServicio como atributo personalizado en el elemento <li>
        nuevoElemento.setAttribute("data-idservicio", opcionSeleccionada.value);

        // Crear una columna para el texto
        var columnaTexto = document.createElement("div");
        columnaTexto.textContent = opcionSeleccionada.text;
        columnaTexto.style.width = "200px"; // Ancho fijo para el texto

        // Crear una columna para el botón eliminar
        var columnaBoton = document.createElement("div");
        columnaBoton.style.marginLeft = "1rem"; // Espacio entre el texto y el botón
        columnaBoton.style.marginTop = "-1rem";

        // Botón para eliminar el elemento
        var botonEliminar = document.createElement("button");
        botonEliminar.className = "btn btn-danger my-3";
        botonEliminar.style.fontSize = "12px";

        var icono = document.createElement("i");
        icono.className = "fa-solid fa-x";
        icono.style.color = "#f5f5f5";

        botonEliminar.appendChild(icono);

        botonEliminar.onclick = function () {
            nuevoElemento.remove(); // Eliminar el elemento de la lista al hacer clic en el botón
        };

        // Agregar el botón de eliminar a la columna de botón
        columnaBoton.appendChild(botonEliminar);

        // Agregar las columnas al elemento de lista
        nuevoElemento.appendChild(columnaTexto);
        nuevoElemento.appendChild(columnaBoton);

        // Agregar el elemento a la lista
        var listaElementos = document.getElementById("listaElementos");
        listaElementos.appendChild(nuevoElemento);
    }

    function agregarElementoPoliticas() {
        // Obtener el DropDownList y la opción seleccionada
        var ddlSelectPoliticas = document.getElementById("<%= selectElementPoliticas.ClientID %>");
        var opcionSeleccionadaPoliticas = ddlSelectPoliticas.options[ddlSelectPoliticas.selectedIndex];

        // Crear un nuevo elemento de lista para políticas
        var nuevoElementoPoliticas = document.createElement("li");
        nuevoElementoPoliticas.style.display = "flex"; // Utilizar flexbox

        var textboxDescripcionPolitica = document.getElementById("<%= descripcionPolitica.ClientID %>"); // Asegúrate de que este es el ID correcto
        var descripcionPolitica = textboxDescripcionPolitica.value;

        // Suponiendo que el valor de la opción es el ID de la política
        var idPolitica = opcionSeleccionadaPoliticas.value;
       

        // Configurar los atributos data-idservicio y data-descripcion
        nuevoElementoPoliticas.setAttribute("data-idservicio", idPolitica);
        nuevoElementoPoliticas.setAttribute("data-descripcion", descripcionPolitica);

        // Crear una columna para el texto
        var columnaTextoPoliticas = document.createElement("div");
        columnaTextoPoliticas.textContent = descripcionPolitica;
        columnaTextoPoliticas.style.width = "200px"; // Ancho fijo para el texto

        // Crear una columna para el botón eliminar
        var columnaBotonPoliticas = document.createElement("div");
        columnaBotonPoliticas.style.marginLeft = "1rem"; // Espacio entre el texto y el botón
        columnaBotonPoliticas.style.marginTop = "-1rem"; // Ajuste para subir el botón

        // Botón para eliminar el elemento de políticas
        var botonEliminarPoliticas = document.createElement("button");
        botonEliminarPoliticas.className = "btn btn-danger my-3";
        botonEliminarPoliticas.style.fontSize = "12px";

        var iconoPoliticas = document.createElement("i");
        iconoPoliticas.className = "fa-solid fa-x";
        iconoPoliticas.style.color = "#f5f5f5";

        botonEliminarPoliticas.appendChild(iconoPoliticas);

        botonEliminarPoliticas.onclick = function () {
            nuevoElementoPoliticas.remove(); // Eliminar el elemento de políticas de la lista al hacer clic en el botón
        };

        // Agregar el botón de eliminar a la columna de botón
        columnaBotonPoliticas.appendChild(botonEliminarPoliticas);

        // Agregar las columnas al elemento de lista
        nuevoElementoPoliticas.appendChild(columnaTextoPoliticas);
        nuevoElementoPoliticas.appendChild(columnaBotonPoliticas);

        // Agregar el elemento de políticas a la lista
        var listaElementosPoliticas = document.getElementById("listaElementosPoliticas");
        listaElementosPoliticas.appendChild(nuevoElementoPoliticas);
    }



    function agregarElementoAmenidades() {
        // Obtener el DropDownList y la opción seleccionada
        var ddlSelectAmenidades = document.getElementById("<%= selectElementAmenidades.ClientID %>");
        var opcionSeleccionadaAmenidades = ddlSelectAmenidades.options[ddlSelectAmenidades.selectedIndex];

        // Crear un nuevo elemento de lista para amenidades
        var nuevoElementoAmenidades = document.createElement("li");
        nuevoElementoAmenidades.style.display = "flex"; // Utilizar flexbox

        // Almacenar el IdAmenidad como atributo personalizado en el elemento <li>
        nuevoElementoAmenidades.setAttribute("data-idamenidad", opcionSeleccionadaAmenidades.value);

        // Crear una columna para el texto
        var columnaTextoAmenidades = document.createElement("div");
        columnaTextoAmenidades.textContent = opcionSeleccionadaAmenidades.text;
        columnaTextoAmenidades.style.width = "200px"; // Ancho fijo para el texto

        // Crear una columna para el botón eliminar
        var columnaBotonAmenidades = document.createElement("div");
        columnaBotonAmenidades.style.marginLeft = "1rem"; // Espacio entre el texto y el botón
        columnaBotonAmenidades.style.marginTop = "-1rem"; // Ajuste para subir el botón

        // Botón para eliminar el elemento de amenidades
        var botonEliminarAmenidades = document.createElement("button");
        botonEliminarAmenidades.className = "btn btn-danger my-3";
        botonEliminarAmenidades.style.fontSize = "12px";

        var iconoAmenidades = document.createElement("i");
        iconoAmenidades.className = "fa-solid fa-x";
        iconoAmenidades.style.color = "#f5f5f5";

        botonEliminarAmenidades.appendChild(iconoAmenidades);

        botonEliminarAmenidades.onclick = function () {
            nuevoElementoAmenidades.remove(); // Eliminar el elemento de amenidades de la lista al hacer clic en el botón
        };

        // Agregar el botón de eliminar a la columna de botón
        columnaBotonAmenidades.appendChild(botonEliminarAmenidades);

        // Agregar las columnas al elemento de lista
        nuevoElementoAmenidades.appendChild(columnaTextoAmenidades);
        nuevoElementoAmenidades.appendChild(columnaBotonAmenidades);

        // Agregar el elemento de amenidades a la lista
        document.getElementById("listaElementosAmenidades").appendChild(nuevoElementoAmenidades);
    }

</script>
</asp:Content>
