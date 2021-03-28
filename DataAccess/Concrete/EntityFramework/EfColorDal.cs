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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            //IDisposable pattern implementation of C#
            using (RecapContext context = new RecapContext())
            {
                var addedEntity = context.Entry(entity);//Referansı yakala
                addedEntity.State = EntityState.Added;//Hangi islemin yapilacagini belirt
                context.SaveChanges();//Degisiklikleri kaydet
            }
        }

        public void Delete(Color entity)
        {
            //IDisposable pattern implementation of C#
            using (RecapContext context = new RecapContext())
            {
                var deletedEntity = context.Entry(entity);//Referansı yakala
                deletedEntity.State = EntityState.Deleted;//Hangi islemin yapilacagini belirt
                context.SaveChanges();//Degisiklikleri kaydet
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RecapContext context = new RecapContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                return filter == null
                ? context.Set<Color>().ToList()
                : context.Set<Color>().Where(filter).ToList();

            }
        }

        public void Update(Color entity)
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
