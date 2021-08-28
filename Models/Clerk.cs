namespace biblioteca_AspNetWebApi.Models
{
    public class Clerk : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}