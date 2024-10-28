using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaybillAPI.DTO;

[Table("gst")]
public partial class Gst
{
    [Key]
    [Column("gstId")]
    public int GstId { get; set; }

    [Column("cgstPer")]
    public float CgstPer { get; set; }

    [Column("sgstPer")]
    public float SgstPer { get; set; }

    [Column("igstPer")]
    public float IgstPer { get; set; }

    [Column("isActive")]
    public int IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }
}
