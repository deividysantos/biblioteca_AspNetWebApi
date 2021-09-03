using biblioteca_AspNetWebApi.Repository;
using biblioteca_AspNetWebApi.Repository.RepositoryInterfaces;

namespace biblioteca_AspNetWebApi.Services
{
    public class PunishmentService
    {
        private readonly IPunishmentRepository _punishmentRepository;

        public PunishmentService(IPunishmentRepository punishmentRepository)
        {
            _punishmentRepository = punishmentRepository;
        }
    }
}