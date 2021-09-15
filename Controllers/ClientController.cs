using System;
using System.Threading.Tasks;
using AutoMapper;
using biblioteca_AspNetWebApi.Models;
using biblioteca_AspNetWebApi.Models.ViewModels;
using biblioteca_AspNetWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_AspNetWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(ClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById([FromRoute]Guid id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if(client is null)
                return NotFound(new Response("false","Client não encontrado"));

            return Ok(client);
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Create([FromBody]ClientSigInViewModel clientViewModel)
        {
            if(!ModelState.IsValid) return BadRequest();

            var validateRegistration = await _clientService.ValidateRegistration(clientViewModel);

            if(validateRegistration is Response)
                return BadRequest(validateRegistration);

            Client client = _mapper.Map<Client>(clientViewModel);
            
            client.IsInactivated = false;

            if(await _clientService.AddAsync(client)) 
                return Ok(new Response("true","registered successfully"));
            
            return BadRequest(new Response("false","internal error"));
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Update([FromBody]ClientSigInViewModel clientViewModel, [FromRoute]Guid id)
        {
            if(!ModelState.IsValid) return BadRequest();

            var oldClient = await _clientService.GetByIdAsync(id);

            if(oldClient.Email != clientViewModel.Email) 
            {
                if(await _clientService.ExistingEmailAsync(clientViewModel.Email))
                    return BadRequest("Email já cadastrado!");
            }

            Client client = _mapper.Map<Client>(clientViewModel);

            if(await _clientService.UpdateAsync(client, id)) return Ok();

            return BadRequest();
        }

        [HttpPost("Inativar/{id}")]
        public async Task<IActionResult> Inativate([FromRoute]Guid id)
        {
            if(!ModelState.IsValid) return BadRequest();

            if(await _clientService.Inactivate(id)) return Ok();

            return BadRequest();
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            if(!ModelState.IsValid) return BadRequest();

            if(await _clientService.DeleteAsync(id)) return Ok();

            return BadRequest();
        }
    }
}