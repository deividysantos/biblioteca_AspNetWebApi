using System;
using System.Collections.Generic;
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
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(OrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetByOrderId([FromRoute]Guid id)
        {
            var entity = _orderService.GetByIdAsync(id);
            if(entity is null) return NotFound();

            return Ok(entity);
        }

        [HttpGet("Client/{id}")]
        public IActionResult GetAllByIdClient([FromRoute]Guid id)
        {
            IEnumerable<Order> entities = _orderService.GetAllByIdClient(id);

            if(entities is null) return NotFound();

            return Ok(entities);
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Create([FromBody]OrderViewModel orderViewModel)
        {
            if(!ModelState.IsValid) return BadRequest();

            if(!_orderService.FitClient(orderViewModel.IdClient))
                return BadRequest("Cliente não está adpto para retirar um novo livro, verifique as pendências"); 

            var order = _mapper.Map<Order>(orderViewModel);

            if(await _orderService.Add(order)) return Ok();

            return BadRequest();
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Update([FromBody]OrderViewModel orderViewModel, [FromRoute]Guid id)
        {
            if(!ModelState.IsValid) return BadRequest();

            Order order = _mapper.Map<Order>(orderViewModel);

            if(await _orderService.UpdateAsync(order, id)) return Ok();

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            if(!ModelState.IsValid) return BadRequest();

            if(await _orderService.DeleteAsync(id)) return Ok();

            return BadRequest();
        }
    }
}