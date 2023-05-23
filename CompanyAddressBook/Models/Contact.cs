using System.ComponentModel.DataAnnotations;

namespace CompanyAddressBook.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Number is required")
            ,DataType(DataType.PhoneNumber,ErrorMessage = "Please enter a valid 10-digit phone number")
            ,MinLength(10,ErrorMessage = "Please enter a valid 10-digit phone number")
            ,MaxLength(10, ErrorMessage ="Please enter a valid 10-digit phone number")]
        public string Number { get; set; }
        [Range(18,100,ErrorMessage = "Age must be more than or equal to 18 and less or equal to 100")]
        public int Age { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
