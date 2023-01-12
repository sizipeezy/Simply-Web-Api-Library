namespace BooksWebApi.Data.ViewModels
{
    public class PublisherWithBooksAndAuthors
    {
        public string Name { get; set; }

        public List<BookAuthorViewModel> BookAuthors { get; set; } = new List<BookAuthorViewModel>();
    }
}
