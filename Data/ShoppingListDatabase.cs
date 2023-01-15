using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SarciniMuncitori.Models;

namespace SarciniMuncitori.Data
{
    public class ShoppingListDatabase
    {

        readonly SQLiteAsyncConnection _database;
        public ShoppingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SarcinaMuncitor>().Wait();
            _database.CreateTableAsync<Product>().Wait();
            _database.CreateTableAsync<ListaSarcina>().Wait();
        }

        public Task<int> SaveProductAsync(Product product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Product>> GetProductsAsync()

        {
            return _database.Table<Product>().ToListAsync();
        }
    
       public Task<List<SarcinaMuncitor>> GetSarcinaMuncitorsAsync()
        {
            return _database.Table<SarcinaMuncitor>().ToListAsync();
        }
        public Task<SarcinaMuncitor> GetSarcinaMuncitorAsync(int id)
        {
            return _database.Table<SarcinaMuncitor>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveSarcinaMuncitorAsync(SarcinaMuncitor slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);

            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteSarcinaMuncitorAsync(SarcinaMuncitor slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> DeleteListaSarcinaAsync(ListaSarcina listp)
        {
            return _database.DeleteAsync(listp);
        }

        public Task<List<ListaSarcina>> GetListaSarcinas()
        {
            return _database.QueryAsync<ListaSarcina>("select * from ListaSarcina");
        }


        public Task<int> SaveListaSarcinaAsync(ListaSarcina listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Product>> GetListaSarcinasAsync(int SarcinaMuncitorid)
        {
            return _database.QueryAsync<Product>(
            "select P.ID, P.Description from Product P"
            + " inner join ListaSarcina LP"
            + " on P.ID = LP.ProductID where LP.SarcinaMuncitorID = ?",
            SarcinaMuncitorid);
        }

    }

}
