using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Blog.Business.Entity
{
    public partial class Comments
    {
        [DataMember]
        public IEnumerable<Comments> comments { get; set; }
    }
}
