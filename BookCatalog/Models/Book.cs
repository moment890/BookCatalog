using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookCatalog.Models
{
    [Table("books")]
    public class Book
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("author")]
        public string Author { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("categoryid")]
        public int CategoryId { get; set; }

        [Column("genreid")]
        public int GenreId { get; set; }


        public Category Category { get; set; }
        public Genre Genre { get; set; }

        internal static void Add(Book books)
        {
            throw new NotImplementedException();
        }
    }
}
