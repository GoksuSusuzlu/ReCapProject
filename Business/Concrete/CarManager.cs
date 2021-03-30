using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            if(car.Description.Length >= 5 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                throw new Exception("You cannot add a car which has e description shorter than 5 characters or a dailyprice of 0");
            }
        }

        public void Delete(Car car)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //If-else kontrolleri, yetki kontrolu vs.
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetByColor(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public Car GetByDescription(string description)
        {
            return _carDal.Get(c => c.Description == description);
        }

        public Car GetById(int id)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            return _carDal.Get(c=> c.CarId == id);
        }


        public List<Car> GetByModelYear(int modelYear)
        {
            return _carDal.GetAll(c => c.ModelYear == modelYear);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            if (car.Description.Length >= 5 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
            }
            else
            {
                throw new Exception("You cannot add a car which has e description shorter than 5 characters or a dailyprice of 0");
            }
        }
    }
}
