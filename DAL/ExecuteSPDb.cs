using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExecuteSPDb<T>
    {
        private LinkHubDbEntities db;
        public ExecuteSPDb()
        {
            db = new LinkHubDbEntities();
        }

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return db.T.ToList();
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_Url GetByID(int id)
        {
            return db.tbl_Url.Find(id);
        }

        /// <summary>
        /// Insert a item
        /// </summary>
        /// <param name="url"></param>
        public void Insert(tbl_Url url)
        {
            db.tbl_Url.Add(url);
            Save();
        }

        /// <summary>
        /// Delete a item
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            tbl_Url url = db.tbl_Url.Find(id);
            db.tbl_Url.Remove(url);
            Save();
        }

        /// <summary>
        /// Update a item
        /// </summary>
        /// <param name="url"></param>
        public void Update(tbl_Url url)
        {
            db.Entry(url).State = EntityState.Modified;
            //Set this property to pybass url unique validation
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        /// <summary>
        /// Save a url
        /// </summary>
        private void Save()
        {
            db.SaveChanges();
        }
    }
}

