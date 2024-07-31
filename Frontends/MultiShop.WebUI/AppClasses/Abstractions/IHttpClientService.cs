namespace MultiShop.WebUI.AppClasses.Abstractions
{
    public interface IHttpClientService
    {
        Task<List<T>> GetAllAsync<T>(string url, string header = null) where T : class;
        Task<bool> PostAsync<T>(string url, T obj, string header = null) where T : class;
        Task<bool> DeleteAsync(string url, string id, string header=null);
        Task<bool> PutAsync<T>(string url, T obj, string header = null) where T : class;

        Task<TResult> GetByIdAsync<TResult>(string url, string id, string header = null) where TResult : class;
    }
}
