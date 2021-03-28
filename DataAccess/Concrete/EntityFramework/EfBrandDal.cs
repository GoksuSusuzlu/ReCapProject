using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            //IDisposable pattern implementation of C#
            using (RecapContext context = new RecapContext())
            {
                var addedEntity = context.Entry(entity);//Referansı yakala
                addedEntity.State = EntityState.Added;//Hangi islemin yapilacagini belirt
                context.SaveChanges();//Degisiklikleri kaydet
            }
        }

        public void Delete(Brand entity)
        {
            //IDisposable pattern implementation of C#
            using (RecapContext context = new RecapContext())
            {
                var deletedEntity = context.Entry(entity);//Referansı yakala
                deletedEntity.State = EntityState.Deleted;//Hangi islemin yapilacagini belirt
                context.SaveChanges();//Degisiklikleri kaydet
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RecapContext context = new RecapContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                return filter == null
                ? context.Set<Brand>().ToList()
                : context.Set<Brand>().Where(filter).ToList();

            }
        }

        public void Update(Brand entity)
        {
            //IDisposable pattern implementation of C#
            using (RecapContext context = new RecapContext())
            {
                var updatedEntity = context.Entry(entity);//Referansı yakala
                updatedEntity.State = EntityState.Modified;//Hangi islemin yapilacagini belirt
                context.SaveChanges();//Degisiklikleri kaydet
            }
        }
    }
}
