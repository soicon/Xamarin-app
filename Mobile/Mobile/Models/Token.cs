using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile.Models
{
    public class Token
    {
        public string token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
    }
}
