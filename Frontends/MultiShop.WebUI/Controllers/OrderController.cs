using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Order.Adress;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Order;
using System.Security.Claims;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAdressService adressService;
        string urlAdress = "";
        public OrderController(IAdressService adressService,IConfiguration configuration)
        {
            this.adressService = adressService;
            urlAdress = configuration["ServiceUrl:Adress"];
        }
        public async Task<IActionResult> Index()
        {
            Claim? claim = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            ResultAdressDTO resultAdressDTO = new() 
            {
            City="", Country="",Destrict="", Detail1="",Detail2="",UserId = "",ZipCode=""
            };

            ResultAdressDTO userAdress=await adressService.GetByUserIdAsync(urlAdress, claim.Value, HttpContext.Request.Cookies["AccesToken"]);
            if (userAdress != null) 
                return View(userAdress);

            return View(resultAdressDTO);
        }
    }
}
