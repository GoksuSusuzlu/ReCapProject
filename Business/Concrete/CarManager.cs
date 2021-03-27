using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
            _carDal.Add(car);
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

        public Car GetById(int id)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            return _carDal.GetById(id);
        }

        public void Update(Car car)
        {
            //If-else kontrolleri, yetki kontrolu vs.
            _carDal.Update(car);
        }
    }
}
