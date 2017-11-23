using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Service.Models
{
    public interface BaseModel
    {
        long Id { get; set; }
        DateTime Created { get; set; }
        DateTime LastModified { get; set; }
    }
}
