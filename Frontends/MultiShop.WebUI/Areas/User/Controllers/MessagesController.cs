using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Message;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Message;
using System.Security.Claims;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessagesController : Controller
    {
        private readonly IMessageService messageService;
        string urlMessage = "";
        public MessagesController(IMessageService messageService,IConfiguration configuration)
        {
            this.messageService = messageService;
            urlMessage = configuration["ServiceUrl:Message"];
        }
        public async Task<IActionResult> InboxMessage()
        {
            Claim? claim = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            return View(await messageService.GetInboxMessageAsync(claim.Value,urlMessage, HttpContext.Request.Cookies["AccesToken"]));
        }

        public async Task<IActionResult> SenderMessage()
        {
            Claim? claim = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            return View(await messageService.GetSenderMessageAsync(claim.Value, urlMessage, HttpContext.Request.Cookies["AccesToken"]));
        }
    }
}
