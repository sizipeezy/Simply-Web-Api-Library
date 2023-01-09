namespace BooksWebApi.Services
{
    using BooksWebApi.Data.ViewModels;
    public interface IBookService
    {
        public void AddBook(BookViewModel model);
    }
}
