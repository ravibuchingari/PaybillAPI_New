using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaybillAPI.DTO;

[Table("items")]
public partial class Item
{
    [Key]
    [Column("itemId")]
    public int ItemId { get; set; }

    [Column("categoryId")]
    public int CategoryId { get; set; }

    [Column("gstId")]
    public int? GstId { get; set; }

    [Column("itemCode")]
    [StringLength(50)]
    public string ItemCode { get; set; } = null!;

    [Column("itemName")]
    [StringLength(100)]
    public string ItemName { get; set; } = null!;

    [Column("aliasName")]
    [StringLength(250)]
    public string? AliasName { get; set; }

    [Column("mrp")]
    public float Mrp { get; set; }

    [Column("salesPrice")]
    public float SalesPrice { get; set; }

    [Column("purchasePrice")]
    public float PurchasePrice { get; set; }

    [Column("hSNCode")]
    [StringLength(20)]
    public string? HSncode { get; set; }

    [Column("measure")]
    [StringLength(20)]
    public string Measure { get; set; } = null!;

    [Column("openingStock")]
    public double OpeningStock { get; set; }

    [Column("closingStock")]
    public double ClosingStock { get; set; }

    [Column("minimumStock")]
    public double MinimumStock { get; set; }

    [Column("isActive")]
    public int IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }
}
