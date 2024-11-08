﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("sales_items_deleted")]
[Index("ItemId", Name = "fk_deleted_salesitem_item_id_idx")]
public partial class SalesItemsDeleted
{
    [Key]
    [Column("salesDeletedItemId")]
    public int SalesDeletedItemId { get; set; }

    public int SalesId { get; set; }

    public int ItemId { get; set; }

    public float Quantity { get; set; }

    public float Rate { get; set; }

    public float Mrp { get; set; }

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

    [Column(TypeName = "datetime")]
    public DateTime DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    [StringLength(250)]
    public string? DeletedRemarks { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("SalesItemsDeleteds")]
    public virtual Item Item { get; set; } = null!;
}
