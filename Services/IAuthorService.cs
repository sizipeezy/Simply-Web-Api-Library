namespace BooksWebApi.Services
{
    using BooksWebApi.Data.ViewModels;


    public interface IAuthorService
    {
        public void AddAuthor(AuthorViewModel model);

        public AuthorWithBooks GetAuthorWithBooks(int id);
    }
}
