using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects
{
    public class OHistories
    {
        public Guid IdHis { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdStatus { get; set; }
        public Guid IdGroup { get; set; }
        public int? Amount { get; set; }
        public List<OUsers> listuser { get; set; }
    }
}
