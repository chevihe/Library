using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IPartnerRepository
    {
         Task<IEnumerable<Partner>> GetPartnersAsync();
         Partner GetById(int id);
         Task<Partner> AddAsync(Partner partner);
         Task<Partner> UpdateAsync(int id, Partner partner);
         Partner Delete(Partner partner);
    }
}
