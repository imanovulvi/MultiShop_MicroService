using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Catalog
{
    public class ImageService: HttpClientService,IImageService
    {
        public async Task<bool> PostAsync(string url, string productId, IFormFileCollection formFiles, string header = null)
        {
            var content = new MultipartFormDataContent();
            foreach (var file in formFiles)
            {

                var fileStream = file.OpenReadStream();

                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                content.Add(fileContent, "file", file.FileName);
            }

            if (header != null)
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + header);


            var response = await httpClient.PostAsync(url + "/Create?productId=" + productId, content);
            return response.IsSuccessStatusCode;
            
        }
    }
}
