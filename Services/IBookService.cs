namespace BooksWebApi.Services
{
    using BooksWebApi.Data.Models;
    using BooksWebApi.Data.ViewModels;
    public interface IBookService
    {
        public void AddBookWithAuthors(BookViewModel model);

        public List<Book> AllBooks();

        public Book GetById(int id);

        public Book UpdateById(int id, BookViewModel model);

        public void Delete(int id);
    }
}
