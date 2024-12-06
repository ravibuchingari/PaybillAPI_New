using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories
{
    public class ItemRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), IItemRepository
    {

        #region "Category"

        public async Task<ResponseMessage> UpsertCategory(CategoryVM categoryVM, int userRowId)
        {
            Category? category = await dbContext.Categories.Where(col => col.CategoryId == categoryVM.CategoryId).FirstOrDefaultAsync();
            if (category != null)
            {
                category.CategoryName = categoryVM.CategoryName;
                category.UpdatedBy = userRowId;
                category.UpdatedDate = DateTime.Now;
            }
            else
            {
                category = new Category
                {
                    CategoryName = categoryVM.CategoryName,
                    CreatedBy = userRowId,
                    UpdatedBy = userRowId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                await dbContext.Categories.AddAsync(category);
            }
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: $"{(categoryVM.CategoryId == 0 ? "Category created successfully" : "Category updated successfully")}");
        }

        public async Task<IEnumerable<CategoryVM>> GetCategories()
        {
            return await dbContext.Categories.Select(row => new CategoryVM()
            {
                CategoryId = row.CategoryId,
                CategoryName = row.CategoryName
            }).ToListAsync();
        }

        public async Task<CategoryVM> GetCategoryDetails(int categoryId)
        {
            Category? category = await dbContext.Categories.FirstOrDefaultAsync(col => col.CategoryId == categoryId);
            if (category != null)
                return new CategoryVM() { CategoryId = category.CategoryId, CategoryName = category.CategoryName };
            else
                throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Category"));
        }

        public async Task<ResponseMessage> DeleteCategory(int categoryId)
        {
            Category? category = await dbContext.Categories.FirstOrDefaultAsync(col => col.CategoryId == categoryId);
            if (category != null)
            {
                dbContext.Categories.Remove(category);
                await SaveChangesAsync();
                return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, "category"));
            }
            else
                throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Category"));
        }

        public async Task<IEnumerable<CategoryVM>> GetCategoriesWithItemCount()
        {
            return await dbContext.Categories.Select(row => new CategoryVM()
            {
                CategoryId = row.CategoryId,
                CategoryName = row.CategoryName,
                ItemCount = row.Items.Count()
            }).ToListAsync();
        }

        public async Task<ResponseMessage> CreateCategoryIfNotExists(string categoryName, int userRowId)
        {
            Category? category = await dbContext.Categories.Where(col => col.CategoryName == categoryName).FirstOrDefaultAsync();
            if (category == null)
            {
                category = new Category
                {
                    CategoryName = categoryName,
                    CreatedBy = userRowId,
                    UpdatedBy = userRowId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                await dbContext.Categories.AddAsync(category);
                await SaveChangesAsync();
            }
            return new ResponseMessage(isSuccess: true, message: category.CategoryId.ToString());
        }

        #endregion

        #region "GST"

        public async Task<ResponseMessage> UpsertGst(GstVM gstVM, int userRowId)
        {
            Gst? gst = await dbContext.Gsts.Where(col => col.GstId == gstVM.GstId).FirstOrDefaultAsync();
            if (gst != null)
            {
                gst.SgstPer = gstVM.SgstPer;
                gst.CgstPer = gstVM.CgstPer;
                gst.IgstPer = gstVM.IgstPer;
                gst.IsActive = (sbyte)gstVM.IsActive.GetHashCode();
                gst.UpdatedBy = userRowId;
                gst.UpdatedDate = DateTime.Now;
            }
            else
            {
                gst = new Gst
                {
                    SgstPer = gstVM.SgstPer,
                    CgstPer = gstVM.CgstPer,
                    IgstPer = gstVM.IgstPer,
                    IsActive = (sbyte)gstVM.IsActive.GetHashCode(),
                    CreatedBy = userRowId,
                    UpdatedBy = userRowId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                await dbContext.Gsts.AddAsync(gst);
            }
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: $"{(gstVM.GstId == 0 ? "GST created successfully" : "GST updated successfully")}");
        }

        public async Task<ResponseMessage> CreateGstIfNotExists(GstVM gstVM, int userRowId)
        {
            Gst? gst = await dbContext.Gsts.Where(col => col.IgstPer == gstVM.IgstPer && col.CgstPer == gstVM.CgstPer && col.SgstPer == gstVM.SgstPer).FirstOrDefaultAsync();
            if (gst == null)
            {
                gst = new Gst()
                {
                    IgstPer = gstVM.IgstPer,
                    CgstPer = gstVM.CgstPer,
                    SgstPer = gstVM.SgstPer,
                    CreatedBy = userRowId,
                    UpdatedBy = userRowId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                await dbContext.Gsts.AddAsync(gst);
                await SaveChangesAsync();
            }
            return new ResponseMessage(isSuccess: true, message: gst.GstId.ToString());
        }

        public async Task<IEnumerable<GstVM>> GetGsts(bool isActive)
        {
            if (isActive)
            {
                return await dbContext.Gsts.Where(col => col.IsActive == 1).Select(row => new GstVM()
                {
                    GstId = row.GstId,
                    SgstPer = row.SgstPer,
                    CgstPer = row.CgstPer,
                    IgstPer = row.IgstPer,
                    IsActive = row.IsActive == 1
                }).ToListAsync();
            }
            else
            {
                return await dbContext.Gsts.Select(row => new GstVM()
                {
                    GstId = row.GstId,
                    SgstPer = row.SgstPer,
                    CgstPer = row.CgstPer,
                    IgstPer = row.IgstPer,
                    IsActive = row.IsActive == 1
                }).ToListAsync();
            }
        }

        public async Task<GstVM> GetGstDetails(int gstId)
        {
            Gst? gst = await dbContext.Gsts.FirstOrDefaultAsync(col => col.GstId == gstId);
            if (gst != null)
                return new GstVM() { GstId = gst.GstId, SgstPer = gst.SgstPer, CgstPer = gst.CgstPer, IgstPer = gst.IgstPer, IsActive = gst.IsActive == 1 };
            else
                throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "GST"));
        }

        public async Task<ResponseMessage> DeleteGST(int gstId)
        {
            Gst? gst = await dbContext.Gsts.FirstOrDefaultAsync(col => col.GstId == gstId);
            if (gst != null)
            {
                dbContext.Gsts.Remove(gst);
                await SaveChangesAsync();
                return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, "GST"));
            }
            else
                throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "GST"));
        }

        #endregion

        #region "Item"

        private static Item MapItem(ItemVM itemVM, Item item)
        {
            item.CategoryId = itemVM.CategoryModel!.CategoryId;
            if (itemVM.GstModel != null)
                item.GstId = itemVM.GstModel.GstId;
            item.ItemCode = itemVM.ItemCode;
            item.ItemName = itemVM.ItemName;
            item.AliasName = itemVM.AliasName ?? "";
            item.Mrp = itemVM.Mrp;
            item.SalesPrice = itemVM.SalesPrice;
            item.PurchasePrice = itemVM.PurchasePrice;
            item.Hsncode = itemVM.HSncode;
            item.Measure = itemVM.Measure ?? string.Empty;
            item.OpeningStock = itemVM.OpeningStock;
            item.MinimumStock = itemVM.MinimumStock;
            item.IsActive = (sbyte)itemVM.IsActive.GetHashCode();
            return item;
        }

        public async Task<ResponseMessage> UpsertItem(ItemVM itemVM, int userRowId)
        {
            Item? item;
            if (itemVM.ItemId == 0)
            {
                item = MapItem(itemVM, new Item());
                item.CreatedDate = DateTime.Now;
                item.CreatedBy = userRowId;
                item.UpdatedDate = DateTime.Now;
                item.UpdatedBy = userRowId;
                await dbContext.Items.AddAsync(item);
            }
            else
            {
                item = await dbContext.Items.Where(col => col.ItemId == itemVM.ItemId).FirstOrDefaultAsync();
                if (item == null)
                    return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Item"));
                item = MapItem(itemVM, item);
                item.UpdatedDate = DateTime.Now;
                item.UpdatedBy = userRowId;
            }
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: $"{(itemVM.ItemId == 0 ? "Item created successfully" : "Item updated successfully")}", data: item.ItemId.ToString());
        }

        public async Task<IEnumerable<ItemVM>> GetItems(int categoryId, string filter)
        {
            if (filter.Trim().IsNullOrEmpty())
                return await dbContext.Items.Where(col => col.CategoryId == (categoryId > 0 ? categoryId : col.CategoryId)).Select(row => new ItemVM()
                {
                    ItemId = row.ItemId,
                    ItemCode = row.ItemCode,
                    ItemName = row.ItemName,
                    AliasName = row.AliasName,
                    Mrp = row.Mrp,
                    SalesPrice = row.SalesPrice,
                    PurchasePrice = row.PurchasePrice,
                    HSncode = row.Hsncode,
                    Measure = row.Measure,
                    OpeningStock = row.OpeningStock,
                    ClosingStock = row.OpeningStock + row.ClosingStock,
                    IsActive = row.IsActive == 1,
                    CategoryModel = new CategoryVM() { CategoryId = row.CategoryId, CategoryName = row.Category.CategoryName },
                    GstModel = row.Gst != null ? new GstVM()
                    {
                        GstId = row.Gst.GstId,
                        SgstPer = row.Gst.SgstPer,
                        CgstPer = row.Gst.CgstPer,
                        IgstPer = row.Gst.IgstPer
                    } : null
                }).OrderBy(ord => ord.ItemName).ToListAsync();
            else
                return await dbContext.Items.Where(col => col.CategoryId == (categoryId > 0 ? categoryId : col.CategoryId) && col.ItemCode.StartsWith(filter, StringComparison.OrdinalIgnoreCase) ||
                                                    col.ItemName.StartsWith(filter, StringComparison.OrdinalIgnoreCase) ||
                                                    col.Category.CategoryName.StartsWith(filter, StringComparison.OrdinalIgnoreCase)).Select(row => new ItemVM()
                                                    {
                                                        ItemId = row.ItemId,
                                                        ItemCode = row.ItemCode,
                                                        ItemName = row.ItemName,
                                                        AliasName = row.AliasName,
                                                        Mrp = row.Mrp,
                                                        SalesPrice = row.SalesPrice,
                                                        PurchasePrice = row.PurchasePrice,
                                                        HSncode = row.Hsncode,
                                                        Measure = row.Measure,
                                                        OpeningStock = row.OpeningStock,
                                                        ClosingStock = row.OpeningStock + row.ClosingStock,
                                                        IsActive = row.IsActive == 1,
                                                        CategoryModel = new CategoryVM() { CategoryId = row.CategoryId, CategoryName = row.Category.CategoryName },
                                                        GstModel = row.Gst != null ? new GstVM()
                                                        {
                                                            GstId = row.Gst.GstId,
                                                            SgstPer = row.Gst.SgstPer,
                                                            CgstPer = row.Gst.CgstPer,
                                                            IgstPer = row.Gst.IgstPer
                                                        } : null
                                                    }).OrderBy(ord => ord.ItemName).ToListAsync();
        }

        public async Task<ItemVM> GetItemDetails(int itemId)
        {
            ItemVM? itemVM = await dbContext.Items.Where(col => col.ItemId == itemId).Select(row => new ItemVM()
            {
                ItemId = row.ItemId,
                ItemCode = row.ItemCode,
                ItemName = row.ItemName,
                AliasName = row.AliasName,
                Mrp = row.Mrp,
                SalesPrice = row.SalesPrice,
                PurchasePrice = row.PurchasePrice,
                HSncode = row.Hsncode,
                Measure = row.Measure,
                OpeningStock = row.OpeningStock,
                ClosingStock = row.OpeningStock + row.ClosingStock,
                IsActive = row.IsActive == 1,
                CategoryModel = new CategoryVM() { CategoryId = row.CategoryId, CategoryName = row.Category.CategoryName },
                GstModel = row.Gst != null ? new GstVM()
                {
                    GstId = row.Gst.GstId,
                    SgstPer = row.Gst.SgstPer,
                    CgstPer = row.Gst.CgstPer,
                    IgstPer = row.Gst.IgstPer
                } : null
            }).FirstOrDefaultAsync();

            if (itemVM != null)
                return itemVM;
            else
                throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Item"));
        }

        public async Task<ResponseMessage> DeleteItem(int itemId)
        {
            Item? item = await dbContext.Items.FirstOrDefaultAsync(col => col.ItemId == itemId);
            if (item != null)
            {
                dbContext.Items.Remove(item);
                await SaveChangesAsync();
                return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, "item"));
            }
            else
                throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Item"));
        }

        public async Task<IEnumerable<ItemVM>> GetMinStockItems()
        {
            return await dbContext.Items.Where(col => col.IsActive == 1 && (col.OpeningStock + col.ClosingStock) < col.MinimumStock).Select(row => new ItemVM()
            {
                ItemCode = row.ItemCode,
                ItemName = row.ItemName,
                Mrp = row.Mrp,
                SalesPrice = row.SalesPrice,
                ClosingStock = row.ClosingStock + row.OpeningStock,
                Measure = row.Measure
            }).ToListAsync();
        }

        public async Task<IEnumerable<ItemVM>> GetItemsForOffline(bool isAllItems, string? lastUpdatedTime)
        {
            if (isAllItems || lastUpdatedTime.IsNullOrEmpty())
            {
                return await dbContext.Items.Where(col => col.IsActive == 1).Select(row => new ItemVM()
                {
                    ItemId = row.ItemId,
                    ItemCode = row.ItemCode,
                    ItemName = row.ItemName,
                    AliasName = row.AliasName,
                    Mrp = row.Mrp,
                    SalesPrice = row.SalesPrice,
                    PurchasePrice = row.PurchasePrice,
                    Measure = row.Measure,
                    UpdatedDate = row.UpdatedDate.ToString("yyyy-MM-dd HH:mm:ss")
                }).ToListAsync();
            }
            else
            {
                DateTime updatedDate = DateTime.Parse(lastUpdatedTime!);

                var result = await dbContext.Items.Where(col => col.IsActive == 1 && col.UpdatedDate > updatedDate).Select(row => new ItemVM()
                {
                    ItemId = row.ItemId,
                    ItemCode = row.ItemCode,
                    ItemName = row.ItemName,
                    AliasName = row.AliasName,
                    Mrp = row.Mrp,
                    SalesPrice = row.SalesPrice,
                    PurchasePrice = row.PurchasePrice,
                    Measure = row.Measure,
                    UpdatedDate = row.UpdatedDate.ToString("yyyy-MM-dd HH:mm:ss")
                }).ToListAsync();

                return result;
            }

        }

        public async Task<IEnumerable<ItemVM>> SearchItems(string filter)
        {
            if (filter.Trim().IsNullOrEmpty())
                return await dbContext.Items.Where(col => col.IsActive == 1).Select(row => new ItemVM()
                {
                    ItemId = row.ItemId,
                    ItemCode = row.ItemCode,
                    ItemName = row.ItemName,
                    AliasName = row.AliasName,
                    Mrp = row.Mrp,
                    SalesPrice = row.SalesPrice,
                    PurchasePrice = row.PurchasePrice,
                    Measure = row.Measure,
                    ClosingStock = row.OpeningStock + row.ClosingStock
                }).OrderBy(ord => ord.ItemName).ToListAsync();
            else
                return await dbContext.Items.Where(col => col.IsActive == 1 && (col.ItemCode.StartsWith(filter, StringComparison.OrdinalIgnoreCase) || col.ItemName.StartsWith(filter, StringComparison.OrdinalIgnoreCase) || col.AliasName!.StartsWith(filter, StringComparison.OrdinalIgnoreCase))).Select(row => new ItemVM()
                {
                    ItemId = row.ItemId,
                    ItemCode = row.ItemCode,
                    ItemName = row.ItemName,
                    AliasName = row.AliasName,
                    Mrp = row.Mrp,
                    SalesPrice = row.SalesPrice,
                    PurchasePrice = row.PurchasePrice,
                    Measure = row.Measure,
                    ClosingStock = row.OpeningStock + row.ClosingStock
                }).OrderBy(ord => ord.ItemName).ToListAsync();
        }

        public async Task<IEnumerable<ItemVM>> GetItemsOnCode(string itemCode)
        {
            return await dbContext.Items.Where(col => col.IsActive == 1 && col.ItemCode == itemCode).Select(row => new ItemVM()
            {
                ItemId = row.ItemId,
                ItemCode = row.ItemCode,
                ItemName = row.ItemName,
                AliasName = row.AliasName,
                Mrp = row.Mrp,
                SalesPrice = row.SalesPrice,
                PurchasePrice = row.PurchasePrice,
                HSncode = row.Hsncode,
                Measure = row.Measure,
                OpeningStock = row.OpeningStock,
                ClosingStock = row.OpeningStock + row.ClosingStock,
                IsActive = row.IsActive == 1,
                CategoryModel = new CategoryVM() { CategoryId = row.CategoryId, CategoryName = row.Category.CategoryName },
                GstModel = row.Gst != null ? new GstVM()
                {
                    GstId = row.Gst.GstId,
                    SgstPer = row.Gst.SgstPer,
                    CgstPer = row.Gst.CgstPer,
                    IgstPer = row.Gst.IgstPer
                } : null
            }).ToListAsync();

        }

        public async Task<ResponseMessage> ResetStock()
        {
            double purchaseQty = 0.0, salesQty = 0.0;

            List<Item> list = await dbContext.Items.Where(col => col.IsActive == 1).ToListAsync();
            foreach (var item in list)
            {
                purchaseQty = await dbContext.PurchaseItems.Where(col => col.ItemId == item.ItemId).SumAsync(sm => sm.Quantity);
                salesQty = await dbContext.SalesItems.Where(col => col.ItemId == item.ItemId).SumAsync(sm => sm.Quantity);
                item.ClosingStock = purchaseQty - salesQty;
            }
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: "Stock balance was successfully reset.");
        }

        public async Task<ResponseMessage> UploadItems(List<ItemVM> items, int userRowId)
        {
            foreach (var itemVM in items)
            {
                Item item = MapItem(itemVM, new Item());
                item.CreatedDate = DateTime.Now;
                item.CreatedBy = userRowId;
                item.UpdatedDate = DateTime.Now;
                item.UpdatedBy = userRowId;
                await dbContext.Items.AddAsync(item);
            }
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: "Data was imported successfully.");
        }




        #endregion

        #region "Service Item"

        private static ServiceType MapServiceType(ServiceTypeVM itemVM, ServiceType item)
        {
            if (itemVM.GstModel != null)
                item.GstId = itemVM.GstModel.GstId;
            item.ServiceTypeName = itemVM.ServiceTypeName;
            item.ServiceCharge = itemVM.ServiceCharge;
            item.ServiceDescription = itemVM.ServiceDescription;
            item.IsActive = (sbyte)itemVM.IsActive.GetHashCode();
            return item;
        }

        public async Task<ResponseMessage> UpsertServiceType(ServiceTypeVM serviceTypeVM, int userRowId)
        {
            ServiceType? item;
            if (serviceTypeVM.ServiceTypeId == 0)
            {
                item = MapServiceType(serviceTypeVM, new ServiceType());
                item.CreatedDate = DateTime.Now;
                item.CreatedBy = userRowId;
                item.UpdatedDate = DateTime.Now;
                item.UpdatedBy = userRowId;
                await dbContext.ServiceTypes.AddAsync(item);
            }
            else
            {
                item = await dbContext.ServiceTypes.Where(col => col.ServiceTypeId == serviceTypeVM.ServiceTypeId).FirstOrDefaultAsync();
                if (item == null)
                    return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Service Type"));
                item = MapServiceType(serviceTypeVM, item);
                item.UpdatedDate = DateTime.Now;
                item.UpdatedBy = userRowId;
            }
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: $"{(serviceTypeVM.ServiceTypeId == 0 ? "Service type created successfully" : "serviceTypeVM updated successfully")}", data: item.ServiceTypeId.ToString());
        }

        public async Task<IEnumerable<ServiceTypeVM>> GetServiceTypes(bool isAll)
        {
            if (isAll)
                return await dbContext.ServiceTypes.Select(row => new ServiceTypeVM()
                {
                    ServiceTypeId = row.ServiceTypeId,
                    ServiceTypeName = row.ServiceTypeName,
                    ServiceDescription = row.ServiceDescription,
                    ServiceCharge = row.ServiceCharge,
                    SacCode = row.SacCode,
                    IsActive = row.IsActive == 1,
                    GstModel = row.Gst != null ? new GstVM()
                    {
                        GstId = row.Gst.GstId,
                        SgstPer = row.Gst.SgstPer,
                        CgstPer = row.Gst.CgstPer,
                        IgstPer = row.Gst.IgstPer
                    } : null
                }).OrderBy(ord => ord.ServiceTypeName).ToListAsync();
            else
                return await dbContext.ServiceTypes.Where(col => col.IsActive == 1).Select(row => new ServiceTypeVM()
                {
                    ServiceTypeId = row.ServiceTypeId,
                    ServiceTypeName = row.ServiceTypeName,
                    ServiceDescription = row.ServiceDescription,
                    ServiceCharge = row.ServiceCharge,
                    SacCode = row.SacCode,
                    IsActive = row.IsActive == 1,
                    GstModel = row.Gst != null ? new GstVM()
                    {
                        GstId = row.Gst.GstId,
                        SgstPer = row.Gst.SgstPer,
                        CgstPer = row.Gst.CgstPer,
                        IgstPer = row.Gst.IgstPer
                    } : null
                }).OrderBy(ord => ord.ServiceTypeName).ToListAsync();
        }

        public async Task<ResponseMessage> DeleteServiceType(int serviceTypeId)
        {
            ServiceType? item = await dbContext.ServiceTypes.FirstOrDefaultAsync(col => col.ServiceTypeId == serviceTypeId);
            if (item != null)
            {
                dbContext.ServiceTypes.Remove(item);
                await SaveChangesAsync();
                return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, "service type"));
            }
            else
                throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Service type"));
        }

        public async Task<ServiceTypeVM> GetServiceTypeDetails(int serviceTypeId)
        {
            ServiceTypeVM? itemVM = await dbContext.ServiceTypes.Where(col => col.ServiceTypeId == serviceTypeId).Select(row => new ServiceTypeVM()
            {
                ServiceTypeId = row.ServiceTypeId,
                ServiceTypeName = row.ServiceTypeName,
                ServiceDescription = row.ServiceDescription,
                ServiceCharge = row.ServiceCharge,
                SacCode = row.SacCode,
                IsActive = row.IsActive == 1,
                GstModel = row.Gst != null ? new GstVM()
                {
                    GstId = row.Gst.GstId,
                    SgstPer = row.Gst.SgstPer,
                    CgstPer = row.Gst.CgstPer,
                    IgstPer = row.Gst.IgstPer
                } : null
            }).FirstOrDefaultAsync();

            if (itemVM != null)
                return itemVM;
            else
                throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Item"));
        }

        #endregion
    }
}
