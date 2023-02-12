using Rent.Web.Models;

namespace Rent.Web.Servieces.IService
{
    public interface IVoitureService : IBaseService
    {
        Task<T> GetAllVoituressAsync<T>();
        Task<T> GetByVoitureIdAsync<T>(int id);
        Task<T> CreateVoitureAsync<T>(VoitureDto voitureDto);
        Task<T> UpdateVoitureAsync<T>(VoitureDto voitureDto);
        Task<T> DeleteVoitureAsync<T>(int id);
    }
}
