using System;

namespace biblioteca_AspNetWebApi.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsInactivated  { get; set; }
    }
}