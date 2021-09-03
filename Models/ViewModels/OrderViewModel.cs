using System;

namespace biblioteca_AspNetWebApi.Models.ViewModels
{
    public class OrderViewModel
    {
        public Guid IdClient { get; set; }
        public Guid IdClerk { get; set; }
        public Guid IdBook { get; set; }
        public DateTime RequestDate { get; set; }
    }
}