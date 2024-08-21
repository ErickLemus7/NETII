$('#btn_guardar').click(function () {
    Swal.fire(
        'Exito!',
        'Se guardo de la manera correcta',
        'success'
    )
});
$('#btn_editar').click(function () {
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: 'Se actualizo el registro de la manera correcta',
        showConfirmButton: false,
        timer: 1500
    })
});
$('#btn_eliminar').click(function () {
    Swal.fire({
        title: '¿Esta seguro de eliminar el registro?',
        text: "Verifique antes de continuar",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, eliminar!'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                'Eliminado',
                'Se elimino su registro de la manera correcta',
                'success'
            )
        }
    })
}); 

document.getElementById("btn_agregar").addEventListener("click", function () {
    // Mostrar el modal
    document.getElementById("window-notice").style.display = "flex";
});

document.querySelector(".closeBtn").addEventListener("click", function () {
    // Ocultar el modal
    document.getElementById("window-notice").style.display = "none";
});

// También puedes cerrar el modal al hacer clic fuera del formulario
window.onclick = function (event) {
    var modal = document.getElementById("window-notice");
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
    