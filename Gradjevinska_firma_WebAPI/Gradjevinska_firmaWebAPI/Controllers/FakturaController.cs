using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FakturaController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSveFakture")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSveFakture()
        {
            var result = await FakturaDataProvider.VratiSveFaktureAsync();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiFaktureProjekta/{idProjekat}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiFaktureProjekta(int idProjekat)
        {
            var result = await FakturaDataProvider.VratiFaktureProjektaAsync(idProjekat);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }


        [HttpPost]
        [Route("DodajFakturu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DodajFakturu([FromBody] FakturaView f)
        {
            var result = await FakturaDataProvider.DodajFakturuAsync(f);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiFakturu/{brFakture}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiFakturu(int brFakture)
        {
            var result=await FakturaDataProvider.VratiFakturuAsync(brFakture);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniFakturu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IzmeniFakturu([FromBody] FakturaView f)
        {
            var result =await FakturaDataProvider.IzmeniFakturuAsync(f);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiFakturu/{brFakture}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObrisiFakturu(int brFakture)
        {
            var result =await FakturaDataProvider.ObrisiFakturuAsync(brFakture);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }


    }
}
