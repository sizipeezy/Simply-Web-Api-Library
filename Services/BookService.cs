namespace BooksWebApi.Services
{
    using BooksWebApi.Data;
    using BooksWebApi.Data.Models;
    using BooksWebApi.Data.ViewModels;
    using System.Collections.Generic;
    using System.Threading;

    public class BookService : IBookService
    {
        private readonly AppDbContext data;

        public BookService(AppDbContext data)
        {
            this.data = data;
        }

        public void AddBook(BookViewModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                IsRead = model.IsRead,
                DateRead = model.IsRead ? model.DateRead.Value : null,
                CoverUrl = model.CoverUrl,
                Rate = model.IsRead ? model.Rate.Value : null,
                Genre = model.Genre,
                Author = model.Author,
                DateAdded = DateTime.UtcNow,

            };

            data.Books.Add(book);
            data.SaveChanges();
        }

        public List<Book> AllBooks() => this.data.Books.ToList();

        public void Delete(int id) 
        {
            var book = this.data.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                this.data.Books.Remove(book);
            }

            this.data.SaveChanges();
        }
      

        public Book GetById(int id) => this.data.Books?.FirstOrDefault(x => x.Id == id);

        public Book UpdateById(int id, BookViewModel model)
        {
            var book = this.data.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                book.Title = model.Title;
                book.Description = model.Description;
                book.IsRead = model.IsRead;
                book.DateRead = model.IsRead ? model.DateRead.Value : null;
                book.CoverUrl = model.CoverUrl;
                book.Rate = model.IsRead ? model.Rate.Value : null;
                book.Genre = model.Genre;
                book.Author = model.Author;

                this.data.SaveChanges();
            }

            return book;

        }
    }
}
