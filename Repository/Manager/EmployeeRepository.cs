using EjemploASP.Data;
using EjemploASP.Models;
using EjemploASP.Repository.Interfaces;

namespace EjemploASP.Repository.Manager
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBcontext _dbcontext;  //Inyeccion de dependencias

        EmployeeRepository(ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;                        //Repositorio
        }
        public Empleado AddEmployee(Empleado employee)
        {
            throw new NotImplementedException();
            _dbcontext.Empleado.Add(employee); //Agregar una entidad
            _dbcontext.SaveChanges();          //Guardar Cambios
            return employee;                   //Retornar mismo objeto
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
            
            var mp = _dbcontext.Empleado.Where(x => x.Id == id).FirstOrDefault(); 
            _dbcontext.Remove(mp); //Se guarda en una variable y luego se remueve
            _dbcontext.SaveChanges();
            //Expresion lambda para eliminar por no existe metodo
            //Se utiliza where para comparar los ID
            
        }

        public List<Empleado> ObtenerEmployee()
        {
            throw new NotImplementedException();
             return _dbcontext.Empleado.ToList();
            //Agregar todos los empleados a la lista
            
        }

        public Empleado UpdateEmployee(Empleado employee)
        {
            throw new NotImplementedException();
            _dbcontext.Update(employee);
            _dbcontext.SaveChanges();
            //Actualizar los empleados
            return employee;
        }
    }
}
