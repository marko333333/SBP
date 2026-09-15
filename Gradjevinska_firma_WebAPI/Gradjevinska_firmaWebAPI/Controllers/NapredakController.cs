using Gradjevinska_firmaLibrary.DataProvider;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NapredakController:ControllerBase
    {
        [HttpGet]
        [Route("VratiNapretkeZadatka/{idZadatka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiNapretkeZadatka(int idZadatka)
        {
            var result = await NapredakDataProvider.VratiNapretkeZadatkaAsync(idZadatka);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }
    }
}
