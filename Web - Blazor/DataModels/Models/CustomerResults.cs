using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class CustomerResults
    {
        public IEnumerable<Customer>? Results { get; set; }
        public int Count { get; set; }
    }
}
