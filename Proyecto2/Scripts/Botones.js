document.addEventListener("DOMContentLoaded", function () {
    // Ocultar el botón al cargar
    if (btnRegistrarNuevo) {
        document.getElementById("txtId").disabled = true;S
    }
});

    const btnNuevo = document.getElementById("btnNuevo");
    const btnRegistrarNuevo = document.getElementById("btnRegistrarNuevo");
    const btnSubeImagen = document.getElementById("btnSubeImagen");
    const btnSeleccionar = document.getElementById("btnSeleccionar");
    const btnAgregarItem = document.getElementById("btnAgregarItem");

    if (btnNuevo) {
        btnNuevo.addEventListener("click", function () {
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

    if (btnSeleccionar) {
        btnSeleccionar.addEventListener("click", function () {
            e.preventDefault();
            document.getElementById("txtId").disabled = true;
            btnRegistrarNuevo.style.display = "block";

        });
}

if (btnAgregarItem) {
    btnAgregarItem.addEventListener("click", function () {
        e.preventDefault();
    });
}

