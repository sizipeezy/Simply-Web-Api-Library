namespace BooksWebApi.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
