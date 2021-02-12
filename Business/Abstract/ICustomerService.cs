using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customers customers);
        IResult Update(Customers customers);
        IResult Delete(Customers customers);
        IDataResult<List<Customers>> GetAll();
        IDataResult<Customers> GetById(int userId);
    }
}