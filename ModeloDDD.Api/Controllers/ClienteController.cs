using Microsoft.AspNetCore.Mvc;

using ModeloDDD.Application.DTO;
using ModeloDDD.Application.Exceptions;
using ModeloDDD.Application.Interfaces;

using System;

namespace ModeloDDD.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IApplicationServiceCliente _applicationServiceCliente;

        public ClienteController(IApplicationServiceCliente applicationServiceCliente)
        {
            _applicationServiceCliente = applicationServiceCliente;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var clientes = _applicationServiceCliente.GetAll();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var cliente = _applicationServiceCliente.GetById(id);
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClienteDTO clienteDto)
        {
            try
            {
                if (clienteDto is null)
                    return BadRequest("O cliente passado não é válido");

                _applicationServiceCliente.Add(clienteDto);
                return Ok("Cliente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ClienteDTO clienteDto)
        {
            try
            {
                if (clienteDto is null)
                    return BadRequest("O cliente passado não é válido");

                _applicationServiceCliente.Update(clienteDto);

                return Ok("Cliente Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                _applicationServiceCliente.Remove(id);

                return Ok("Cliente deletado com sucesso!");
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