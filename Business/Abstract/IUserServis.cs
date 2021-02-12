using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserServis
    {
        IResult Add(Users users);
        IResult Update(Users users);
        IResult Delete(Users users);
        IDataResult<List<Users>> GetAll();
    }
}