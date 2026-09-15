using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BezbednosnaObukaController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSveBezbednosneObuke")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSveBezbednosneObuke()
        {
            var result = await BezbednosnaObukaDataProvider.VratiSveBezbednosneObukeAsync();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiBezObukuFizickogLica/{idOsobe}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiBezObukuFizickogLica(int idOsobe)
        {
            var result = await BezbednosnaObukaDataProvider.VratiBezObukuFizickogLicaAsync(idOsobe);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajBezbednosnuObuku")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DodajBezbednosnuObuku([FromBody] BezbednosnaObukaView b)
        {
            var result = await BezbednosnaObukaDataProvider.DodajBezbednosnuObukuAsync(b);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiBezbednosnuObuku/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiBezbednosnuObuku(int id)
        {
            var result = await BezbednosnaObukaDataProvider.VratiBezbednosnuObukuAsync(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniBezbednosnuObuku")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IzmeniBezbednosnuObuku([FromBody] BezbednosnaObukaView b)
        {
            var result =await BezbednosnaObukaDataProvider.IzmeniBezbednosnuObukuAsync(b);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiBezbednosnuObuku/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObrisiBezbednosnuObuku(int id)
        {
            var result =await BezbednosnaObukaDataProvider.ObrisiBezbednosnuObukuAsync(id);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }


    }
}
