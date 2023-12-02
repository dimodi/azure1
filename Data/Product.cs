using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorEF.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        public Product()
        {

        }
    }
}
