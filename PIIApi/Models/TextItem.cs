using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIIApi.Models
{
    public class TextItem
    {
        public int ID { get; set; }
        public string TextBody { get; set; }
        public bool hasPii { get; set; }
    }
}
