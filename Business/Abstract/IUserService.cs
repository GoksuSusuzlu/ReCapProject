using Entities.Concrete;
using RecapCore.Utility.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetByFirstName(string firstName);
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByEmail(string email);
        

    }
}
