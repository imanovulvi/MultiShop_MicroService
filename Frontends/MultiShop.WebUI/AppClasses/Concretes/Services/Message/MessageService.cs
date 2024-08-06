

using MultiShop.DTOs.DTOs.Message;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Message;
using Newtonsoft.Json;
using System.Security.Policy;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Message
{
    public class MessageService:HttpClientService,IMessageService
    {
        public async Task<List<ResultMessageDTO>> GetInboxMessageAsync(string id,string url,string header)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetInboxMessage?receiverId="+id);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ResultMessageDTO>>(json);
            }
            return null;
        }

        public async Task<List<ResultMessageDTO>> GetSenderMessageAsync(string id, string url, string header)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetSenderMessage?senderId=" + id);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ResultMessageDTO>>(json);
            }
            return null;
        }
    }
}
