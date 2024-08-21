using EjemploASP.Data;
using EjemploASP.Models;
using EjemploASP.Repository.Interfaces;

namespace EjemploASP.Repository.Manager
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        private readonly ApplicationDBcontext _dbcontext;  //Inyeccion de dependencias

        EmployeeTypeRepository (ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;                        //Repositorio
        }
        public TipoEmpleado AddTipoEmployee(TipoEmpleado Temployee)
        {
            _dbcontext.Add(Temployee);
            _dbcontext.SaveChanges();
            throw new NotImplementedException();
        }

        public void DeleteTipoEmployee(int id)
        {
            throw new NotImplementedException();
            var tp = _dbcontext.TipoEmpleado.Where(x => x.Id == id);
            _dbcontext.Remove(tp);
            _dbcontext.SaveChanges();
        }

        public List<TipoEmpleado> ObtenerTipoEmployee()
        {
            throw new NotImplementedException();
            return _dbcontext.TipoEmpleado.ToList();
        }

        public TipoEmpleado UpdateTipoEmployee(TipoEmpleado Temployee)
        {
            throw new NotImplementedException();
            _dbcontext.Update(Temployee);
            _dbcontext.SaveChanges ();
        }
    }
}
