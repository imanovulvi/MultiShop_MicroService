using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Identity;
using MultiShop.WebUI.AppClasses.Abstractions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Permissions;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly string urlIdentity;

        public AuthController(IHttpClientFactory httpClientFactory, IConfiguration configuration,ITokenService tokenService)
        {
            httpClient = httpClientFactory.CreateClient();
            urlIdentity = configuration["ServiceUrl:Identity"];
            this.configuration = configuration;
            this.tokenService = tokenService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO request)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(urlIdentity+"/Login", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<LoginResponseDTO>(await response.Content.ReadAsStringAsync());
                if (res.AccessToken !=null)
                {
                  
                    HttpContext.Response.Cookies.Append("AccesToken", res.AccessToken, new CookieOptions { 
                    
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(1)
                   
                    });

                    HttpContext.Response.Cookies.Append("RefreshToken", res.RefreshToken, new CookieOptions
                    {

                        HttpOnly = true,
                        Expires = DateTime.UtcNow.AddDays(1)

                    });

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, await tokenService.TokenReadAsync(res.AccessToken));
               
                    return Redirect("/Home/Index");
                }
                        
            }
            return Redirect("/Auth/Index");
        }

        
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationDTO request)
        {
            request.Role = "User";
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(urlIdentity + "/CreateUser", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Auth/Index");
            }
            return Redirect("/Auth/Registration");
        }
    }
}
