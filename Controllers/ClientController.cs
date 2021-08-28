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

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Create([FromBody]ClientViewModel clientViewModel)
        {
            if(!ModelState.IsValid) return BadRequest();

            Client client = _mapper.Map<Client>(clientViewModel);
            
            client.IsInactivated = false;

            if(await _clientService.Add(client)) return Ok();
            
            return BadRequest();
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Update([FromBody]ClientViewModel clientViewModel, [FromQuery] int id)
        {
            if(!ModelState.IsValid) return BadRequest();

            Client client = _mapper.Map<Client>(clientViewModel);

            if(await _clientService.Update(client, id)) return Ok();

            return BadRequest();
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if(!ModelState.IsValid) return BadRequest();

            if(await _clientService.Delete(id)) return Ok();

            return BadRequest();
        }
    }
}