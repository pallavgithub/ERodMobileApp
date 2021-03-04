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
        }

        public Task<List<SalesOrder>> GetSalesOrderAsync()
        {
            //Get all notes.
            return database.Table<SalesOrder>().ToListAsync();
        }

        public Task<SalesOrder> GetSalesOrderAsync(int id)
        {
            // Get a specific note.
            return database.Table<SalesOrder>()
                            .Where(i => i.Num == id.ToString())
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveSalesOrderAsync(SalesOrder so)
        {
            var existingSo = database.Table<SalesOrder>().Where(x => x.Num == so.Num).FirstOrDefaultAsync();

            if (existingSo != null)
            {
                // Update an existing note.
                return database.UpdateAsync(so);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(so);
            }
        }

        public Task<int> DeleteSalesOrderAsync(SalesOrder note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }

        public Task<int> SaveUserAsync(UserModel so)
        {
            var existuser = database.Table<UserModel>().Where(x => x.PhoneNumber == so.PhoneNumber ||  x.ActivationCode == so.ActivationCode).FirstOrDefaultAsync();
            if (existuser != null)
            {
                // Update an existing note.
                return database.UpdateAsync(so);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(so);
            }
        }

        public Task<UserModel> GetUserAsync()
        {
            // Get a specific note.
            return database.Table<UserModel>()
                            .FirstOrDefaultAsync();
        }
    }
}
