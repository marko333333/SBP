using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PosebnaKlauzulaController:ControllerBase
    {
        [HttpGet]
        [Route("VratiPosebneKlauzuleUgovora/{idUgovor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiPosebneKlauzuleUgovora(int idUgovor)
        {
            var result = await PosebneKlauzuleDataProvider.VratiPosebneKlauzuleUgovoraAsync(idUgovor);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }
    }
}
