using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MultiShop.Comment.Context;
using ET=MultiShop.Comment.Entitys;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentDBContext context;

        public CommentController(CommentDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            return Ok(await context.Comments.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await context.Comments.FindAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsProductById(string productId)
        {
            return Ok(context.Comments.Where(x=>x.ProductId==productId));
        }



        [HttpPost]
        public async Task<IActionResult> Create(ET.Comment comment)
        {
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
            return Ok("Elave olundu");
        }


        [HttpPut]
        public async Task<IActionResult> Update(ET.Comment comment)
        {
             context.Comments.Update(comment);
            await context.SaveChangesAsync();
            return Ok("Yenilendi");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var comment =await context.Comments.FindAsync(id);
            context.Remove(comment);
            await context.SaveChangesAsync();
            return Ok("Yenilendi");
        }
    }
}
