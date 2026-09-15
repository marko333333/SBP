using Gradjevinska_firmaLibrary;
using Gradjevinska_firmaLibrary.DTOs;
using Gradjevinska_firmaLibrary.Entiteti;
using Gradjevinska_firmaLibrary.DataProvider;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizickoLiceController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSvaFizickaLica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSvaFizickaLica()
        {
            var fizickaLica = await OsobaDataProvider.VratiSvaFizickaLicaAsync();

            if (fizickaLica.IsError)
            {
                return StatusCode(fizickaLica.Error.StatusCode,fizickaLica.Error.Message);
            }

            return Ok(fizickaLica.Data);
        }

        [HttpPost]
        [Route("DodajFizickoLice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DodajFizickoLice([FromBody] FizickoLiceView f)
        {
            var result = await OsobaDataProvider.DodajFizickoLiceAsync(f);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniFizickoLice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> IzmeniFizickoLice([FromBody] FizickoLiceView f)
        {
            var result = await OsobaDataProvider.IzmeniFizickoLiceAsync(f);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode,result.Error.Message);
            }

            return Ok(result.Data);
        }
    }
}
