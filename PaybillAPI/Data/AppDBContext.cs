using Microsoft.EntityFrameworkCore;
using PaybillAPI.DTO;

namespace PaybillAPI.Data;

public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
{
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Gst> Gsts { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<MessageTemplate> MessageTemplates { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }

    public virtual DbSet<PurchaseItemsDeleted> PurchaseItemsDeleteds { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesItem> SalesItems { get; set; }

    public virtual DbSet<SalesItemsDeleted> SalesItemsDeleteds { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionsDeleted> TransactionsDeleteds { get; set; }

    public virtual DbSet<UnlockRequest> UnlockRequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

}
