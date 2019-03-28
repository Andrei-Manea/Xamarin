using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DataAccessLayer.DTO;
using SQLite;

namespace DataAccessLayer
{
    public partial class Database
    {
        // Vom implementa principiul Singleton
        private static Database _dataBase;
        private static SQLiteAsyncConnection _connection;

        public static Database Instance
        {
            get
            {
                if (_dataBase == null)
                {
                    _dataBase = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"ShoppingItem.db3"));
                }

                return _dataBase;
            }
        }

        private Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath); // open database file or create database file if it doesn't exist

            // Aici ne putem instantia mereu tabelele de care avem nevoie conform obiectului oferit
            // Comanda este CREATE IF NOT EXIST
            _connection.CreateTableAsync<ShoppingItem>().Wait();
        }

        public Task<List<ShoppingItem>> GetItemsAsync()
        {
            return _connection.Table<ShoppingItem>().OrderBy(x => x.ID).ToListAsync();
        }

        public Task<ShoppingItem> GetItemAsync(uint id)
        {
            return _connection.Table<ShoppingItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateItemData(ShoppingItem item)
        {
            return _connection.InsertOrReplaceAsync(item);
        }

        public Task<int> DeleteItemAsync(ShoppingItem item)
        {
            return _connection.DeleteAsync(item);
        }
    }
}
