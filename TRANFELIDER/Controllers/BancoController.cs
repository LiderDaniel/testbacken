using Microsoft.AspNetCore.Mvc;
using Tranferencia.MODEL;
using Transferencia.DATA.Repository;

namespace TRANFELIDER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : Controller
    {
        private readonly IBanco _bancoRepository;

        public BancoController(IBanco bancoRepository)
        {
            _bancoRepository = bancoRepository; 
        }

        [HttpGet]
        public async Task<IActionResult> Getallbanco()
        {

            return Ok(await _bancoRepository.GetAllBanco());
        }

        [HttpGet("{COD_BANCO}")]
        public async Task<IActionResult> Getbancodetailss(string codban)
        {
            return Ok(await _bancoRepository.GetBancoDetails(codban));

        }

        [HttpPost]
        public async Task<IActionResult> CREATEBANCO([FromBody] BANCO banco)
        {
            if (banco == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _bancoRepository.InsertBanco(banco);

            return Created("created", created);


            
            }
        [HttpPut]
        public async Task<IActionResult> UPDATEBANCO([FromBody] BANCO banco)
        {
            if (banco == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _bancoRepository.UpdateBanco(banco);

            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> DELETEBANCO(string codig)
        {

            await _bancoRepository.DeleteBanco(new BANCO { COD_BANCO = codig });

            return NoContent();

        }


    }

    }

