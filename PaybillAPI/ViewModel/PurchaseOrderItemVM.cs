namespace PaybillAPI.ViewModel
{
    public class PurchaseOrderItemVM
    {
        public int PurchaseOrderItemId { get; set; }

        public int PurchaseOrderId { get; set; }

        public float Quantity { get; set; }

        public float Rate { get; set; }

        public double Amount { get; set; }

        public ItemVM ItemModel { get; set; } = null!;
    }
}
