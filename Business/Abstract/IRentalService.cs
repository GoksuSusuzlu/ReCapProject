using Entities.Concrete;
using Entities.DTOs;
using RecapCore.Utility.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetByRentDate(DateTime rentDate);
        IDataResult<List<Rental>> GetByReturnDate(DateTime returnDate);
        IDataResult<Rental> GetById(int id);
        IDataResult<Rental> GetByCarId(int carId);

        IDataResult<List<RentalDetailDto>> GetRentalDetails();

    }
}
