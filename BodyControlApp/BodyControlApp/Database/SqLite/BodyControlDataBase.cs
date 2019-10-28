using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Database.SqLite.Tables;
using SQLite;

namespace BodyControlApp.Database.SqLite
{
    class BodyControlDataBase
    {
        readonly SQLiteAsyncConnection database;

        public BodyControlDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<GenericFoods>().Wait();
        }

        public Task<List<GenericFoods>> GetItemsAsync()
        {
            return database.Table<GenericFoods>().ToListAsync();
        }
    }
}
