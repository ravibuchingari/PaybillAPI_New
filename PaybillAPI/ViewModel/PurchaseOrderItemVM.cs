namespace Paybill.ViewModel
{
    public class PurchaseOrderItemVM
    {
        public int PurchaseOrderItemId { get; set; }
        public int PurchaseOrderId { get; set; }
        public float Quantity { get; set; }
        public float Rate { get; set; }
        public double Amount { get; set; }
        public ItemVM ItemModel { get; set; } = new();

        public ItemVM Item
        {
            get => ItemModel;
            set => ItemModel = value ?? new ItemVM();
        }
        public int ItemId
        {
            get => ItemModel.ItemId;
            set => ItemModel.ItemId = value;
        }
    }
}
