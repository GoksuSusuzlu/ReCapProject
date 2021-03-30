using Microsoft.EntityFrameworkCore;
using RecapCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecapCore.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>: IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//Referansı yakala
                addedEntity.State = EntityState.Added;//Hangi islemin yapilacagini belirt
                context.SaveChanges();//Degisiklikleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//Referansı yakala
                deletedEntity.State = EntityState.Deleted;//Hangi islemin yapilacagini belirt
                context.SaveChanges();//Degisiklikleri kaydet
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//Referansı yakala
                updatedEntity.State = EntityState.Modified;//Hangi islemin yapilacagini belirt
                context.SaveChanges();//Degisiklikleri kaydet
            }
        }
    }
}
