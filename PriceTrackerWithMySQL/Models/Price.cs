namespace PriceTrackerWithMySQL.Models
{
    public class Price
    {
        public int id { get; set; }

        public double price { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }
}
