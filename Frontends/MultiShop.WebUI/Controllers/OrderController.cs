using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Basket;
using MultiShop.DTOs.DTOs.Identity;
using MultiShop.DTOs.DTOs.Order;
using MultiShop.DTOs.DTOs.Order.Adress;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Basket;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Identity;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Order;
using System.Security.Claims;

namespace MultiShop.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IAdressService adressService;
        private readonly IIdentityService identityService;
      
        string urlAdress = "";
        string urlIdentity = "";
       
        public OrderController(IAdressService adressService, IIdentityService identityService,IConfiguration configuration)
        {
            this.adressService = adressService;
            this.identityService = identityService;
            urlAdress = configuration["ServiceUrl:Order:Adress"];
            urlIdentity = configuration["ServiceUrl:Identity"];

        }
        public async Task<IActionResult> Index()
        {
            Claim? claim = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            ResultOrderInfoDTO resultAdressWithUser = new()
            { Country = " ", City = " ", Destrict = " ", Detail1 = " ", Detail2 = "  ", ZipCode = "  " };

            UserInfoDTO userInfo = await identityService.GetUserInfoAsync(urlIdentity, claim.Value, HttpContext.Request.Cookies["AccesToken"]);

            if (userInfo != null)
            {
                ResultAdressDTO userAdress = await adressService.GetByUserIdAsync(urlAdress, claim.Value, HttpContext.Request.Cookies["AccesToken"]);

                if (userAdress != null)
                {
                    resultAdressWithUser = new()
                    {
                        UserId = userInfo.Id,
                        Surname = userInfo.Surname,
                        Name = userInfo.Name,
                        Email = userInfo.Email,
                        Country = userAdress.Country,
                        City = userAdress.City,
                        Destrict = userAdress.Destrict,
                        Detail1 = userAdress.Detail1,
                        Detail2 = userAdress.Detail2,
                        ZipCode = userAdress.ZipCode
                    };
                }
               
            }
           

          return View(resultAdressWithUser);

        }
    }
}
