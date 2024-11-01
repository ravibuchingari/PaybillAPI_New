﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [StringLength(100)]
    public string? UserSaltKey { get; set; }

    public int IsAdmin { get; set; }

    public int IsActive { get; set; }

    [StringLength(45)]
    public string? SecurityKey { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Item> ItemCreatedByNavigations { get; set; } = new List<Item>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Item> ItemUpdatedByNavigations { get; set; } = new List<Item>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Party> PartyCreatedByNavigations { get; set; } = new List<Party>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Party> PartyUpdatedByNavigations { get; set; } = new List<Party>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Purchase> PurchaseCreatedByNavigations { get; set; } = new List<Purchase>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Purchase> PurchaseUpdatedByNavigations { get; set; } = new List<Purchase>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Setting> SettingCreatedByNavigations { get; set; } = new List<Setting>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Setting> SettingUpdatedByNavigations { get; set; } = new List<Setting>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Transaction> TransactionCreatedByNavigations { get; set; } = new List<Transaction>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Transaction> TransactionUpdatedByNavigations { get; set; } = new List<Transaction>();
}
