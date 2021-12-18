using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointAPI
{
    public class TransferDTO
    {
        public int sourceId { get; set; }
        public int destId { get; set; }
        public decimal balance { get; set; }
        
    }
}
