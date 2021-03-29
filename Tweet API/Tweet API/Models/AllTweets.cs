using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tweet_API.Models
{
    public partial class AllTweets
    {
        public string UserName { get; set; }
        public string Tweet { get; set; }
    }
}
