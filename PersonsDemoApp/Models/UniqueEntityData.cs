using System.ComponentModel.DataAnnotations.Schema;

namespace PersonsDemoApp.Models
{
    public class UniqueEntityData
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
