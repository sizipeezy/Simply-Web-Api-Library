namespace BooksWebApi.Services
{
    using BooksWebApi.Data;
    using BooksWebApi.Data.Models;
    using BooksWebApi.Data.ViewModels;


    public class AuthorService : IAuthorService
    {
        private AppDbContext data;

        public AuthorService(AppDbContext data)
        {
            this.data = data;
        }

        public void AddAuthor(AuthorViewModel model)
        {
            var author = new Author()
            {
                Name = model.Name,  
            };

            this.data.Authors.Add(author);
            this.data.SaveChanges();
        }
    }
}
