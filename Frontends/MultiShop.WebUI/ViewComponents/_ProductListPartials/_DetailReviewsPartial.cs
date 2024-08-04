using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Comment;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Comment;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _DetailReviewsPartial:ViewComponent
    {
        private readonly ICommentService commentService;
        string url = "";
    


        public _DetailReviewsPartial(ICommentService commentService, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Comment"];
         

            this.commentService = commentService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (ViewBag.id is not null)
            {
            https://localhost:7207/api/Comment/GetCommentsProductById=669793288c396c08bdd22fc5

                return View(await  commentService.GetCommentsProductById(url, ViewBag.id));

                //HttpResponseMessage response = await httpClient.GetAsync(url + "/GetCommentsProductById?productId=" + ViewBag.id);
                //if (response.IsSuccessStatusCode)
                //{
                //  return  View(JsonConvert.DeserializeObject<List<ResultCommentDTO>>(await response.Content.ReadAsStringAsync()));

                //}

            }
            return View();
        }
    }
}
