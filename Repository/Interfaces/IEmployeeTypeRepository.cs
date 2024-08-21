using EjemploASP.Models;

namespace EjemploASP.Repository.Interfaces
{
    public interface IEmployeeTypeRepository
    {
            TipoEmpleado AddTipoEmployee(TipoEmpleado employee); //Agregar Empleado
            TipoEmpleado UpdateTipoEmployee(TipoEmpleado employee); //Actualizar Empleado
            void DeleteTipoEmployee(int id);   //Eliminar Empleado
            List<TipoEmpleado> ObtenerTipoEmployee();  //Obtener las lista de empleados
    }
}
