using System.ComponentModel.DataAnnotations;

namespace ecommerce.Data
{
    public class EntityModel
    {
        public int id {get; set; }
        [Required(ErrorMessage ="Name required")]
        public string name {get; set; }
    }
}