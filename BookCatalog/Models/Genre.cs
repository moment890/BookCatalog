using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookCatalog.Models
{
    [Table("genres")]
    public class Genre
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }



        public List<Book> books { get; set; }
    }
}
