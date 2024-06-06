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
    public class PartnerService : IPartnerService
    {
        private static int id = 4;

        private readonly IPartnerRepository _partnerRepository;

        public PartnerService(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<IEnumerable<Partner>> GetAllAsync()
        {

            return await _partnerRepository.GetPartnersAsync();
        }

        public Partner GetById(int id)
        {
            return _partnerRepository.GetById(id);
        }

        public async Task<Partner> AddPAsync(Partner p)
        {
            p.Books = new List<Book>();
            return await _partnerRepository.AddAsync(p);
        }

        public async Task<Partner> PutPAsync(int id, Partner p)
        {
            return await _partnerRepository.UpdateAsync(id, p);
        }

        public Partner DeleteP(int id)
        {
            Partner p = _partnerRepository.GetById(id);
            return _partnerRepository.Delete(p);
        }
    }
}