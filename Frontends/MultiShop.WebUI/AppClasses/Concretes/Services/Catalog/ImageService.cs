using MultiShop.DTOs.DTOs.Catalog.Image;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Catalog
{
    public class ImageService: HttpClientService,IImageService
    {
        public async Task<List<ResultImageDTO>> GetImagesProductByIdAsync(string url,string productId,string header=null) 
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await  httpClient.GetAsync(url+ "/GetImagesProductById?productId="+productId);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ResultImageDTO>>(json);
            }
            return null;
        }

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
                AddHeader(header);


            var response = await httpClient.PostAsync(url + "/Create?productId=" + productId, content);
            return response.IsSuccessStatusCode;
            
        }
    }
}
