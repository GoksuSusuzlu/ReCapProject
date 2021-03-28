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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //IDisposable pattern implementation of C#
            using (RecapContext context = new RecapContext())
            {
                var addedEntity = context.Entry(entity);//Referansı yakala
                addedEntity.State = EntityState.Added;//Hangi islemin yapilacagini belirt
                context.SaveChanges();//Degisiklikleri kaydet
            }
        }

        public void Delete(Car entity)
        {
            //IDisposable pattern implementation of C#
            using (RecapContext context = new RecapContext())
            {
                var deletedEntity = context.Entry(entity);//Referansı yakala
                deletedEntity.State = EntityState.Deleted;//Hangi islemin yapilacagini belirt
                context.SaveChanges();//Degisiklikleri kaydet
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using(RecapContext context = new RecapContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                return filter == null
                ? context.Set<Car>().ToList()
                : context.Set<Car>().Where(filter).ToList();

            }
        }

        public void Update(Car entity)
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
