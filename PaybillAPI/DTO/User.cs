using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaybillAPI.DTO;

[Table("users")]
[Index("SecurityKey", Name = "SecurityKey_UNIQUE", IsUnique = true)]
[Index("UserId", Name = "UserId_UNIQUE", IsUnique = true)]
public partial class User
{
    [Key]
    public int UserRowId { get; set; }

    [StringLength(50)]
    public string UserId { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(500)]
    public string? Address { get; set; }

    [StringLength(10)]
    public string Mobile { get; set; } = null!;

    [StringLength(100)]
    public string Password { get; set; } = null!;

    public int IsAdmin { get; set; }

    public int IsActive { get; set; }

    [StringLength(45)]
    public string? SecurityKey { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }
}
