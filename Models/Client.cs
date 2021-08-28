using System;

namespace biblioteca_AspNetWebApi.Models
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public bool IsInactivated  { get; set; }
    }
}