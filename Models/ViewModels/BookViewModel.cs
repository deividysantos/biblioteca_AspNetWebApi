namespace biblioteca_AspNetWebApi.Models.ViewModels
{
    public class BookViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public int AvailableQuantity { get; set; }
        public int AgeGroup { get; set; }
    }
}