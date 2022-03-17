using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>>MostrarTodoAsync();
        Task<T>FiltrarAsync(Expression<Func<T, bool>> expression);
        Task<T> AgregarAsync(T entity);
        Task<T> EditarAsync(T entity);
        Task<T> EliminarAsync(T entity);

    }
}
