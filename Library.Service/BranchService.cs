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
   
    
        public class BranchService : IBranchService
        {
            private static int id = 4;
            private readonly IBranchRepository _branchRepository;

            public BranchService(IBranchRepository branchRepository)
            {
                _branchRepository = branchRepository;
            }

            public async Task<IEnumerable<Branch>> GetAllAsync()
            {
                return await _branchRepository.GetBranchsAsync();
            }

            public Branch GetById(int id)
            {
                return _branchRepository.GetById(id);
            }

            public async Task<Branch> AddBAsync(Branch b)
            {
                return await _branchRepository.AddAsync(b);
            }

            public async Task<Branch> PutBAsync(int id, Branch b)
            {
                return await _branchRepository.UpdateAsync(id, b);
            }

            public Branch DeleteB(int id)
            {
                Branch b = _branchRepository.GetById(id);
                return _branchRepository.Delete(b);
            }


        }
    
}