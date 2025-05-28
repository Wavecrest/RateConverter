using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateConverter.Entities
{
    public class RateInputModel
    {
        public string Destination { get; set; }
        public string Codes { get; set; }
        public string Rate { get; set; }
    }
}
