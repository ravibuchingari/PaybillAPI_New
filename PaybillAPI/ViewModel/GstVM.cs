using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaybillAPI.ViewModel
{
    public class GstVM
    {
        public int GstId { get; set; }

        public float CgstPer { get; set; }

        public float SgstPer { get; set; }

        public float IgstPer { get; set; }

        public bool IsActive { get; set; }
    }
}
