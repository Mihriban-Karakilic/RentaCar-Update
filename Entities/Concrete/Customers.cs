using Entities.Abstract;

namespace Entities.Concrete
{
    public class Customers :IEntity
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}