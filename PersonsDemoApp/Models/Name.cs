using System.ComponentModel.DataAnnotations;

namespace PersonsDemoApp.Models
{
    public class Name : Dates
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
