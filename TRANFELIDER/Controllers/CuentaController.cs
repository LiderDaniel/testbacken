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
        public async Task<IActionResult> getallcuenta()
        {

            return Ok(await _cuentaRepository.GetAllCuenta());
        }


        [HttpGet("{idcuenta}")]
        public async Task<IActionResult> Getbancodetailss(string idcuenta)
        {
            return Ok(await _cuentaRepository.GetCuentaDetails(idcuenta));

        }

        [HttpPost]
        public async Task<IActionResult> CREATEBANCO([FromBody] CUENTA cuenta)
        {
            if (cuenta == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            Guid guid = Guid.NewGuid();
            var CUENTA = new CUENTA()
            {
                ID_CTA = guid.ToString(),
                NUM_CTA = cuenta.NUM_CTA,
                MONEDA  = cuenta.MONEDA,
                CEDULA_CLIENTE = cuenta.CEDULA_CLIENTE,
                SALDO = cuenta.SALDO,
                COD_BANCO = cuenta.COD_BANCO
            };
            var created = await _cuentaRepository.InsertCuenta(CUENTA);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UPDATEBANCO([FromBody] CUENTA cuenta)
        {
            if (cuenta == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _cuentaRepository.UpdateCuenta(cuenta);

            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> DELETEBANCO(string idcta)
        {

            await _cuentaRepository.DeleteCuenta(new CUENTA { ID_CTA = idcta });

            return NoContent();

        }

    }
}
