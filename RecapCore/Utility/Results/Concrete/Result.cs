using RecapCore.Utility.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecapCore.Utility.Results.Concrete
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success, string message): this(success)
        {
            Message = message;
        }
    }
}
