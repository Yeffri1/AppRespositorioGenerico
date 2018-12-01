using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRepositorioGenerico.Model
{
    public class Response
    {
        public int Error { get; set; } = 0;
        public string msg { get; set; }
    }
}
