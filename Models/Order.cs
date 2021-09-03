using System;

namespace biblioteca_AspNetWebApi.Models
{
    public class Order : BaseEntity
    {
        public Guid IdClient { get; set; }
        public Guid IdClerk { get; set; }
        public Guid IdBook { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}