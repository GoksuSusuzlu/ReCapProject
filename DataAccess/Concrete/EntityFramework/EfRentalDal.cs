using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using RecapCore.DataAccess.EntityFramework;
using RecapCore.Utility.Results.Abstract;
using RecapCore.Utility.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapContext>, IRentalDal
    {
        public IDataResult<List<RentalDetailDto>> GetRentDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join b in context.Brands on c.BrandId equals b.Id
                             join cus in context.Customers on r.CustomerId equals cus.Id
                             join u in context.Users on cus.UserId equals u.Id
                             select new RentalDetailDto { CarId = c.CarId, CompanyName = cus.CompanyName, FirstName = u.FirstName, LastName = u.LastName,
                                                          BrandName = b.Name, RentDate = r.RentDate, RentId = r.Id, ReturnDate = r.ReturnDate };

                return new SuccessDataResult<List<RentalDetailDto>>(result.ToList());
            }
        }
    }
}
