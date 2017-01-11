using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fantastyka2.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Wydawca")]
        public string Publisher { get; set; }
        [Required]
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Cena")]
        public double Price { get; set; }
    }
}