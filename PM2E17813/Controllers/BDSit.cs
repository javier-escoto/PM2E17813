using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2E17813.Models;
using System.Threading.Tasks;

namespace PM2E17813.Controllers
{
    class BDSit
    {
        readonly SQLiteAsyncConnection _connection;
        public BDSit() { }

        public BDSit(string dbpath) 
        {
            _connection = new SQLiteAsyncConnection(dbpath);

            _connection.CreateTableAsync<Sitios>().Wait();
        }

        /* create crud bd*/

        //crete

        public Task<int> Addemple(Sitios sitios)
        {
            if (sitios.Id == 0)
            {
                return _connection.InsertAsync(sitios);
            }
            else
            {
                return _connection.UpdateAsync(sitios);
            }
        }

        public Task<List<Sitios>> GetAll()
        {
            return _connection.Table<Sitios>().ToListAsync();
        }

        public Task<Sitios> GetById(int id)
        {
            return _connection.Table<Sitios>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

        }

        // delete

        public Task<int> DeleteEmple(Sitios sitios)
        {
            return _connection.DeleteAsync(sitios);
        }




    }
}
