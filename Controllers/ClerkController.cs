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
    public class ClerkController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ClerkService _clerkService;

        public ClerkController(IMapper mapper, ClerkService clerkService)
        {
            _mapper = mapper;
            _clerkService = clerkService;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Create([FromBody]ClerkViewModel clerkViewModel)
        {
            if(!ModelState.IsValid) return BadRequest();

            if(await _clerkService.ExistingEmailAsync(clerkViewModel.Email.ToString()))
                return BadRequest("Email já cadastrado!");

            Clerk clerk = _mapper.Map<Clerk>(clerkViewModel);

            if(await _clerkService.AddAsync(clerk)) return Ok();

            return BadRequest();
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Update([FromBody] ClerkViewModel clerkViewModel, [FromRoute]Guid id)
        {
            if(!ModelState.IsValid) return BadRequest("aiaiai");

            Clerk clerk = _mapper.Map<Clerk>(clerkViewModel);

            if(await _clerkService.UpdateAsync(clerk, id)) return Ok();

            return BadRequest("aaaa");
        }

        [HttpPost("Inativar/{id}")]
        public async Task<IActionResult> Inativate([FromRoute]Guid id)
        {
            if(!ModelState.IsValid) return BadRequest();

            if(await _clerkService.Inactivate(id)) return Ok();

            return BadRequest();
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if(!ModelState.IsValid) return BadRequest();

            if(await _clerkService.DeleteAsync(id)) return Ok();

            return BadRequest();
        }
    }
}