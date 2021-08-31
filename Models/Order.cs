using System;

namespace biblioteca_AspNetWebApi.Models
{
    public class Order : BaseEntity
    {
        public int IdClient { get; set; }
        public int IdClerk { get; set; }
        public int IdBook { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}