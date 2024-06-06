using Library.Core.Entities;
using Library.Core.Repositories;
using Library.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
   
    
        public class BookService : IBookService
        {
            private static int id = 0;
            private readonly IBookRepository _iBookRepository;

            public BookService(IBookRepository iBookRepository)
            {
                _iBookRepository = iBookRepository;
            }
            public async Task<IEnumerable<Book>> GetAllAsync(string? name, int? status, int? branchId)
            {
                if (string.IsNullOrEmpty(name) && status == null && branchId == null)
                    return await _iBookRepository.GetBooksAsync();
                IEnumerable<Book> books = await _iBookRepository.GetBooksAsync();
                if (status == 1)//ספרים פנויים
                {
                    books = books.Where(bo => bo.Status == true);
                }
                else if (status == 2)
                {
                    books = books.Where(bo => bo.Status == false);
                }

                if (books.Count() == 0)
                    return null;

                if (!(string.IsNullOrEmpty(name)))
                {
                    books = books.Where(bo => bo.Name == name);
                }

                if (branchId != null)
                {
                    books = books.Where(bo => bo.BranchId == branchId);
                }
                return books;
            }

            public Book GetById(int id)
            {
                return  _iBookRepository.GetById(id);
            }

            public async Task<Book> AddBAsync(Book b)
            {
                return await _iBookRepository.AddAsync(new Book
                {
                    BookId = id++,
                    Name = b.Name,
                    Writer = b.Writer,
                    Status = b.Status,
                    BranchId = b.BranchId,
                    PartnerId = b.PartnerId
                });
            }
            public async Task<Book> PutBAsync(int id, Book? b, string? status)
            {
               
                if (status != "")
                {
                    Book book =  GetById(id);
                    book.Status = !(book.Status);
                    return await _iBookRepository.UpdateAsync(id, book);
                }
                return await _iBookRepository.UpdateAsync(id, b);
            }

            public Book DeleteB(int id)
            {
                Book b =  _iBookRepository.GetById(id);
                return  _iBookRepository.Delete(b);
            }
        }
    
}
