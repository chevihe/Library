using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IBranchRepository
    {
        public Task<IEnumerable<Branch>> GetBranchsAsync();
        public Branch GetById(int id);
        public Task<Branch> AddAsync(Branch branch);
        public Task<Branch> UpdateAsync(int id, Branch branch);
        public Branch Delete(Branch branch);
    }
}
