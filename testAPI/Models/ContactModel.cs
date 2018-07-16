using System.ComponentModel.DataAnnotations;

namespace testAPI.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Enter valid EmailID")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone no. is required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid phone Number.")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Status is required")]
        public string Status { get; set; }
    }
}