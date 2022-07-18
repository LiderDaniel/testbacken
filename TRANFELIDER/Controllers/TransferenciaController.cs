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


        [HttpGet("{idtra}/HistorialEnviado")]
        public async Task<IActionResult> GetTransferenciaesEnviado(string idtra)
        {
            return Ok(await _transferenciaRepository.GetTransferenciaaHistorialEnviado(idtra));
        }

        [HttpGet("{idtra}/HistorialRecibido")]
        public async Task<IActionResult> GetTransferenciaesRecibido(string idtra)
        {
            return Ok(await _transferenciaRepository.GetTransferenciaaHistorialRecibido(idtra));
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
            if (transfe.num_cuenta_origen == transfe.num_cuenta_destino)
                throw new Exception("EL NUMERO DE CUENTA NO DEBE SER IGUAL AL NUMERO DE CUENTA DESTINO");
            if (transfe.saldo < transfe.monto)
                throw new Exception("El MONTO INGRESADO ES MAYOR AL SALDO DISPONIBLE ");
            Guid guid = Guid.NewGuid();
            var TRANFERENCIA = new TRANFERENCIA()
            {
                id_transaccion = guid.ToString(),

                num_cta = transfe.num_cta,


                cedula_cliente = transfe.cedula_cliente,

                fecha = transfe.fecha,

                monto = transfe.monto,

                estado = transfe.estado,


                num_cuenta_origen = transfe.num_cuenta_origen,

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
