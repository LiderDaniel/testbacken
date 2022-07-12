using Microsoft.AspNetCore.Mvc;
using Tranferencia.MODEL;
using Transferencia.DATA.Repository;

namespace TRANFELIDER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {
        private readonly ICuenta _cuentaRepository;

        public CuentaController(ICuenta cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Getallcliente()
        {

            return Ok(await _cuentaRepository.GetAllCuenta());
        }

        [HttpGet("{ID_CTA}")]
        public async Task<IActionResult> Getclientesdetailss(string cta)
        {
            return Ok(await _cuentaRepository.GetCuentaDetails(cta));

        }
        [HttpPost]
        public async Task<IActionResult> CREATECAR([FromBody] CUENTA cuenta)
        {
            if (cuenta == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _cuentaRepository.InsertCuenta(cuenta);

            return Created("created", created);
           
        }
        [HttpPut]
        public async Task<IActionResult> UPDATECAR([FromBody] CUENTA cuenta)
        {
            if (cuenta == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _cuentaRepository.InsertCuenta(cuenta);

            return NoContent();

        }
        [HttpDelete]
        public async Task<IActionResult> DELETECAR(string cuenta)
        {

            await _cuentaRepository.DeleteCuenta(new CUENTA { ID_CTA = cuenta });

            return NoContent();

        }
    }
}
