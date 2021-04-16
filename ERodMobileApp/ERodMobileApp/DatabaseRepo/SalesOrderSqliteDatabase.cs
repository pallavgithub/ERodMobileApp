using ERodMobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERodMobileApp.DatabaseRepo
{
    public class SalesOrderSqliteDatabase
    {
        readonly SQLiteAsyncConnection database;

        public SalesOrderSqliteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<SalesOrder>().Wait();
            database.CreateTableAsync<UserModel>().Wait();
            database.CreateTableAsync<SalesOrderItemModel>().Wait();
            database.CreateTableAsync<CustomDataField>().Wait();
            database.CreateTableAsync<UserSignature>().Wait();
            database.CreateTableAsync<ProductModel>().Wait();
        }

        public async Task<List<SalesOrder>> GetSalesOrderAsync()
        {
            //Get all notes.
            var AllSo = await database.Table<SalesOrder>().ToListAsync();
            for (int i = 0; i < AllSo.Count; i++)
            {
                var Oid = AllSo[i].Num;
                var customfields = await database.Table<CustomDataField>().Where(x => x.RecordId == Oid).ToListAsync();
                var Soitems = await database.Table<SalesOrderItemModel>().Where(x => x.SoId == Oid).ToListAsync();
                if (customfields != null && customfields.Count > 0)
                {
                    AllSo[i].CustomFields.AddRange(customfields);
                }
                if (Soitems != null && Soitems.Count > 0)
                {
                    AllSo[i].SOItems.AddRange(Soitems);
                }
            }
            return AllSo;
        }
        public async Task<SalesOrder> GetSalesOrderByIdAsync(string salesOrderId)
        {
            var So = await database.Table<SalesOrder>().Where(x => x.Num == salesOrderId).FirstOrDefaultAsync();

            var customfields = await database.Table<CustomDataField>().Where(x => x.RecordId == So.Num).ToListAsync();
            var Soitems = await database.Table<SalesOrderItemModel>().Where(x => x.SoId == So.Num).ToListAsync();
            So.CustomFields.AddRange(customfields);
            So.SOItems.AddRange(Soitems);
            return So;
        }

        public async Task<int> SaveSalesOrderAsync(SalesOrder so)
        {
            var existingSo = await database.Table<SalesOrder>().Where(x => x.Num == so.Num).FirstOrDefaultAsync();

            if (existingSo != null)
            {
                // Update an existing note.
                await SaveCustomFieldsAsync(so.CustomFields);
                await SaveSoItemsAsync(so.SOItems);
                return await database.UpdateAsync(so);
            }
            else
            {
                // Save a new note.
                await SaveCustomFieldsAsync(so.CustomFields);
                await SaveSoItemsAsync(so.SOItems);
                return await database.InsertAsync(so);
            }

        }

        public async Task<int> SaveCustomFieldsAsync(List<CustomDataField> cdfs)
        {
            var rowUpdated = 0;
            foreach (var cdf in cdfs)
            {

                var existingSo = await database.Table<CustomDataField>().Where(x => x.RecordId == cdf.RecordId && x.Name == cdf.Name && x.Info == cdf.Info).FirstOrDefaultAsync();

                if (existingSo != null)
                {

                    // Update an existing note.
                    rowUpdated += await database.UpdateAsync(cdf);
                }
                else
                {
                    // Save a new note.
                    rowUpdated += await database.InsertAsync(cdf);
                }
            }
            return rowUpdated;
        }

        public Task<int> DeleteSalesOrderAsync(SalesOrder note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }

        public async Task<int> SaveUserAsync(UserModel so)
        {
            var existuser = await database.Table<UserModel>().Where(x => x.PhoneNumber == so.PhoneNumber || x.ActivationCode == so.ActivationCode).FirstOrDefaultAsync();
            if (existuser != null)
            {
                // Update an existing note.
                return await database.UpdateAsync(so);
            }
            else
            {
                // Save a new note.
                return await database.InsertAsync(so);
            }
        }

        public Task<UserModel> GetUserAsync()
        {
            // Get a specific note.
            return database.Table<UserModel>().FirstOrDefaultAsync();
        }

        public async Task<int> SaveSoItemsAsync(List<SalesOrderItemModel> soItems)
        {
            var rowUpdated = 0;
            foreach (var si in soItems)
            {

                var existingSo = await database.Table<SalesOrderItemModel>().Where(x => x.Id == si.Id).FirstOrDefaultAsync();

                if (existingSo != null)
                {


                    rowUpdated += await database.UpdateAsync(si);
                }
                else
                {

                    rowUpdated += await database.InsertAsync(si);
                }
            }
            return rowUpdated;
        }

        public async Task<List<SalesOrder>> GetSoitemsAsync(List<SalesOrder> So)
        {

            foreach (var order in So)
            {
                var soItems = await database.Table<SalesOrderItemModel>().Where(x => x.SoId == order.Num).FirstOrDefaultAsync();
                order.SOItems.Add(soItems);
            }
            return So;
        }
        public async Task<UserSignature> SaveSignatureAsync(UserSignature sign)
        {

            var existingsign = await database.Table<UserSignature>().Where(x => x.SalesOrderID == sign.SalesOrderID).FirstOrDefaultAsync();

            if (existingsign != null)
            {
                await database.UpdateAsync(sign);
            }
            else
            {
                await database.InsertAsync(sign);
            }
            return sign;
        }
        public async Task<UserSignature> GetSignatureAsync(string OrderId)
        {
            return await database.Table<UserSignature>().Where(x => x.SalesOrderID == OrderId).FirstOrDefaultAsync();
        }
        public async Task<int> SaveProductAsync(ProductModel product)
        {
            var existingProduct = await database.Table<ProductModel>().Where(x => x.Part == product.Part).FirstOrDefaultAsync();

            if (existingProduct != null)
            {
                // Update an existing note.              
                return await database.UpdateAsync(product);
            }
            else
            {
                // Save a new note.
                return await database.InsertAsync(product);
            }
        }
        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            //Get all notes.
            var AllProducts = await database.Table<ProductModel>().ToListAsync();
            return AllProducts;
        }
        public async Task<List<SalesOrder>> SaveAndCompareSalesOrderAsync(List<SalesOrder> soList)
        {
            var localSOList = await GetSalesOrderAsync();
            var records = new List<SalesOrder>();
            if (localSOList.Count != 0)
            {
                foreach (var item in soList)
                {
                    var localSOStatus = localSOList.Where(i => i.Num == item.Num).FirstOrDefault().StatusId;
                    if (localSOStatus != item.StatusId)
                        records.Add(item);
                    await SaveSalesOrderAsync(item);
                }
            }
            else
            {
                foreach (var item in soList)
                {
                    await SaveSalesOrderAsync(item);
                }
            }
            return records;
        }
    }
}
