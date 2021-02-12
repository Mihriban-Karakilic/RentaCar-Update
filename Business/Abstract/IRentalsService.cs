using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IResult Add(Rentals rentals);
        IResult Update(Rentals rentals);
        IResult Delete(Rentals rentals);
        IDataResult<List<Rentals>> GetAll();
    }
}