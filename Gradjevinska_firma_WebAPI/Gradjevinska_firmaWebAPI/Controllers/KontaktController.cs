using Microsoft.AspNetCore.Mvc;
using Gradjevinska_firmaLibrary.DataProvider;
namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KontaktController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSveKontakte")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetKontakti()
        {
            var kontakti = await KontaktDataProvider.VratiSveKontakteAsync();

            if (kontakti.IsError)
            {
                return StatusCode(kontakti.Error.StatusCode,kontakti.Error.Message);
            }

            return Ok(kontakti.Data);
        }

        [HttpGet]
        [Route("VratiKontakteOsobe/{idOsobe}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetKontakteOsobe(int idOsobe)
        {
            var result = await KontaktDataProvider.VratiKontakteOsobeAsync(idOsobe);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }
    }
}
