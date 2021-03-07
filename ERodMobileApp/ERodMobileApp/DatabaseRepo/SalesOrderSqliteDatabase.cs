using ERodMobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
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
        }

        public async Task<List<SalesOrder>> GetSalesOrderAsync()
        {
            //Get all notes.
            var AllSo = await database.Table<SalesOrder>().ToListAsync();
            for(int i  = 0; i < AllSo.Count; i++)
            {
               var customfields = await database.Table<CustomDataField>().Where(x => x.RecordId  == AllSo[i].Num).ToListAsync();
               var Soitems = await database.Table<SalesOrderItemModel>().Where(x => x.SoId == AllSo[i].Num).ToListAsync();
               AllSo[i].CustomFields.AddRange(customfields);
               AllSo[i].SOItems.AddRange(Soitems);
            }
            return AllSo;
        }

        public Task<SalesOrder> GetSalesOrderAsync(int id)
        {
            // Get a specific note.
            return database.Table<SalesOrder>()
                            .Where(i => i.Num == id.ToString())
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveSalesOrderAsync(SalesOrder so)
        {
            var existingSo = await database.Table<SalesOrder>().Where(x => x.Num == so.Num).FirstOrDefaultAsync();

            if (existingSo != null)
            {
                // Update an existing note.
                await SaveCustomFieldsAsync(so.CustomFields);
                await SaveCustomFieldsAsync(so.CustomFields);
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
            return database.Table<UserModel>()
                            .FirstOrDefaultAsync();
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
    }
}
