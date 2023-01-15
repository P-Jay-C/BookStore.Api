using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class BookModel 
    {
        public int id { get; set; }
        [Required]
        public string? title { get; set; }
        public string? description { get; set; }
    } 
}
