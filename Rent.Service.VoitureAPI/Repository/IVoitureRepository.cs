using Rent.Service.VoitureAPI.Models.Dto;

namespace Rent.Service.VoitureAPI.Repository
{
    public interface IVoitureRepository
    {
        Task<IEnumerable<VoitureDto>> GetVoitures();
        Task<VoitureDto> GetVoitureById(int voitureId);
        Task<VoitureDto> CreateUpdateVoiture(VoitureDto voitureDto);
        Task<bool> DeleteVoiture(int voitureId);
    }
}
