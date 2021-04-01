﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using RecapCore.Utility.Results.Abstract;
using RecapCore.Utility.Results.Concrete;
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
        public IResult Add(Car car)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            if(car.Description.Length >= 5 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult("Car added successfully.");
            }
            else
            {
                return new ErrorResult("You cannot add a car which has e description shorter than 5 characters or a dailyprice of 0");
            }
        }

        public IResult Delete(Car car)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            _carDal.Delete(car);
            return new SuccessResult("Car deleted successfully.");
        }

        public IDataResult<List<Car>> GetAll()
        {
            //If-else kontrolleri, yetki kontrolu vs.
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), "Cars listed by brand ID."); 
        }

        public IDataResult<List<Car>> GetByColor(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), "Cars listed by color ID."); 
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), "Cars listed by their daily prices.");
        }

        public IDataResult<Car> GetByDescription(string description)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Description == description));
        }

        public IDataResult<Car> GetById(int id)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }


        public IDataResult<List<Car>> GetByModelYear(int modelYear)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == modelYear)); 
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails()); 
        }

        public IResult Update(Car car)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            if (car.Description.Length >= 5 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult("Car updated successfully");
            }
            else
            {
                return new ErrorResult("You cannot add a car which has e description shorter than 5 characters or a dailyprice of 0");
            }
        }
    }
}
