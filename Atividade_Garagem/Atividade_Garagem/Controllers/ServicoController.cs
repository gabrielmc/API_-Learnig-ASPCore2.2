using System;
using System.Threading.Tasks;
using Atividade_Garagem.Business.interfaces;
using Atividade_Garagem.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_Garagem.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("servico")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ServicoController : ControllerBase
    {
        private IServicoBusiness _servicoBusiness;

        public ServicoController(IServicoBusiness servicobusiness)
        {
            _servicoBusiness = servicobusiness;
        }

        #region GET
        [HttpGet(Name = "GetAllServico")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var servicos = await _servicoBusiness.FindAll();
                if (servicos.Count > 0)
                    return Ok(servicos);

                return NotFound("Nenhum serviço encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetByIdServico")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var servico = await _servicoBusiness.FindById(Convert.ToInt32(id));
                if (servico == null)
                    return NotFound("Serviço não encontrado");

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region POST
        [HttpPost(Name = "CreateServico")]
        public async Task<IActionResult> Create([FromBody]Servico servico)
        {
            try
            {
                if (!ModelState.IsValid || servico == null)
                    return BadRequest(ModelState);

                servico.Entrada = DateTime.Now;
                servico.Preco = 0;
                var newservico = await _servicoBusiness.Create(servico);
                return CreatedAtRoute("GetByIdServico", new { id = newservico.Id });
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut("atualizar", Name = "UpdateServico")]
        public async Task<IActionResult> Update(Servico servico)
        {
            try
            {
                if (servico == null)
                    return BadRequest("Entrada nula");

                servico.Saida = DateTime.Now;
                TimeSpan tempo = servico.Saida.Subtract(servico.Entrada);
                servico.Preco = (tempo.Minutes > 0) ? Convert.ToDecimal((tempo.Hours + 1) * 3.50) : Convert.ToDecimal(tempo.Hours * 3.50);

                var putServico = await _servicoBusiness.Update(servico);
                return CreatedAtRoute("GetByIdServico", new { id = putServico.Id });
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "DeleteServico")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return NotFound("ID não informado!");

                await _servicoBusiness.Delete(id);
                return Ok("Item deletado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion
    }
}
