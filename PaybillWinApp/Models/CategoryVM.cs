using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Models
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public int ItemCount { get; set; }

    }
}
