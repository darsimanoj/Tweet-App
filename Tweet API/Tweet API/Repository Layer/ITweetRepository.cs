using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweet_API.Models;

namespace Tweet_API.Repository_Layer
{
    public interface ITweetRepository
    {
        bool Add(Tweets tweet);
       
    }
}
