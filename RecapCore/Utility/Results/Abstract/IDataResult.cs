using System;
using System.Collections.Generic;
using System.Text;

namespace RecapCore.Utility.Results.Abstract
{
    public interface IDataResult<T>: IResult
    {
        T Data { get; }
    }
}
