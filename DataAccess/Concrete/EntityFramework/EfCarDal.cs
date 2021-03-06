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
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.Name, ColorName = clr.Name, DailyPrice = c.DailyPrice, 
                                                       Description = c.Description, BrandId = c.BrandId };

                return new SuccessDataResult<List<CarDetailDto>>(result.ToList());
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join clr in context.Colors on c.ColorId equals clr.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             where c.BrandId == brandId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId
                             };
                             

                return new SuccessDataResult<List<CarDetailDto>>(result.ToList());
            }
        }

        public IDataResult<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join clr in context.Colors on c.ColorId equals clr.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             where c.CarId == carId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId
                             };


                return new SuccessDataResult<CarDetailDto>(result.SingleOrDefault());
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join clr in context.Colors on c.ColorId equals clr.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             where c.ColorId == colorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId
                             };


                return new SuccessDataResult<List<CarDetailDto>>(result.ToList());
            }
        }
    }
}
