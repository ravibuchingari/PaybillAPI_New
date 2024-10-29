using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;
using System;
using System.Runtime.CompilerServices;
using static Google.Protobuf.Compiler.CodeGeneratorResponse.Types;

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

        private static Item PrepareItem(ItemVM itemVM, Item item)
        {
            item.CategoryId = itemVM.CategoryId;
            item.GstId = itemVM.GstId;
            item.ItemCode = itemVM.ItemCode;
            item.ItemName = itemVM.ItemName;
            item.AliasName = itemVM.AliasName;
            item.Mrp = itemVM.Mrp;
            item.SalesPrice = itemVM.SalesPrice;
            item.PurchasePrice = itemVM.PurchasePrice;
            item.HSncode = itemVM.HSncode;
            item.Measure = itemVM.Measure;
            item.OpeningStock = itemVM.OpeningStock;
            item.MinimumStock = itemVM.MinimumStock;
            item.IsActive = (sbyte)itemVM.IsActive.GetHashCode();
            return item;
        }
        private static ItemVM ApplyItem(Item row)
        {
            return new ItemVM()
            {
                ItemId = row.ItemId,
                CategoryId = row.CategoryId,
                GstId = row.GstId,
                ItemCode = row.ItemCode,
                ItemName = row.ItemName,
                AliasName = row.AliasName,
                Mrp = row.Mrp,
                SalesPrice = row.SalesPrice,
                PurchasePrice = row.PurchasePrice,
                HSncode = row.HSncode,
                Measure = row.Measure,
                OpeningStock = row.OpeningStock,
                ClosingStock = row.OpeningStock + row.ClosingStock,
                IsActive = row.IsActive == 1
            };
        }

        public async Task<ResponseMessage> UpsertItem(ItemVM itemVM, int userRowId)
        {
            if(itemVM.ItemId == 0)
            {
                Item item = PrepareItem(itemVM, new Item());
                item.CreatedDate = DateTime.Now;
                item.CreatedBy = userRowId;
                item.UpdatedDate = DateTime.Now;
                item.UpdatedBy = userRowId;
                await dbContext.Items.AddAsync(item);
            }
            else
            {
                Item? item = await dbContext.Items.Where(col => col.ItemId == itemVM.ItemId).FirstOrDefaultAsync();
                if(item == null)
                    return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Item"));
                item = PrepareItem(itemVM, item);
                item.UpdatedDate = DateTime.Now;
                item.UpdatedBy = userRowId;
            }
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: $"{(itemVM.ItemId == 0 ? "Item created successfully" : "Item updated successfully")}");
        }

        public async Task<IEnumerable<ItemVM>> GetItems(bool isActive)
        {
            if (isActive)
                return await dbContext.Items.Where(col => col.IsActive == 1).Select(row => ApplyItem(row)).ToListAsync();
            else
                return await dbContext.Items.Select(row => ApplyItem(row)).ToListAsync();
        }

        public async Task<ItemVM> GetItemDetails(int itemId)
        {
            Item? item = await dbContext.Items.FirstOrDefaultAsync(col => col.ItemId == itemId);
            if (item != null)
                return ApplyItem(item);
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

        #endregion
    }
}
