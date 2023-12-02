using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorEF.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(64)]
        public string Name { get; set; } = string.Empty;

        public Category()
        {

        }
    }
}
