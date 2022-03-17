using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        string ConexionMapper(string value);
        Task<IEnumerable<T>> MostrarTodoAsync();
        Task<IEnumerable<T>> FiltrarAsync();
        Task<T> AgregarAsync(T entity);
        Task<T> EditarAsync(T entity);
        Task<T> EliminarAsync(int id);
    }
}
