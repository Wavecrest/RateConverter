using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateConverter.Entities
{
    public class RateOutputModel
    {
        public required string originCountryCode { get; set; }
        public required string currency { get; set; }
        public required string destinationCountryCode { get; set; }
        public required string destinationKey { get; set; }
        public required string minorUnit { get; set; }
        public required string validFrom { get; set; }
        public required string connectionFee { get; set; }
        public required string rate { get; set; }
        public required string delimitedCode { get; set; }
        public required string destinationAndDescriptionKey { get; set; }
        public required string phoneNumberTypeKey { get; set; }

    }
}
