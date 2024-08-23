$(document).ready(function () {
    // Inicializar DataTables 
    $('#table_empleado').DataTable({
        "language": {
            url: '//cdn.datatables.net/plug-ins/2.1.4/i18n/es-ES.json',
        },
    });
});

$('#btn_guardar').click(function () {
    // Cierra el modal al guardar los datos
    $('#editModal').modal('hide');

    // Mostrar la alerta de exito
    Swal.fire({
        title: '¡Éxito!',
        text: 'Se guardó de la manera correcta',
        icon: 'success',
        showConfirmButton: false,
        timer: 2000  //  2 segundos
    }).then(() => {

    location.reload();  
    });
});

$('#btn_agregarUser').click(function () {
    // Obtener valores de los campos del formulario
    var nombre = $('#nombre').val();
    var apellido = $('#apellido').val();
    var numeroTelefonico = $('#numeroTelefonico').val();
    var dui = $('#dui').val();
    var tipoEmpleadoId = $('#tipoEmpleado').val();

    // Validar los campos 
    if (nombre === '' || apellido === '' || numeroTelefonico === '' || dui === '' || tipoEmpleadoId === '') {
        // alerta
        Swal.fire({
            title: 'Error',
            text: 'Por favor complete todos los campos.',
            icon: 'error',
            showConfirmButton: true
        });
    } else {
        // Cierrar modal y guardar los datos
        $('#window-notice').hide();  // Cambiar el selector segun el ID del modal
        $('.modal-backdrop').remove();

        // Mostrar la alerta 
        Swal.fire({
            title: '¡Éxito!',
            text: 'Se guardó de la manera correcta',
            icon: 'success',
            showConfirmButton: false,
            timer: 2000  // 2 segundos
        }).then(() => {
            location.reload();
        });
    }
});

$('.btn-editar').click(function () {
    var id = $(this).data('id');
    var nombre = $(this).data('nombre');
    var apellido = $(this).data('apellido');
    var telefono = $(this).data('telefono');
    var dui = $(this).data('dui');

    // Asignar los valores a los campos del modal
    $('#edit-id').val(id);
    $('#edit-nombre').val(nombre);
    $('#edit-apellido').val(apellido);
    $('#edit-telefono').val(telefono);
    $('#edit-dui').val(dui);

    // Mostrar el modal
    $('#editModal').modal('show');
});
//Boton de eliminar
$(document).on('click', '.btn_eliminar', function () {
    var id = $(this).data("id"); // Obtener el id del empleado desde el atributo data-id
    Swal.fire({
        title: '¿Está seguro de eliminar el registro?',
        text: "Verifique antes de continuar",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, eliminar!'
    }).then((result) => {
        if (result.isConfirmed) {
            // Realizar solicitud AJAX para eliminar
            $.ajax({
                url: '/Empleado/DeleteEmployee/' + id, // La URL para la eliminación
                type: 'POST',
                success: function () {
                    Swal.fire(
                        'Eliminado',
                        'Se eliminó el registro correctamente.',
                        'success'
                    ).then(() => {
                        location.reload(); // Recargar la página para actualizar la tabla
                    });
                },
                error: function () {
                    Swal.fire(
                        'Error',
                        'Hubo un error al eliminar el registro.',
                        'error'
                    );
                }
            });
        }
    })
});

document.getElementById("btn_agregar").addEventListener("click", function () {
    // Mostrar el modal
    document.getElementById("window-notice").style.display = "flex";
});

document.getElementById("btn_agregarUser").addEventListener("click", function () {
    // Cerrar el modal
    document.getElementById("window-notice").style.display = "none";
});
document.querySelector(".closeBtn").addEventListener("click", function () {
    // Ocultar el modal
    document.getElementById("window-notice").style.display = "none";
});

// Cerrar el modal al hacer clic fuera del form
window.onclick = function (event) {
    var modal = document.getElementById("window-notice");
    if (event.target == modal) {
        modal.style.display = "none";
    }
}