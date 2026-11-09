using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr3
{
    public partial class Products
    {
        public int TotalQuantity => Stock?.Sum(q => q.Quantity) ?? 0;
    }
}
