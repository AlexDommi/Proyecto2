document.addEventListener("DOMContentLoaded", function () {
    // Ocultar el botón al cargar
    if (btnRegistrarNuevo) {
        document.getElementById("txtId").disabled = true;
        btnRegistrarNuevo.style.display = "none";
    }
});

    const btnNuevo = document.getElementById("btnNuevo");
    const btnRegistrarNuevo = document.getElementById("btnRegistrarNuevo");
    // const btnEditar = document.getElementById("btnEditar");
    const btnSeleccionar = document.getElementById("btnSeleccionar");
    
    // Mostrar al dar clic en btnNuevo
    if (btnNuevo) {
        btnNuevo.addEventListener("click", function () {
            btnRegistrarNuevo.style.display = "block";
            document.getElementById("txtId").value = "";
            document.getElementById("txtNombre").value = "";
            document.getElementById("txtRazonSocial").value = "";
            document.getElementById("txtCorreo").value = "";
            document.getElementById("txtTelefono").value = "";
            document.getElementById("txtDireccion").value = "";
            document.getElementById("txtId").disabled = true;
        });
    }

    if (btnSeleccionar) {
        btnSeleccionar.addEventListener("click", function () {
            e.preventDefault();
            document.getElementById("txtId").disabled = true;
            btnRegistrarNuevo.style.display = "block";
            
        });
    }
    
