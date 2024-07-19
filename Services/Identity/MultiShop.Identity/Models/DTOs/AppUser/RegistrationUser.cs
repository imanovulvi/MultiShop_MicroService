using System.ComponentModel.DataAnnotations;

namespace MultiShop.Identity.Models.DTOs.AppUser
{
    public class RegistrationUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
