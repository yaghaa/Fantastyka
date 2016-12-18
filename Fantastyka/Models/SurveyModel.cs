using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using Fantastyka.Validators;

namespace Fantastyka.Models
{
    public class SurveyModel
    {
        [Required(ErrorMessage = "Pole Jest Wymagane")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole Jest Wymagane")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Niepoprawny format adresu e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole Jest Wymagane")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Pole Jest Wymagane")]
        public string Title { get; set; }

        public string Publisher { get; set; }

        [Required(ErrorMessage = "Pole Jest Wymagane")]
        public double? Rating { get; set; }

        [Required(ErrorMessage = " Pole Jest Wymagane")]
        public YesNoAnswer Readed { get; set; }

        [Range(0, 10,ErrorMessage = "Liczba z poza zakresu")]
        public int? TimesReaded { get; set; }

        public DateTime PurchaseDate { get; set; }

        [IsDateAfterAttribute("PurchaseDate")]
        public DateTime ReadedDate { get; set; }
    
        public bool  Hidden { get; set; }

        public string  Result { get; set; }

    }
}