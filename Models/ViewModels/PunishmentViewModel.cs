using System;

namespace biblioteca_AspNetWebApi.Models.ViewModels
{
    public class PunishmentViewModel
    {
        public Guid IdClient { get; set; }
        public Guid IdPedido { get; set; }
        public DateTime InitialDate { get; set; }
    }
}