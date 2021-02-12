using Core.Entities;

namespace Entities.DTOs
{
    class UserDetailDto :IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}