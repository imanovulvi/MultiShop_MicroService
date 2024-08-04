using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Comment;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Comment;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {

        private readonly ICommentService commentService;
        string urlComment = "";
        public ProductListController(ICommentService commentService,IConfiguration configuration)
        {
           
            urlComment = configuration["ServiceUrl:Comment"];
            this.commentService = commentService;
        }

        public IActionResult Index(string id)
        {
            ViewBag.Id = id;    
            return View();
        }

        public IActionResult Detail(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDTO dto)
        {
            dto.CreateDate = DateTime.Now;
            dto.Status = true;
            dto.Rating = 2;

            if (await commentService.PostAsync(urlComment, dto, HttpContext.Request.Cookies["AccesToken"]))
            {
                return RedirectToAction("Index", "ProductList");
            }
            return View();
        }
    }
}
