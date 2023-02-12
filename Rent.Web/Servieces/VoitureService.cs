using Rent.Web.Models;
using Rent.Web.Servieces.IService;

namespace Rent.Web.Servieces
{
    public class VoitureService : BaseService, IVoitureService
    {
        private readonly IHttpClientFactory _clientFactory;

        public VoitureService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }
        public ResponseDto responseModel { get; set; }
        public async Task<T> CreateVoitureAsync<T>(VoitureDto voitureDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apitype = SD.APIType.POST,
                URL = SD.VoitureAPIBase + "/api/voitures",
                AccessToken = "",
                DATA = voitureDto
            });
        }

        public async Task<T> DeleteVoitureAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apitype = SD.APIType.DELETE,
                URL = SD.VoitureAPIBase + "/api/voitures/"+id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllVoituressAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apitype = SD.APIType.GET,
                URL = SD.VoitureAPIBase + "/api/voitures",
                AccessToken = ""
            });
        }

        public async Task<T> GetByVoitureIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apitype = SD.APIType.GET,
                URL = SD.VoitureAPIBase + "/api/voitures/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateVoitureAsync<T>(VoitureDto voitureDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apitype = SD.APIType.PUT,
                URL = SD.VoitureAPIBase + "/api/voitures",
                AccessToken = "",
                DATA = voitureDto
            });
        }
    }
}
