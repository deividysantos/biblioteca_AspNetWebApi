using System;

namespace biblioteca_AspNetWebApi.Models
{
    public class Punishment : BaseEntity
    {
        public int IdClient { get; set; }
        public int IdPedido { get; set; }
        public DateTime InitialDate { get; set; }
    }
}