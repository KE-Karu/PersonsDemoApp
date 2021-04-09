using System.ComponentModel.DataAnnotations;

namespace PersonsDemoApp.Models
{
    public class Gender : Name
    {
        [Required]
        public string Sex { get; set; }
    }
}
