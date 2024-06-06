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
    public class PartnerRepository : IPartnerRepository
    {
        private readonly DataContext _context;

        public PartnerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Partner>> GetPartnersAsync()
        {
            return await _context.Partners.ToListAsync();
        }

        public Partner GetById(int id)
        {
            return _context.Partners.FirstOrDefault(b => b.PartnerId == id);
        }

        public async Task<Partner> AddAsync(Partner partner)
        {
            _context.Partners.Add(partner);
             await _context.SaveChangesAsync();
            return partner;
        }

        public async Task<Partner> UpdateAsync(int id, Partner partner)
        {
            Partner p = _context.Partners.FirstOrDefault(b => b.PartnerId == id);
            if (p != null)
            {
                p.Addres = partner.Addres;
                p.Phone = partner.Phone;
                p.Name = partner.Name;
               // p.Books = partner.Books;
              //  _context.Partners.Add(partner);
               await _context.SaveChangesAsync();
            }
            return partner;
        }

        public Partner Delete(Partner partner)
        {
            _context.Partners.Remove(partner);
            _context.SaveChanges();
            return partner;
        }
    }
}
