using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyAddressBook.Models
{
    public class Company
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Name is required"),MaxLength(100,ErrorMessage ="Name must be less than or equal 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Number Of Contacts is required")]
        public int NumberOfContacts { get; set; } = 0;
        [Required(ErrorMessage ="Max Contact Age is required")]
        [Range(18, 100, ErrorMessage = "Max Contact Age must be more than or equal to 18 and less or equal to 100")]
        public int MaxContactAge { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}
