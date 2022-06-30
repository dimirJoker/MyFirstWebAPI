using System.ComponentModel.DataAnnotations;

namespace MyFirstWebAPI.Models
{
    public class Item
    {
        public uint Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, uint.MaxValue)]
        public float Salary { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
    }
}