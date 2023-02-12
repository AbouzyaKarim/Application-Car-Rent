using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rent.Service.VoitureAPI.DbContexts;
using Rent.Service.VoitureAPI.Models;
using Rent.Service.VoitureAPI.Models.Dto;

namespace Rent.Service.VoitureAPI.Repository
{
    public class VoitureRepository : IVoitureRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public VoitureRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<VoitureDto> CreateUpdateVoiture(VoitureDto voitureDto)
        {
            Voiture voiture = _mapper.Map<VoitureDto, Voiture>(voitureDto);
            if (voiture.VoitureId > 0)
            {
                _db.Voitures.Update(voiture);
            }
            else
            {
                _db.Voitures.Add(voiture);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Voiture, VoitureDto>(voiture);
        }

        public async Task<bool> DeleteVoiture(int voitureId)
        {
            try
            {
                Voiture voiture = await _db.Voitures.FirstOrDefaultAsync(u => u.VoitureId == voitureId);
                if (voiture == null)
                {
                    return false;
                }
                _db.Voitures.Remove(voiture);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public async Task<VoitureDto> GetVoitureById(int voitureId)
        {
            Voiture voiture = await _db.Voitures.Where(x => x.VoitureId == voitureId).FirstOrDefaultAsync();

            return _mapper.Map<VoitureDto>(voiture);
        }

        public async Task<IEnumerable<VoitureDto>> GetVoitures()
        {
            List<Voiture> voituresList = await _db.Voitures.ToListAsync();
            return _mapper.Map<List<VoitureDto>>(voituresList);
        }
    }
}
