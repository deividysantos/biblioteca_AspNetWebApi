using System;

namespace biblioteca_AspNetWebApi.Models
{
    public class Punishment : BaseEntity
    {
        public Guid IdClient { get; set; }
        public Guid IdPedido { get; set; }
        public DateTime InitialDate { get; set; }
    }
}