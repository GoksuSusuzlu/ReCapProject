using RecapCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecapCore.Utility.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }

    
}
