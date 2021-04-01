using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using RecapCore.Utility.Results.Abstract;
using RecapCore.Utility.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colordal;

        public ColorManager(IColorDal colordal)
        {
            _colordal = colordal;
        }

        public IResult Add(Color color)
        {
            _colordal.Add(color);
            return new SuccessResult("Color added successfully");
        }

        public IResult Delete(Color color)
        {
            _colordal.Delete(color);
            return new SuccessResult("Color deleted successfully");
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colordal.Get(p => p.Id == id));
        }

        public IResult Update(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult("Color updated successfully");
        }
    }
}
