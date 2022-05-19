using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public interface ICloseable
    {
        Action Close { get; set; }
    }
}
