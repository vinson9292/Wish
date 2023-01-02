using System.ComponentModel.DataAnnotations;

namespace Wish.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}