﻿using DataAccess.Abstract;
using Entities.Concrete;
using RecapCore.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal: EfEntityRepositoryBase<CarImage, RecapContext>, ICarImageDal
    {
    }
}
