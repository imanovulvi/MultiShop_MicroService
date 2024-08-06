using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Identity;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Identity;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IIdentityService identityService;
        string urlIdentity = "";

        public UsersController(IIdentityService identityService,IConfiguration configuration)
        {
            this.identityService = identityService;
            urlIdentity = configuration["ServiceUrl:Identity"];
        }
        public async Task<IActionResult> Index()
        {
            return View(await identityService.GetAllAsync<UserInfoDTO>(urlIdentity, HttpContext.Request.Cookies["AccesToken"]));
        }
    }
}
