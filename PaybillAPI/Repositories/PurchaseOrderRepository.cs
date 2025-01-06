using Microsoft.EntityFrameworkCore;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories
{
    public class PurchaseOrderRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), IPurchaseOrderRepository
    {
        public async Task<ResponseMessage> UpsertPurchaseOrder(PurchaseOrderVM purchaseOrderVM, int userRowId)
        {
            using var dbTrans = await dbContext.Database.BeginTransactionAsync();
            try
            {
                PurchaseOrder? purchaseOrder;
                if (purchaseOrderVM.PurchaseOrderId > 0)
                {
                    purchaseOrder = await dbContext.PurchaseOrders.Where(col => col.PurchaseOrderId == purchaseOrderVM.PurchaseOrderId).FirstOrDefaultAsync();
                    if (purchaseOrder == null)
                        return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Purchase order"));
                }
                else
                    purchaseOrder = new PurchaseOrder();

                purchaseOrder.PartyId = purchaseOrderVM.PartyModel.PartyId;
                purchaseOrder.OrderDate = DateTime.Parse(purchaseOrderVM.OrderDate);
                purchaseOrder.Remarks = purchaseOrderVM.Remarks ?? string.Empty;
                if (purchaseOrderVM.PurchaseOrderId == 0)
                {
                    purchaseOrder.CreatedDate = DateTime.Now;
                    purchaseOrder.CreatedBy = userRowId;
                    await dbContext.PurchaseOrders.AddAsync(purchaseOrder);
                }

                await SaveChangesAsync();

                foreach (PurchaseOrderItemVM purchaseItemVM in purchaseOrderVM.OrderItems!)
                {
                    if (purchaseOrder.PurchaseOrderId < 1)
                    {
                        await dbContext.PurchaseOrderItems.AddAsync(new PurchaseOrderItem()
                        {
                            PurchaseOrderId = purchaseOrder.PurchaseOrderId,
                            ItemId = purchaseItemVM.ItemModel!.ItemId,
                            Quantity = purchaseItemVM.Quantity,
                            Rate = purchaseItemVM.Rate,
                            Amount = purchaseItemVM.Quantity * purchaseItemVM.Rate,
                        });
                    }
                }
                await SaveChangesAsync();
                await dbTrans.CommitAsync();
                return new ResponseMessage(isSuccess: true, message: "Purchase order saved successfully.", data: purchaseOrder.PurchaseOrderId.ToString());
            }
            catch (DbUpdateException ex)
            {
                await dbTrans.RollbackAsync();
                DetachedEntries(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                await dbTrans.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<PurchaseOrderVM> GetPurchaseOrderDetails(int purchaseOrderId)
        {
            PurchaseOrderVM purchaseOrderVM = await dbContext.PurchaseOrders.Where(col => col.PurchaseOrderId == purchaseOrderId).Select(row => new PurchaseOrderVM()
            {
                PurchaseOrderId = row.PurchaseOrderId,
                OrderDate = row.OrderDate.ToString("dd-MMM-yyyy"),
                PartyModel = new PartyVM()
                {
                    PartyId = row.PartyId,
                    PartyName = row.Party.PartyName,
                    PartyAddress = row.Party.PartyAddress,
                    PartyShippingAddress = row.Party.PartyShippingAddress ?? string.Empty,
                    PartyMobile = row.Party.PartyMobile,
                    PartyGstNo = row.Party.PartyGstNo
                }

            }).FirstOrDefaultAsync() ?? throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Purchase invoice"));

            List<PurchaseOrderItemVM> list = await dbContext.PurchaseOrderItems.Where(col => col.PurchaseOrderId == purchaseOrderId).Select(row => new PurchaseOrderItemVM()
            {
                PurchaseOrderItemId = row.PurchaseOrderItemId,
                ItemModel = new ItemVM()
                {
                    ItemId = row.ItemId,
                    ItemCode = row.Item.ItemCode,
                    ItemName = row.Item.ItemName,
                    Measure = row.Item.Measure
                },
                Quantity = row.Quantity,
                Rate = row.Rate,
                Amount = row.Quantity * row.Rate
            }).ToListAsync();

            purchaseOrderVM.OrderItems = list;

            return purchaseOrderVM;

        }

        public async Task<ResponseMessage> DeletePurchaseOrderItem(int purchaseOrderItemId)
        {
            PurchaseOrderItem? purchaseOrderItem = await dbContext.PurchaseOrderItems.FirstOrDefaultAsync(col => col.PurchaseOrderItemId == purchaseOrderItemId);
            if (purchaseOrderItem != null)
            {
                dbContext.PurchaseOrderItems.Remove(purchaseOrderItem);
                await SaveChangesAsync();
                return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, "purchase order item"));
            }
            else
                return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Purchase order item"));
        }

        public async Task<IEnumerable<PurchaseOrderVM>> GetPurchaseOrderActiveList()
        {
            return await dbContext.PurchaseOrders.Include(itm => itm.PurchaseOrderItems).Where(col => col.Purchases.Count == 0).Select(row => new PurchaseOrderVM()
            {
                PurchaseOrderId = row.PurchaseOrderId,
                OrderDate = row.OrderDate.ToString("dd-MMM-yyyy"),
                OrderAmount = row.PurchaseOrderItems.Where(c => c.PurchaseOrderId == row.PurchaseOrderId).Sum(sm => sm.Amount),
                PurchaseInvoiceNo = string.Empty,
                PurchaseInvoiceDate = string.Empty,
                PartyModel = new PartyVM()
                {
                    PartyId = row.PartyId,
                    PartyName = row.Party.PartyName,
                    PartyMobile = row.Party.PartyMobile
                }
            }).ToListAsync();
        }

        public async Task<ResponseMessage> DeletePurchaseOrder(int purchaseOrderId)
        {
            PurchaseOrder? purchaseOrder = await dbContext.PurchaseOrders.Include(p => p.PurchaseOrderItems).FirstOrDefaultAsync(col => col.PurchaseOrderId == purchaseOrderId);
            if (purchaseOrder != null)
            {
                dbContext.PurchaseOrderItems.RemoveRange(purchaseOrder.PurchaseOrderItems);
                dbContext.PurchaseOrders.Remove(purchaseOrder);
                await SaveChangesAsync();
                return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, "purchase order"));
            }
            else
                return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Purchase order"));
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderItems(int purchaseOrderId)
        {

            List<PurchaseOrderItemVM> list = await dbContext.PurchaseOrderItems.Where(col => col.PurchaseOrderId == purchaseOrderId).Select(row => new PurchaseOrderItemVM()
            {
                PurchaseOrderItemId = row.PurchaseOrderItemId,
                ItemModel = new ItemVM()
                {
                    ItemId = row.ItemId,
                    ItemCode = row.Item.ItemCode,
                    ItemName = row.Item.ItemName,
                    Measure = row.Item.Measure
                },
                Quantity = row.Quantity,
                Rate = row.Rate,
                Amount = row.Quantity * row.Rate
            }).ToListAsync();

            return list;
        }
    }
}
