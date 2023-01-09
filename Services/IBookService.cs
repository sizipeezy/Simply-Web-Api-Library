namespace BooksWebApi.Services
{
    using BooksWebApi.Data.Models;
    using BooksWebApi.Data.ViewModels;
    public interface IBookService
    {
        public void AddBook(BookViewModel model);

        public List<Book> AllBooks();

        public Book GetById(int id);
    }
}
