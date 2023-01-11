namespace BooksWebApi.Data.ViewModels
{
    public class BookViewModel
    { 
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }

        public int? Rate { get; set; }

        public string CoverUrl { get; set; }

        public string Genre { get; set; }

        public int PublisherId { get; set; }

        public List<int> AuthorsIds { get; set; }
    }
}
