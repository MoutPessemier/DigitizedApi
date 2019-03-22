using System.ComponentModel.DataAnnotations;

namespace DigitizedApi.DTO {
    public class RegisterDTO : LoginDTO {
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [Required]
        //[StringLength(15)]
        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
