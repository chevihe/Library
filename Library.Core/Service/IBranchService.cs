using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Service
{
    public interface IBranchService
    {
        Task<IEnumerable<Branch>> GetAllAsync();
        Branch GetById(int id);
        Task<Branch> AddBAsync(Branch b);
        Task<Branch> PutBAsync(int id, Branch b);
        Branch DeleteB(int id);
    }
}
