using Microsoft.AspNetCore.Identity;

namespace MultiShop.Identity.Models.Entitys
{
    public class AppUser:IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
