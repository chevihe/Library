using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Service
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync(string? name, int? status, int? branchI);
        Book GetById(int id);
        Task<Book> AddBAsync(Book b);
        Task<Book> PutBAsync(int id, Book? b, string? v);
        Book DeleteB(int id);
    }
}
