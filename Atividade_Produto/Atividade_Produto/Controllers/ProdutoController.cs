using Atividade_Produto.Business.interfaces;
using Atividade_Produto.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Atividade_Produto.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("produtos")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoBusiness _produtoBusiness;

        public ProdutoController(IProdutoBusiness produtobusiness)
        {
            _produtoBusiness = produtobusiness;
        }

        #region GET
        [HttpGet(Name = "GetAllCliente")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                /*var clientes = await _clienteBusiness.FindAll();
                if (clientes.Count > 0)
                    return Ok(clientes);*/

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

                /*var newcliente = await _clienteBusiness.FindById(Convert.ToInt32(id));
                if (newcliente == null)
                    return NotFound();*/
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("nome/{name}", Name = "GetByName")]
        public async Task<IActionResult> GetByName(string descricao)
        {
            try
            {
                if (string.IsNullOrEmpty(descricao.Trim() ))
                    return BadRequest("Nome não informado !");

                /*var cliente = await _clienteBusiness.FindByName(name);
                if (cliente == null)
                    return NotFound("Nome não encontrado na base !");*/
                return Ok();
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

                /*var cliente = await _clienteBusiness.FindByCPF(cpf.Trim());
                if (cliente == null)
                    return NotFound("CPF não encontrado na base !");*/
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region POST
        [HttpPost(Name = "CreateCliente")]
        public async Task<IActionResult> Create([FromBody]Produto produto)
        {
            try
            {
                if (!ModelState.IsValid || produto == null)
                    return BadRequest(ModelState);

                /*var newcliente = await _clienteBusiness.Create(obj);
                return CreatedAtRoute("GetByIdCliente", new { id = newcliente.Id });*/
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut("atualizar", Name = "UpdateCliente")]
        public async Task<IActionResult> Update(Produto produto)
        {
            try
            {
                if (produto == null)
                    return BadRequest();

                /*if (await _clienteBusiness.FindById(cliente.Id) == null)
                    return NotFound();

                var putCliente = await _clienteBusiness.Update(cliente);*/
                return Ok();
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

                //await _clienteBusiness.Delete(id);
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
