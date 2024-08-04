using MultiShop.DTOs.DTOs.Comment;
using MultiShop.WebUI.AppClasses.Concretes;

namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Comment
{
    public interface ICommentService:IHttpClientService
    {
        Task<List<ResultCommentDTO>> GetCommentsProductById(string url, string productId, string header = null);
    }
}
