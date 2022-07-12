using Microsoft.AspNetCore.Mvc;
using Tranferencia.MODEL;
using Transferencia.DATA.Repository;

namespace TRANFELIDER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ICliente _clienteRepository;


        public ClienteController(ICliente clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Getallcliente()
        {

            return Ok(await _clienteRepository.GetAllCliente());
        }
        [HttpGet("{idcedula}")]
        public async Task<IActionResult> Getclientesdetailss(string cedulas)
        {
            return Ok(await _clienteRepository.GetClienteDetails(cedulas));
         
        }

        [HttpPost]
        public async Task<IActionResult> CREATECLIENTE([FromBody] CLIENTE clientes)
        {
            if (clientes == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _clienteRepository.InsertCliente(clientes);

            return Created("created", created);
           
        }

        [HttpPut]
        public async Task<IActionResult> UPDATECLIENTE([FromBody] CLIENTE clientes)
        {
            if (clientes == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
          await _clienteRepository.UpdateCliente(clientes);

            return NoContent(); 

        }

        [HttpDelete]
        public async Task<IActionResult> DELETECLIENTE( string IDCEDULA)
        {
           
            await _clienteRepository.DeleteCliente(new CLIENTE { idcedula= IDCEDULA });

            return NoContent();

        }
    }
}
