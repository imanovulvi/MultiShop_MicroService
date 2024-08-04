using MultiShop.DTOs.DTOs.Comment;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Comment;
using Newtonsoft.Json;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Comment
{
    public class CommentService:HttpClientService,ICommentService
    {
        public async Task<List<ResultCommentDTO>> GetCommentsProductById(string url, string productId, string header = null) 
        {

            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetCommentsProductById?productId=" + productId);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ResultCommentDTO>>(json);
            }
            return null;
        }

    }
}
