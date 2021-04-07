using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using RecapCore.Aspects.Autofac.Validation;
using RecapCore.CrossCuttingConcerns.Validation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //If-else kontrolleri, yetki kontrolu vs.

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //If-else kontrolleri, yetki kontrolu vs.
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarsListed); 
        }

        public IDataResult<List<Car>> GetByColor(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarsListed); 
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarsListed);
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
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Data); 
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            //If-else kontrolleri, yetki kontrolu vs.

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
