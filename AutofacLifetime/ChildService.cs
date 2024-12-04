using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacLifetime
{
    public class ChildService : IChildService
    {
        public int GetData()
        {
            return 1;
        }
    }
}
