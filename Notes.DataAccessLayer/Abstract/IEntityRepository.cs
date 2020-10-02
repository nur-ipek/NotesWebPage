using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DataAccessLayer.Abstract
{
    interface IEntityRepository<T>
    {
        int Save();
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> where);
        int Insert(T obj);
        int Delete(T obj);
        int Update(T obj);
        T Find(Expression<Func<T, bool>> where);
     
    }
}
