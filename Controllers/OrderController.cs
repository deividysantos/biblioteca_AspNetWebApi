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

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Create([FromBody]OrderViewModel orderViewModel)
        {
            if(!ModelState.IsValid) return BadRequest();

            var order = _mapper.Map<Order>(orderViewModel);

            if(await _orderService.Add(order)) return Ok();

            return BadRequest();
        }
    }
}