using System.ComponentModel.DataAnnotations;

namespace PriceTrackerWithMySQL.Models
{
    public class PriceModel
    {
        public int id { get; set; }


        public double price { get; set; }
        [Required]
        public string? name { get; set; }
     
        public string? description { get; set; }
    }
}
