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
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly IMapper _mapper;

        public BookController(BookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Create([FromBody]BookViewModel bookViewModel)
        {
            if(!ModelState.IsValid) return BadRequest();

            Book book = _mapper.Map<Book>(bookViewModel);

            if(await _bookService.Add(book)) return Ok();

            return BadRequest();
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Update([FromBody]BookViewModel bookViewModel, [FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest();

            Book book = _mapper.Map<Book>(bookViewModel);

            if(await _bookService.Update(book, id)) return Ok();

            return BadRequest();
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest();

            if(await _bookService.Delete(id)) return Ok();

            return BadRequest();
        }
    }
}