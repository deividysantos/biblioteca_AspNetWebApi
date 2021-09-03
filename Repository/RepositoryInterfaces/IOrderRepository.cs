using System;
using System.Collections.Generic;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository.RepositoryInterfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        IEnumerable<Order> GetAllByIdClient(Guid id);
    }
}