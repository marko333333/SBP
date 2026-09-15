using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> VratiSveKontakte()
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
        public async Task<IActionResult> VratiKontakteOsobe(int idOsobe)
        {
            var result = await KontaktDataProvider.VratiKontakteOsobeAsync(idOsobe);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajKontakt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DodajKontakt([FromBody] KontaktView kontaktView)
        {
            var result =await KontaktDataProvider.DodajKontaktAsync(kontaktView);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiKontakt/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiKontakt(int id)
        {
            var result = await KontaktDataProvider.VratiKontaktAsync(id);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniKontakt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IzmeniKontakt([FromBody] KontaktView kontaktView)
        {
            var result =
                await KontaktDataProvider.IzmeniKontaktAsync(kontaktView);

            if (result.IsError)
                return StatusCode(
                    result.Error.StatusCode,
                    result.Error.Message);

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiKontakt/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObrisiKontakt(int id)
        {
            var result = await KontaktDataProvider.ObrisiKontaktAsync(id);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }
    }
}
