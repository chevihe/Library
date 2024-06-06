using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Partner
    {
        public int PartnerId { get; set; }
        public List<Book> Books { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public string Phone { get; set; }

    }
}
