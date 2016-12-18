using System.ComponentModel.DataAnnotations;

namespace Fantastyka.Models
{
    public enum YesNoAnswer
    {
        [Display(Name = "Tak")]
        Yes,
        [Display(Name ="Nie")]
        No
    }
}