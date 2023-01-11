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

        public void AddBookWithAuthors(BookViewModel model)
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
                DateAdded = DateTime.UtcNow,
                PublisherId = model.PublisherId,
            };

            data.Books.Add(book);
            data.SaveChanges();

            foreach (var id in model.AuthorsIds)
            {
                var booksAuthors = new BookAuthor()
                {
                    BookId = book.Id,
                    AuthorId = id
                };
                data.BookAuthors.Add(booksAuthors);
                data.SaveChanges();
            }
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


        public BookWithAuthors GetById(int id)
        {
            var bookWithAuthors = this.data.Books.Where(x => x.Id == id)
                .Select(model => new BookWithAuthors
            {
                Title = model.Title,
                Description = model.Description,
                IsRead = model.IsRead,
                DateRead = model.IsRead ? model.DateRead.Value : null,
                CoverUrl = model.CoverUrl,
                Rate = model.IsRead ? model.Rate.Value : null,
                Genre = model.Genre,
                PublisherName = model.Publisher.Name,
                AuthorNames = model.BookAuthors.Select(x => x.Author.Name).ToList()
            }).FirstOrDefault();

            return bookWithAuthors; 
        }

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

                this.data.SaveChanges();
            }

            return book;

        }
    }
}
