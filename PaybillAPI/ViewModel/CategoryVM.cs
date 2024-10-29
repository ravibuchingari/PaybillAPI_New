using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaybillAPI.ViewModel
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;
    }
}
