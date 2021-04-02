using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using RecapCore.DataAccess.EntityFramework;
using RecapCore.Utility.Results.Abstract;
using RecapCore.Utility.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join clr in context.Colors on c.ColorId equals clr.Id 
                             join b in context.Brands on c.BrandId equals b.Id
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.Name, ColorName = clr.Name, DailyPrice = c.DailyPrice, Description = c.Description };


                return new SuccessDataResult<List<CarDetailDto>>(result.ToList());
            }
        }
    }
}
