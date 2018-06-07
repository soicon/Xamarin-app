using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VNRC_WEB.Models
{
    public class LocationCustom
    {
        public int LocationId { get; set; }
        public String Name { get; set; }
        public LocationCustom Parent { get; set; }

    }
}
