using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RecapCore.Entities
{
    //Generic constraint
    //Class: Referance type
    //IEntity: May be an IEntity or an object that implements IEntity
    //new (): Should be able to initialize by using new operator (interfaces cant initialize)
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
