using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("users")]
[Index("Mobile", Name = "Mobile_UNIQUE", IsUnique = true)]
[Index("SecurityKey", Name = "SecurityKey_UNIQUE", IsUnique = true)]
[Index("UserId", Name = "UserId_UNIQUE", IsUnique = true)]
[Index("CreatedBy", Name = "fk_users_createdby_idx")]
[Index("UpdatedBy", Name = "fk_users_updated_by_idx")]
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

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    [StringLength(600)]
    public string? BiometricAuthKey { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InverseCreatedByNavigation")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<User> InverseUpdatedByNavigation { get; set; } = new List<User>();

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

    [InverseProperty("DeletedByNavigation")]
    public virtual ICollection<PurchaseItemsDeleted> PurchaseItemsDeleteds { get; set; } = new List<PurchaseItemsDeleted>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Purchase> PurchaseUpdatedByNavigations { get; set; } = new List<Purchase>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Sale> SaleCreatedByNavigations { get; set; } = new List<Sale>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Sale> SaleUpdatedByNavigations { get; set; } = new List<Sale>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

    [InverseProperty("DeletedByNavigation")]
    public virtual ICollection<SalesItemsDeleted> SalesItemsDeleteds { get; set; } = new List<SalesItemsDeleted>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ServiceType> ServiceTypeCreatedByNavigations { get; set; } = new List<ServiceType>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<ServiceType> ServiceTypeUpdatedByNavigations { get; set; } = new List<ServiceType>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Setting> SettingCreatedByNavigations { get; set; } = new List<Setting>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Setting> SettingUpdatedByNavigations { get; set; } = new List<Setting>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Transaction> TransactionCreatedByNavigations { get; set; } = new List<Transaction>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Transaction> TransactionUpdatedByNavigations { get; set; } = new List<Transaction>();

    [InverseProperty("RequestedByNavigation")]
    public virtual ICollection<UnlockRequest> UnlockRequestRequestedByNavigations { get; set; } = new List<UnlockRequest>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<UnlockRequest> UnlockRequestUpdatedByNavigations { get; set; } = new List<UnlockRequest>();

    [ForeignKey("UpdatedBy")]
    [InverseProperty("InverseUpdatedByNavigation")]
    public virtual User? UpdatedByNavigation { get; set; }
}
