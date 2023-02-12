using AutoMapper;
using Rent.Service.VoitureAPI.Models;
using Rent.Service.VoitureAPI.Models.Dto;

namespace Rent.Service.VoitureAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<VoitureDto, Voiture>();
                config.CreateMap<Voiture, VoitureDto>();
            }
            );

            return mappingConfig;
        }
    }
}
