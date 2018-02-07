using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model
{
    public class Combos
    {
        public class TBaseItem
        {
            public int Id { get; set; }
            public string name { get; set; }
        }
        public class TDs : TBaseItem { }

    }
}
