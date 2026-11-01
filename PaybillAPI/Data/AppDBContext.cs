using Microsoft.EntityFrameworkCore;
using Paybill.DTO;

namespace Paybill.Data;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Client1> Clients1 { get; set; }

    public virtual DbSet<CustomReceiptLine> CustomReceiptLines { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Gst> Gsts { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<JobCard> JobCards { get; set; }

    public virtual DbSet<JobCardItem> JobCardItems { get; set; }

    public virtual DbSet<JobCardSpare> JobCardSpares { get; set; }

    public virtual DbSet<MessageTemplate> MessageTemplates { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }

    public virtual DbSet<PurchaseItemsDeleted> PurchaseItemsDeleteds { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    public virtual DbSet<RewardTransaction> RewardTransactions { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesItem> SalesItems { get; set; }

    public virtual DbSet<SalesItemsDeleted> SalesItemsDeleteds { get; set; }

    public virtual DbSet<ServiceRequestStatus> ServiceRequestStatuses { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionsDeleted> TransactionsDeleteds { get; set; }

    public virtual DbSet<UnlockRequest> UnlockRequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientUniqueId).HasName("PRIMARY");

            entity.Property(e => e.CountryCurrencyCode).HasDefaultValueSql("'Rs'");
            entity.Property(e => e.CountryCurrencySymbol).HasDefaultValueSql("'₹'");
            entity.Property(e => e.CountryId).HasDefaultValueSql("'28'");
            entity.Property(e => e.CountryLocaleCode).HasDefaultValueSql("'in'");
            entity.Property(e => e.CountryMobileLength).HasDefaultValueSql("'10'");
            entity.Property(e => e.CountryName).HasDefaultValueSql("'India'");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Client1>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PRIMARY");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<CustomReceiptLine>(entity =>
        {
            entity.HasKey(e => e.CustomLineId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.CustomLineDescription).HasDefaultValueSql("''");
            entity.Property(e => e.CustomLineTitle).HasDefaultValueSql("''");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerRowId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Gst>(entity =>
        {
            entity.HasKey(e => e.GstId).HasName("PRIMARY");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.HasOne(d => d.Category).WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_items_category_id");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ItemCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_items_created_by");

            entity.HasOne(d => d.Gst).WithMany(p => p.Items).HasConstraintName("fk_items_gst_id");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ItemUpdatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_items_updated_by");
        });

        modelBuilder.Entity<JobCard>(entity =>
        {
            entity.HasKey(e => e.ServiceRequestId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.ServiceRequestStatusId).HasDefaultValueSql("'1'");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<JobCardItem>(entity =>
        {
            entity.HasKey(e => e.ServiceRequestComplaintId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<JobCardSpare>(entity =>
        {
            entity.HasKey(e => e.JobCardSpareId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Quantity).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<MessageTemplate>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PRIMARY");

            entity.Property(e => e.MessageType).HasDefaultValueSql("'Sales Invoice Message'");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderRowId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.CustomerRow).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orders_customer_row_id");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_status_id");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemRowId).HasName("PRIMARY");

            entity.HasOne(d => d.OrderRow).WithMany(p => p.OrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_items_order_row_id");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PRIMARY");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.PartyId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PartyCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_parties_created_by");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.PartyUpdatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_parties_updated_by");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PRIMARY");

            entity.Property(e => e.IsLocked).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PurchaseCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_created_by");

            entity.HasOne(d => d.Party).WithMany(p => p.Purchases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_partry_id");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.Purchases).HasConstraintName("fk_purchase_order_id");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.PurchaseUpdatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_updated_by");
        });

        modelBuilder.Entity<PurchaseItem>(entity =>
        {
            entity.HasKey(e => e.PurchaseItemId).HasName("PRIMARY");

            entity.HasOne(d => d.Item).WithMany(p => p.PurchaseItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_item_item_id");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_item_purchase_id");
        });

        modelBuilder.Entity<PurchaseItemsDeleted>(entity =>
        {
            entity.HasKey(e => e.PurchaseDeletedItemId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.DeletedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.PurchaseItemsDeleteds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_deleted_purchaseitem_deleted_by");

            entity.HasOne(d => d.Item).WithMany(p => p.PurchaseItemsDeleteds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_deleted_purchaseitem_item_id");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderId).HasName("PRIMARY");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PurchaseOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_order_created_by");

            entity.HasOne(d => d.Party).WithMany(p => p.PurchaseOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_order_vendor_id");
        });

        modelBuilder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderItemId).HasName("PRIMARY");

            entity.HasOne(d => d.Item).WithMany(p => p.PurchaseOrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_order_items_item_id");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_order_items_order_id");
        });

        modelBuilder.Entity<RewardTransaction>(entity =>
        {
            entity.HasKey(e => e.RewardTransId).HasName("PRIMARY");

            entity.Property(e => e.CreatedBy).HasDefaultValueSql("'0'");
            entity.Property(e => e.Description).HasDefaultValueSql("''");
            entity.Property(e => e.RefTransId).HasDefaultValueSql("'0'");
            entity.Property(e => e.SalesId).HasDefaultValueSql("'0'");
            entity.Property(e => e.TransactionDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SalesId).HasName("PRIMARY");

            entity.Property(e => e.IsLocked).HasDefaultValueSql("'1'");
            entity.Property(e => e.ServiceRequestId).HasDefaultValueSql("'0'");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SaleCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sales_created_by");

            entity.HasOne(d => d.Party).WithMany(p => p.Sales).HasConstraintName("fk_sales_party_id");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.SaleUpdatedByNavigations).HasConstraintName("fk_sales_updated_by");
        });

        modelBuilder.Entity<SalesItem>(entity =>
        {
            entity.HasKey(e => e.SalesItemId).HasName("PRIMARY");

            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Item).WithMany(p => p.SalesItems).HasConstraintName("fk_sales_item_item_id");

            entity.HasOne(d => d.Sales).WithMany(p => p.SalesItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sales_item_sales_id");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.SalesItems).HasConstraintName("fk_sales_item_service_type_id");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.SalesItems).HasConstraintName("fk_sales_item_updated_by");
        });

        modelBuilder.Entity<SalesItemsDeleted>(entity =>
        {
            entity.HasKey(e => e.SalesDeletedItemId).HasName("PRIMARY");

            entity.Property(e => e.DeletedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.SalesItemsDeleteds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_deleted_sales_item_deleted_by");

            entity.HasOne(d => d.Item).WithMany(p => p.SalesItemsDeleteds).HasConstraintName("fk_deleted_salesitem_item_id");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.SalesItemsDeleteds).HasConstraintName("fk_deleted_salesitem_service_type_id");
        });

        modelBuilder.Entity<ServiceRequestStatus>(entity =>
        {
            entity.HasKey(e => e.ServiceRequestStatusId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.ServiceTypeId).HasName("PRIMARY");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ServiceTypeCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_service_type_createdby");

            entity.HasOne(d => d.Gst).WithMany(p => p.ServiceTypes).HasConstraintName("fk_service_types_gst_id");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ServiceTypeUpdatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_service_type_updatedby");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.RowId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.InvoiceLength).HasDefaultValueSql("'6'");
            entity.Property(e => e.IsAutoBackupWhatsAppEnabled).HasDefaultValueSql("'1'");
            entity.Property(e => e.IsGstSummaryRequired).HasDefaultValueSql("'1'");
            entity.Property(e => e.IsPaymentDetailsRequired).HasDefaultValueSql("'1'");
            entity.Property(e => e.IsSalesInvoiceDateEnabled).HasDefaultValueSql("'1'");
            entity.Property(e => e.IsSavingDetailsRequired).HasDefaultValueSql("'1'");
            entity.Property(e => e.IsSendSmsonInvoice).HasDefaultValueSql("'1'");
            entity.Property(e => e.IsSoundEnabled).HasDefaultValueSql("'1'");
            entity.Property(e => e.ItemCodeAllowNumberOnly).HasDefaultValueSql("'1'");
            entity.Property(e => e.MaxItemImageDimension).HasDefaultValueSql("'512'");
            entity.Property(e => e.PaymentGatewayApiKey).HasDefaultValueSql("''");
            entity.Property(e => e.PaymentGatewayApiSecret).HasDefaultValueSql("''");
            entity.Property(e => e.PaymentGatewayMerchantId).HasDefaultValueSql("''");
            entity.Property(e => e.PaymentGatewayName).HasDefaultValueSql("'None'");
            entity.Property(e => e.RewardAllowPartialRedemption).HasDefaultValueSql("'1'");
            entity.Property(e => e.RewardEarningMethod).HasDefaultValueSql("'FIXED_POINTS'");
            entity.Property(e => e.RewardEarningPercentage).HasDefaultValueSql("'2'");
            entity.Property(e => e.RewardEarningPoints).HasDefaultValueSql("'1'");
            entity.Property(e => e.RewardEarningPurchaseAmount).HasDefaultValueSql("'100'");
            entity.Property(e => e.RewardEligibleAmountType).HasDefaultValueSql("'TOTAL_WITH_TAX'");
            entity.Property(e => e.RewardEndDate).HasDefaultValueSql("''");
            entity.Property(e => e.RewardExpiryDays).HasDefaultValueSql("'365'");
            entity.Property(e => e.RewardMaxRedemptionPercentage).HasDefaultValueSql("'20'");
            entity.Property(e => e.RewardMinPurchaseForEarning).HasDefaultValueSql("'100'");
            entity.Property(e => e.RewardPointValue).HasDefaultValueSql("'1'");
            entity.Property(e => e.RewardStartDate).HasDefaultValueSql("''");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.BalanceMessage).WithMany(p => p.SettingBalanceMessages).HasConstraintName("fk_settings_balance_message_id");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SettingCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_settings_created_by");

            entity.HasOne(d => d.FestivalMessage).WithMany(p => p.SettingFestivalMessages).HasConstraintName("fk_settings_festival_message_id");

            entity.HasOne(d => d.SalesMessage).WithMany(p => p.SettingSalesMessages).HasConstraintName("fk_settings_sales_message_id");

            entity.HasOne(d => d.ServiceMessage).WithMany(p => p.SettingServiceMessages).HasConstraintName("fk_settings_service_message_id");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.SettingUpdatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_settings_updated_by");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TransactionCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transaction_created_by");

            entity.HasOne(d => d.Party).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transaction_party_id");

            entity.HasOne(d => d.Purchase).WithMany(p => p.Transactions).HasConstraintName("fk_transaction_purchase_id");

            entity.HasOne(d => d.Sales).WithMany(p => p.Transactions).HasConstraintName("fk_transaction_sales_id");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TransactionUpdatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transaction_updated_by");
        });

        modelBuilder.Entity<TransactionsDeleted>(entity =>
        {
            entity.HasKey(e => e.DeletedTransactionId).HasName("PRIMARY");

            entity.Property(e => e.DeletedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<UnlockRequest>(entity =>
        {
            entity.HasKey(e => e.UnlockRequestId).HasName("PRIMARY");

            entity.HasOne(d => d.Purchase).WithMany(p => p.UnlockRequests).HasConstraintName("fk_request_purchase_id");

            entity.HasOne(d => d.RequestedByNavigation).WithMany(p => p.UnlockRequestRequestedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_request_requested_by");

            entity.HasOne(d => d.Sales).WithMany(p => p.UnlockRequests).HasConstraintName("fk_request_sales_id");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.UnlockRequestUpdatedByNavigations).HasConstraintName("fk_request_updated_by");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserRowId).HasName("PRIMARY");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation).HasConstraintName("fk_users_created_by");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InverseUpdatedByNavigation).HasConstraintName("fk_users_updated_by");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
