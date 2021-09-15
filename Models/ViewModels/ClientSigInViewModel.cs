using System;

namespace biblioteca_AspNetWebApi.Models.ViewModels
{
    public class ClientSigInViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDay { get; set; }
    }
}