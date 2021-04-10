using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using RecapCore.Aspects.Autofac.Validation;
using RecapCore.Utility.Business;
using RecapCore.Utility.Helpers;
using RecapCore.Utility.Results.Abstract;
using RecapCore.Utility.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            //Needs some refactoring?
            var imageResult = FileHelper.Add(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(Messages.FailedToUploadImage);
            }

            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var imageResult = FileHelper.Delete(carImage.ImagePath);
            if (!imageResult.Success)
            {
                return new ErrorResult(Messages.FailedToDeleteImage);
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByDate(DateTime date)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Date == date));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            //var oldImage = _carImageDal.Get(c => c.Id == carImage.Id);

            //if (oldImage == null)
            //{
            //    return new ErrorResult(Messages.CarImageNotFound);
            //}

            IResult imageResult = FileHelper.Update(file, carImage.ImagePath);
            
            
            if (!imageResult.Success)
            {
                return new ErrorResult(Messages.FailedToUploadImage);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
