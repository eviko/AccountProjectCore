using System;
using System.Collections.Generic;
using System.Text;

namespace AccountProjectCore.Models
{
    public class Currency : EntityRoots
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
