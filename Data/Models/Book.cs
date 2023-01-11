using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWebApi.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }
        public DateTime?  DateRead { get; set; }

        public int? Rate { get; set; }

        public string CoverUrl { get; set; }

        public DateTime DateAdded { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        //nav properties

        public int? PublisherId { get; set; }

        [ForeignKey(nameof(PublisherId))]
        public Publisher Publisher { get; set; }

        public List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
