using biblioteca_AspNetWebApi.Repository;

namespace biblioteca_AspNetWebApi.Services
{
    public class PunishmentService
    {
        private readonly PunishmentRepository _punishmentRepository;

        public PunishmentService(PunishmentRepository punishmentRepository)
        {
            _punishmentRepository = punishmentRepository;
        }
    }
}