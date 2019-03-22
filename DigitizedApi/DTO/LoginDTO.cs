using System.ComponentModel.DataAnnotations;

namespace DigitizedApi.DTO {
    public class LoginDTO {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^([a-zA-Z]+[a-zA-Z0-9.\-_éèàùäëïöüâêîôû]*)@([a-z]+)[.]([a-z]+)([.][a-z]+)*$")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
