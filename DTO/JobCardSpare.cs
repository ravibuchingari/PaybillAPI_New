using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Paybill.DTO;

[Table("job_card_spares")]
[Index("ItemId", Name = "fk_job_card_spares_item_id_idx")]
[Index("ServiceRequestId", Name = "fk_job_card_spares_req_id_idx")]
public partial class JobCardSpare
{
    [Key]
    public int JobCardSpareId { get; set; }

    public int ServiceRequestId { get; set; }

    public int ItemId { get; set; }

    public double Quantity { get; set; }

    public double Mrp { get; set; }

    public double Rate { get; set; }

    public double Amount { get; set; }

    public double DiscountInRs { get; set; }

    public double TaxableAmount { get; set; }

    public float CgstPer { get; set; }

    public float SgstPer { get; set; }

    public float IgstPer { get; set; }

    public float GstPer { get; set; }

    public double CgstRs { get; set; }

    public double SgstRs { get; set; }

    public double IgstRs { get; set; }

    public double GstAmount { get; set; }

    public double TotalAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("JobCardSpares")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("ServiceRequestId")]
    [InverseProperty("JobCardSpares")]
    public virtual JobCard ServiceRequest { get; set; } = null!;
}
