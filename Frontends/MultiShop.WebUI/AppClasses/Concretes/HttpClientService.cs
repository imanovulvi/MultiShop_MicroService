using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MultiShop.WebUI.AppClasses.Abstractions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Text;

namespace MultiShop.WebUI.AppClasses.Concretes
{
    public class HttpClientService : IHttpClientService
    {
        public readonly HttpClient httpClient;

        public HttpClientService()
        {
           
            this.httpClient = new HttpClient();
        }
        public async Task<List<T>> GetAllAsync<T>(string url,string header=null) where T : class
        {
            if(header !=null)
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + header);
            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
           


            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            return null;
        }
        public async virtual Task<bool> PostAsync<T>(string url, T obj,string header=null) where T : class
        {
            if (header != null)
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + header);

            StringContent stringConten = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url + "/Create", stringConten);
            return response.IsSuccessStatusCode;
          
        }

        public async Task<bool> DeleteAsync(string url,string id,string header= null)
        {
            if (header != null)
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + header);

            HttpResponseMessage response = await httpClient.DeleteAsync(url + "/Delete?id=" + id);
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> PutAsync<T>(string url,T obj, string header = null) where T : class
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            if (header != null)
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + header);

            HttpResponseMessage response = await httpClient.PutAsync(url + "/Update", stringContent);
            return response.IsSuccessStatusCode;
           
        }

        public async Task<TResult> GetByIdAsync<TResult>(string url, string id,string header) where TResult : class
        {
            if (header != null)
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + header);
            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetById?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(json);
            }
            return null;
        }
    }
}
