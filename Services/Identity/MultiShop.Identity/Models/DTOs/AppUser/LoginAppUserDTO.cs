namespace MultiShop.Identity.Models.DTOs.AppUser
{
    public class LoginAppUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public enum Roles
    {

        Admin = 0,
        Moderator=1
    }
}
