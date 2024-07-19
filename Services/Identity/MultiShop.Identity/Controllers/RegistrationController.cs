using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Identity.Models.Context;
using MultiShop.Identity.Models.DTOs.AppUser;
using MultiShop.Identity.Models.Entitys;

namespace MultiShop.Identity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly AppIdentityDBContext context;

        public RegistrationController(AppIdentityDBContext context)
        {

            this.context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationUser user) 
        {

                AppUser appUser = new()
                {
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    PasswordHash = user.Password

                };
                var result = context.Users.Add(appUser);

                if (await context.SaveChangesAsync()>0)
                {
                    return Ok("Istifadeci olusduruldu");
                }
                return Ok("Sehvlik bas verdi");

         
            
        }
    }
}
