using Ejercicio1._4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1._4.Controllers
{
    public class dbController
    {
        readonly SQLiteAsyncConnection _connection;
        public dbController() { }
        public dbController(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Data>().Wait();

        }

        public Task<int> AddPeople(Data info)
        {
            if (info.id == 0)
            {
                return _connection.InsertAsync(info);
            }
            else
            {
                return _connection.UpdateAsync(info);
            }
        }

        public Task<List<Data>> GetListPople()
        {
            return _connection.Table<Data>().ToListAsync();
        }

        public Task<List<Data>> GetPersonForId(int id)
        {
            return _connection.Table<Data>().Where(p => p.id == id).ToListAsync();
        }

        public Task<int> delete(Data info)
        {
            return _connection.DeleteAsync(info);
        }
    }
}
