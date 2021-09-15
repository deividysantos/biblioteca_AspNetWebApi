namespace biblioteca_AspNetWebApi.Models
{
    public class Response
    {
        public string Sucess { get; set; }
        public string Message { get; set; }

        public Response(string sucess, string message)
        {
            Sucess = sucess;
            Message = message;
        }
    }
}