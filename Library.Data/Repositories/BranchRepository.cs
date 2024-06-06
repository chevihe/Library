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
    public class BranchRepository : IBranchRepository
    {

        private readonly DataContext _context;

        public BranchRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Branch>> GetBranchsAsync()
        {
            return await _context.Branches.ToListAsync(); 
        }


        public Branch GetById(int id)
        {
            return _context.Branches.FirstOrDefault(b => b.BranchId == id);
        }

        public async Task<Branch> AddAsync(Branch branch)
        {
            _context.Branches.Add(branch);
           await _context.SaveChangesAsync();
            return branch;
        }

        public async Task<Branch> UpdateAsync(int id, Branch branch)
        {
            Branch br =  GetById(id);
            if (br != null)
            {
                br.Addres = branch.Addres;
                br.Phone = branch.Phone;
                br.Name = branch.Name;
                await _context.SaveChangesAsync();
            }
            return branch;
        }

        public Branch Delete(Branch branch)
        {
            _context.Branches.Remove(branch);
            _context.SaveChanges();
            return branch;
        }
    }
}
