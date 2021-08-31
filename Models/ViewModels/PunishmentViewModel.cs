using System;

namespace biblioteca_AspNetWebApi.Models.ViewModels
{
    public class PunishmentViewModel
    {
        public int IdClient { get; set; }
        public int IdPedido { get; set; }
        public DateTime InitialDate { get; set; }
        public int QuantityDays { get; set; }
    }
}