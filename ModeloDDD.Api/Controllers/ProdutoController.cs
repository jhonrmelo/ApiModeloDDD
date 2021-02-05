using Microsoft.AspNetCore.Mvc;
using ModeloDDD.Application.DTO;
using ModeloDDD.Application.Exceptions;
using ModeloDDD.Application.Interfaces;

using System;

namespace ModeloDDD.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_applicationServiceProduto.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_applicationServiceProduto.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO is null)
                    return BadRequest("O produto passado não é valido");

                _applicationServiceProduto.Add(produtoDTO);
                return Ok("Produto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO is null)
                    return BadRequest("O produto passado não é valido");

                _applicationServiceProduto.Update(produtoDTO);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Informação inválida");

                _applicationServiceProduto.Remove(id);

                return Ok("Produot excluido com sucesso");


            }
            catch (NotFoundException ntEx)
            {
                return NotFound(ntEx.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
