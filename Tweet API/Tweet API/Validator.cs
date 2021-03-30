using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tweet_API
{
    public static class Validator
    {
        public static bool Required (Object o) 
        {
            return o != null? true: false;
        }

        public static bool MaxLength(Object o, int length)
        {
            return o.ToString().Length < length ? true : false;
        }
    }
}
