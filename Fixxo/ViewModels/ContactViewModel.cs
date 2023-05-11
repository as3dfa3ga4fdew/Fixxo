using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fixxo.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "You have to provide a name.")]
        [StringLength(100, ErrorMessage = "Name is too short.", MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "You have to provide an email.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must provide a valid email address.")]
        [StringLength(200, ErrorMessage = "Email is too short.", MinimumLength = 8)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "You have to provide a message.")]
        [StringLength(1000, ErrorMessage = "Message is too short.", MinimumLength = 40)]
        public string Message { get; set; } = null!;

        //Result message
        [JsonIgnore]
        public string Result { get; set; } = string.Empty;
    }
}
