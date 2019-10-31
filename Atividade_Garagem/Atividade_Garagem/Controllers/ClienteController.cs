using Atividade_Garagem.Business.interfaces;
using Atividade_Garagem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Atividade_Garagem.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("cliente")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ClienteController : ControllerBase
    {
        private IClienteBusiness _clienteBusiness;

        public ClienteController(IClienteBusiness clientebusiness)
        {
            _clienteBusiness = clientebusiness;
        }

        #region GET
        [HttpGet(Name = "GetAllCliente")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var clientes = await _clienteBusiness.FindAll();
                if (clientes.Count > 0)
                    return Ok(clientes);

                return NotFound("Nenhum item encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetByIdCliente")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var newcliente = await _clienteBusiness.FindById(Convert.ToInt32(id));
                if (newcliente == null)
                    return NotFound();
                return Ok(newcliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("nome/{name}", Name = "GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name.Trim() ))
                    return BadRequest("Nome não informado !");

                var cliente = await _clienteBusiness.FindByName(name);
                if (cliente == null)
                    return NotFound("Nome não encontrado na base !");
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("cpf/{cpf}", Name = "GetByCPF")]
        public async Task<IActionResult> GetByCPF(string cpf)
        {
            try
            {
                if (string.IsNullOrEmpty(cpf.Trim()))
                    return BadRequest("CPF não informado !");

                var cliente = await _clienteBusiness.FindByCPF(cpf.Trim());
                if (cliente == null)
                    return NotFound("CPF não encontrado na base !");
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region POST
        [HttpPost(Name = "CreateCliente")]
        public async Task<IActionResult> Create([FromBody]Cliente obj)
        {
            try
            {
                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                var newcliente = await _clienteBusiness.Create(obj);
                return CreatedAtRoute("GetByIdCliente", new { id = newcliente.Id });
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut("atualizar", Name = "UpdateCliente")]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return BadRequest();

                if (await _clienteBusiness.FindById(cliente.Id) == null)
                    return NotFound();

                var putCliente = await _clienteBusiness.Update(cliente);
                return Ok(putCliente);
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "DeleteCliente")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return NotFound("ID não informado!");

                await _clienteBusiness.Delete(id);
                return Ok("Item deletado!");
            }          
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion
    }
}
