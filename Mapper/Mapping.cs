using AutoMapper;
using biblioteca_AspNetWebApi.Models;
using biblioteca_AspNetWebApi.Models.ViewModels;

namespace biblioteca_AspNetWebApi.Mapper
{
    public class Mapping : Profile  
    {
        public Mapping()
        {
            CreateMap<ClientSigInViewModel, Client>();
            CreateMap<ClerkViewModel, Clerk>();
            CreateMap<BookViewModel, Book>();
            CreateMap<PunishmentViewModel, Punishment>();
            CreateMap<OrderViewModel, Order>();
        }
    }
}