using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public bool Status { get; set; }
        public int BranchId { get; set; }
        public int PartnerId { get; set; }

    }
}
