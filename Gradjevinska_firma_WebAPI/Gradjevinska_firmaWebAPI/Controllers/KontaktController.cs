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
    }
}
