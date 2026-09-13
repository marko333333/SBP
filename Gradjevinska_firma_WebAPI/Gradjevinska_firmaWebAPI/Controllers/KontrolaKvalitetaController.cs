using Gradjevinska_firmaLibrary.DataProvider;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KontrolaKvalitetaController:ControllerBase
    {
        [HttpGet]
        [Route("VratiKontroleKvalitetaZadatka/{idZadatak}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetKontroleKvalitetaZadatka(int idZadatak)
        {
            var result = await KontrolaKvalitetaDataProvider.VratiKontroleKvalitetaZadatkaAsync(idZadatak);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }
    }
}
