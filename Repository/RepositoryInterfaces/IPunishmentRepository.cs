using System;
using System.Collections.Generic;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository.RepositoryInterfaces
{
    public interface IPunishmentRepository : IBaseRepository<Punishment>
    {
        IEnumerable<Punishment> GetAllByClientId(Guid id);
    }
}