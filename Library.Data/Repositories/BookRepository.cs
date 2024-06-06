using Library.Core.Entities;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public class BookRepository : IBookRepository


    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public  Book GetById(int id)
        {
            return  _context.Books.FirstOrDefault(b => b.BookId == id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            Book b =  GetById(id);
            if (b != null)
            {
                b.Writer = book.Writer;
                b.Status = book.Status;
                b.Name = book.Name;
                b.BranchId = book.BranchId;
                b.PartnerId=book.PartnerId;
                await _context.SaveChangesAsync();
            }
            return book;
        }

        public Book Delete(Book book)
        {
            _context.Books.Remove(book);
             _context.SaveChanges();
            return book;
        }

    }
}
