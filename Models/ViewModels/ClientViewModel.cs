using System;

namespace biblioteca_AspNetWebApi.Models.ViewModels
{
    public class ClientViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
    }
}