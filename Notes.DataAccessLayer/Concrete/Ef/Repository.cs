using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Notes.Common;
using Notes.DataAccessLayer;
using Notes.DataAccessLayer.Abstract;
using Notes.DataAccessLayer.Concrete.Ef;
using Notes.Entities;

namespace Notes.DataAccessLayer.Concrete
{
    public class Repository<T>: RepositoryBase, IEntityRepository<T> where T: class
    {
        private DbSet<T> _objectSet; //private !!!
        public Repository() 
        {
            _objectSet = context.Set<T>();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        public List<T> GetList()
        {
            return _objectSet.ToList();
        }
        public List<T> GetList(Expression<Func<T,bool>> where)
        {
           return _objectSet.Where(where).ToList();
        }
        public int Insert (T obj)
        {
            _objectSet.Add(obj);
            if(obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;
                DateTime now = DateTime.Now;

                o.CreatedOn = now;
                o.ModifiedOn = now;
                o.ModifiedUserName = App.Common.GetUsername();
            }
            return Save();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }
        public int Update(T obj)
        {
            return Save();
        }
        public T Find(Expression<Func<T,bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
        
    }
}
