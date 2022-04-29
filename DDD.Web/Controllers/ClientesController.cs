using DDD.Web.Models;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static Domain.Services.ClienteService;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace DDD.Web.Controllers
{
    
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly IRepository<Cliente> _clienteRepository;

        public ClientesController(ClienteService clienteService,
           IRepository<Cliente> clienteRepository)
        {
            _clienteService = clienteService;
            _clienteRepository = clienteRepository;
        }
    
        [HttpGet("api/Clientes")]
        public IEnumerable<ClienteDTO> GetClientes()
        {
            var cliente = _clienteRepository.GetAll();

            var resultado = cliente.Select(c => new ClienteDTO 
            { 
                Id = c.Id,
                NomeCompleto = c.NomeCompleto,
                Ativo = c.Ativo,
                DataCadastro = c.DataCadastro,
                DataNasc =c.DataNasc,
                Documento = c.Documento,
                Endereco =c.Endereco
            });

            return resultado;
        }


        [HttpGet("api/Clientes/{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
         
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound(new { message = $"Cliente de id={id} não encontrado" });
            }
            return cliente;
        }
        [HttpPost("api/Clientes")]
        public ActionResult<Cliente> Post(Cliente cliente)
        {
            var errors = new List<string>();
            var Listerrors = new List<string>();
            ClienteValidator validator = new ClienteValidator();
            ValidationResult results = validator.Validate(cliente);
            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    errors.Add(failure.ErrorMessage);
                }
            }
            if (errors.Count() > 0)
            {
                foreach (var item in errors)
                {
                    Listerrors.Add(item);
                    return NotFound(new { message = $"{item} " });
                }
                
            }
           
            var clie = _clienteRepository.GetDOC(cliente.Documento);
            if (clie.Count()>0)
            {
                return NotFound(new { message = $"Cliente de id={cliente.NomeCompleto} ja foi cadastrado" });
            }
            else
            {
               var result= _clienteService.Save(cliente);
                if (result)
                return Ok(cliente);
                else { return BadRequest(result); }
            }
           
        }
    }
}
