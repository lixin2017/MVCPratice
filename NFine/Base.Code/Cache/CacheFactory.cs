using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Code
{
    class CacheFactory
    {
        public static Icache Cache()
        {
            return new Cache();
        }
    }
}
