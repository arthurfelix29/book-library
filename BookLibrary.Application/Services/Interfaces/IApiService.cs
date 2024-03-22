namespace BookLibrary.Application.Services.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<T>> Get<T>(string endpoint);
    }
}