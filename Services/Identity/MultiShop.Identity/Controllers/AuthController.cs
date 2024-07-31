using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Identity.Models.AppClass;
using MultiShop.Identity.Models.Context;
using MultiShop.Identity.Models.DTOs.AppUser;
using MultiShop.Identity.Models.Entitys;
using MultiShop.Identity.Services.Abstactions;
using System.Security.Claims;

namespace MultiShop.Identity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;
        private readonly AppIdentityDBContext context;

        public AuthController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager,ITokenService tokenService,AppIdentityDBContext context,IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenService = tokenService;
            this.configuration = configuration;
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateAppUserDTO request) 
        {
           

            AppUser appUser = new() { 
            Name= request.Name,
            Surname= request.Surname,
            UserName= request.UserName,
            Email= request.Email,
            PasswordHash= request.Password
            
            };

         

           var result=await  userManager.CreateAsync(appUser);

            if (result.Succeeded)
            {

                await userManager.AddToRoleAsync(appUser, request.Role);


                return Ok("Qeydiyyat bas catdi");
            }
                
            
            return Ok("Errors");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAppUserDTO request)
        {


            var result = await userManager.FindByEmailAsync(request.Email);
           
            if (result is not null)
            {
                if (result.PasswordHash==request.Password)
                {
                    List<Claim> claims = new() {
                    new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
                    new Claim(ClaimTypes.Email, result.Email),
                    new Claim(ClaimTypes.Name, result.Name),
                    new Claim(ClaimTypes.Surname, result.Surname),
                    new Claim(ClaimTypes.Name, result.Name),

                    
                    };
                    foreach (var item in await userManager.GetRolesAsync(result))
                    {
                        claims.Add(new Claim(ClaimTypes.Role,item));
                    }
                    Token token =tokenService.GetTokens(claims, DateTime.UtcNow.AddMinutes(int.Parse(configuration["JWT:expires"])));

                    result.RefreshToken=token.RefreshToken;
                    result.RefreshTokenExpire=token.RefreshTokenExpire;
                    context.Users.Update(result);
                   await context.SaveChangesAsync();
                    return Ok(token);
                }
                else
                {
                    return Ok(new Token());
                }
            }
            else
            {
                return Ok(new Token());
            }


            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(string request)
        {


            var rol = await roleManager.RoleExistsAsync(request);
            if (!rol)
            {
               var result= await roleManager.CreateAsync(new AppRole { Name=request});
                if(result.Succeeded)
                    return Ok("elave edildi");
            }
            else
                return Ok("Artiq var");


            return Ok("Errors");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UserInfo(Guid id)
        {

            AppUser user = await context.Users.FindAsync(id);
            AppUserInfo userInfo =new() 
            {
                Id=user.Id,
                Name=user.Name,
                Surname=user.Surname,
                Email=user.Email,
                UserName=user.UserName
            };

            return Ok(userInfo);
        }
    }
}
