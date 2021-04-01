using System;
using System.Collections.Generic;
using System.Text;

namespace RecapCore.Utility.Results.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
