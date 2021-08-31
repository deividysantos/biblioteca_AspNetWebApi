using AutoMapper;
using biblioteca_AspNetWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_AspNetWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PunishmentController : ControllerBase
    {
        private readonly PunishmentService _punishmentService;
        private readonly IMapper _mapper;

        public PunishmentController(PunishmentService punishmentService, IMapper mapper)
        {
            _punishmentService = punishmentService;
            _mapper = mapper;
        }

        
    }
}