namespace BooksWebApi.Data.ViewModels
{
    public class AuthorWithBooks
    {
        public string Name { get; set; }

        public List<string> BookTitles { get; set; }
    }
}
