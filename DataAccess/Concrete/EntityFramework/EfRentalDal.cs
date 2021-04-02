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
                             join cus in context.Customers on r.CustomerId equals cus.Id
                             select new RentalDetailDto { CarId = c.CarId, CompanyName = cus.CompanyName, CustomerId = cus.Id, RentDate = r.RentDate, RentId = r.Id, ReturnDate = r.ReturnDate };

                return new SuccessDataResult<List<RentalDetailDto>>(result.ToList());
            }
        }
    }
}
