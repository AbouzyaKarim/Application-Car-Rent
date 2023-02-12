using Rent.Web.Models;

namespace Rent.Web.Servieces.IService
{
    public interface IBaseService : IDisposable
    {
        public ResponseDto responseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
