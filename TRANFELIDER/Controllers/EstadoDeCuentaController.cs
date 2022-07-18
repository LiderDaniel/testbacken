using Microsoft.AspNetCore.Mvc;
using Tranferencia.MODEL;
using Transferencia.DATA.Repository;


namespace TRANFELIDER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoDeCuentaController : Controller
    {
        private readonly IEstadodecuenta _estadodecuenta;


        public EstadoDeCuentaController(IEstadodecuenta estadocuentaas)
        {
            _estadodecuenta = estadocuentaas;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEstadoCuenta()
        {
            return Ok(await _estadodecuenta.GetAllEstadoCuenta());
        }
    }
}
