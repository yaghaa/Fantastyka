using System.Collections.Generic;

namespace Fantastyka2.Models
{
    public class BooksViewModel
    {
        public List<Fantastyka2.Models.Book> Books { get; set; }
        public int[] SelectedBooks { get; set; }

        public string Category { get; set; }
    }
}