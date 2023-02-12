using Microsoft.AspNetCore.Mvc;
using Rent.Service.VoitureAPI.Models.Dto;
using Rent.Service.VoitureAPI.Repository;

namespace Rent.Service.VoitureAPI.Controllers
{
    [Route("api/voitures")]
    public class VoitureAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IVoitureRepository _voitureRepository;

        public VoitureAPIController(IVoitureRepository voitureRepository)
        {
            this._voitureRepository = voitureRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<VoitureDto> voituresDtos = await _voitureRepository.GetVoitures();
                _response.Result = voituresDtos;
            }
            catch (Exception e)
            {

                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{voitureId}")]
        public async Task<object> GetById(int voitureId)
        {
            try
            {
                VoitureDto model = await _voitureRepository.GetVoitureById(voitureId);
                _response.Result = model;
            }
            catch (Exception e)
            {

                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPost]

        public async Task<object> Post([FromBody] VoitureDto voitureDto)
        {
            try
            {
                VoitureDto model = await _voitureRepository.CreateUpdateVoiture(voitureDto);
                _response.Result = model;
            }
            catch (Exception e)
            {

                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] VoitureDto voitureDto)
        {
            try
            {
                VoitureDto model = await _voitureRepository.CreateUpdateVoiture(voitureDto);
                _response.Result = model;
            }
            catch (Exception e)
            {

                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{voitureId}")]
        public async Task<object> Delete(int voitureId)
        {
            try
            {
                bool isSuccess = await _voitureRepository.DeleteVoiture(voitureId);
                _response.Result = isSuccess;
            }
            catch (Exception e)
            {

                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }
    }

}
