using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rent.Web.Models;
using Rent.Web.Servieces.IService;

namespace Rent.Web.Controllers
{
    public class VoitureController : Controller
    {
        private IVoitureService _voitureService;

        public VoitureController(IVoitureService voitureService)
        {
            _voitureService = voitureService;
        }
        public async Task<IActionResult> VoitureIndex()
        {
            List<VoitureDto> list = new List<VoitureDto>();

            var response = await _voitureService.GetAllVoituressAsync<ResponseDto>();

            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VoitureDto>>(Convert.ToString(response.Result));
                ;
            }

            return View(list);
        }

        public async Task<IActionResult> VoitureCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VoitureCreate(VoitureDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _voitureService.CreateVoitureAsync<ResponseDto>(model);

                if (response != null && response.isSuccess)
                {
                    return RedirectToAction(nameof(VoitureIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> VoitureEdit(int voitureId)
        {
            if (ModelState.IsValid)
            {
                var response = await _voitureService.GetByVoitureIdAsync<ResponseDto>(voitureId);

                if (response != null && response.isSuccess)
                {
                    VoitureDto model = JsonConvert.DeserializeObject<VoitureDto>(Convert.ToString(response.Result));
                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VoitureEdit(VoitureDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _voitureService.UpdateVoitureAsync<ResponseDto>(model);

                if (response != null && response.isSuccess)
                {
                    return RedirectToAction(nameof(VoitureIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> VoitureDelete(int voitureId)
        {
            if (ModelState.IsValid)
            {
                var response = await _voitureService.GetByVoitureIdAsync<ResponseDto>(voitureId);

                if (response != null && response.isSuccess)
                {
                    VoitureDto model = JsonConvert.DeserializeObject<VoitureDto>(Convert.ToString(response.Result));
                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VoitureDelete(VoitureDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _voitureService.DeleteVoitureAsync<ResponseDto>(model.VoitureId);

                if (response != null && response.isSuccess)
                {
                    return RedirectToAction(nameof(VoitureIndex));
                }
            }
            return View(model);
        }

    }
}
