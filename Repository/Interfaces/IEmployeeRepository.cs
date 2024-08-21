using EjemploASP.Models;

namespace EjemploASP.Repository.Interfaces
{
    //Recordar que las interfaces son contratos
    public interface IEmployeeRepository
    {
        Empleado AddEmployee (Empleado employee); //Agregar Empleado
        Empleado UpdateEmployee(Empleado employee); //Actualizar Empleado
        void DeleteEmployee(int id);   //Eliminar Empleado
        List<Empleado> ObtenerEmployee();  //Obtener las lista de empleados
    }
}
