using System;
using System.Collections.Generic;
using System.Text;

namespace RecapCore.Utility.Results.Concrete
{
    public class SuccessResult: Result
    {
        public SuccessResult(): base(true)
        {

        }

        public SuccessResult(string message): base(true, message)
        {

        }
    }
}
