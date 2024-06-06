using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IBookRepository
    {
         Task<IEnumerable<Book>> GetBooksAsync();
         Book GetById(int id);
         Task<Book> AddAsync(Book book);
         Task<Book> UpdateAsync(int id, Book book);
         Book Delete(Book book);

    }
}
