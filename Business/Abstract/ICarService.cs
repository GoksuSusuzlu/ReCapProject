using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);
        List<Car> GetByColor(int colorId);
        List<Car> GetByBrandId(int brandId);
        List<Car> GetByModelYear(int modelYear);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        Car GetByDescription(string description);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        List<CarDetailDto> GetCarDetails();
    }
}
