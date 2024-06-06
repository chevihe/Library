using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Service
{
    public interface IPartnerService
    {
        Task<IEnumerable<Partner>> GetAllAsync();
        Partner GetById(int id);
        Task<Partner> AddPAsync(Partner p);
        Task<Partner> PutPAsync(int id, Partner p); 
        Partner DeleteP(int id);
    }
}
