using System;

namespace biblioteca_AspNetWebApi.Models.ViewModels
{
    public class OrderViewModel
    {
        public int IdClient { get; set; }
        public int IdClerk { get; set; }
        public int IdBook { get; set; }
        public DateTime RequestDate { get; set; }
    }
}