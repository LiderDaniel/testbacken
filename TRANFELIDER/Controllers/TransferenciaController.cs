using Microsoft.AspNetCore.Mvc;
using Tranferencia.MODEL;
using Transferencia.DATA.Repository;

namespace TRANFELIDER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : Controller
    {
        private readonly ITransferencia _transferenciaRepository;


        public TransferenciaController(ITransferencia transfenciaRepository)
        {
            _transferenciaRepository = transfenciaRepository;
        }



        ValidarTransferencia validartransferencia = new ValidarTransferencia();



        [HttpGet]
        public async Task<IActionResult> Getalltransferencia()
        {
            return Ok(await _transferenciaRepository.GetAllTranferencia());

            
        }


         [HttpGet("{idtra}/EstadoTranferencia")]
        public async Task<IActionResult> GetTransferenciaestadp(string idtra)
        {
            return Ok(await _transferenciaRepository.GetAllTranferenciaestado(idtra));
        }


        [HttpGet("{numcuenta}/HistorialEnviado")]
        public async Task<IActionResult> GetTransferenciaesEnviado(string numcuenta)
        {
            return Ok(await _transferenciaRepository.GetTransferenciaaHistorialEnviado(numcuenta));
        }

        [HttpGet("{numcuenta}/HistorialRecibido")]
        public async Task<IActionResult> GetTransferenciaesRecibido(string numcuenta)
        {
            return Ok(await _transferenciaRepository.GetTransferenciaaHistorialRecibido(numcuenta));
        }

        [HttpGet("{trans}")]
        public async Task<IActionResult> GetTransferenciaDetails(string trans)
        {
            return Ok(await _transferenciaRepository.GetTransferenciaDetails(trans));
        }


        [HttpPost]

        public async Task<IActionResult> CREATETRANSACION([FromBody] TRANFERENCIA transfe)
        {
            if (transfe == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            
            if (transfe.num_cta == transfe.num_cuenta_destino)
                throw new Exception("EL NUMERO DE CUENTA NO DEBE SER IGUAL AL NUMERO DE CUENTA DESTINO");
            Guid guid = Guid.NewGuid();
            var TRANFERENCIA = new TRANFERENCIA()
            {
                id_transaccion = guid.ToString(),

                num_cta = transfe.num_cta,


                cedula_cliente = transfe.cedula_cliente,

                fecha = transfe.fecha,

                monto = transfe.monto,

                estado = transfe.estado,

                banco_origen = transfe.banco_origen,

                banco_destino = transfe.banco_destino,


                num_cuenta_destino = transfe.num_cuenta_destino
            };
            var created = await _transferenciaRepository.InsertTransferencia(TRANFERENCIA);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UPDATETRANSFERENCIA([FromBody] TRANFERENCIA transfe)
        {
            if (transfe == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _transferenciaRepository.UpdateTransferencia(transfe);

            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> DELETETRANSFERENCIA(string codig)
        {

            await _transferenciaRepository.DeleteTransferencia(new TRANFERENCIA { id_transaccion = codig });

            return NoContent();

        }






    }


}
