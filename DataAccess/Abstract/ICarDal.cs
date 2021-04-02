﻿using Entities.Concrete;
using Entities.DTOs;
using RecapCore.Entities;
using RecapCore.Utility.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
