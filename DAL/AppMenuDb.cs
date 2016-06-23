using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppMenuDb
    {
        private LinkHubDbEntities db;
        public AppMenuDb()
        {
            db = new LinkHubDbEntities();
            //db.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Get all categorys
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppMenu> GetAll()
        {
            return db.AppMenus.ToList();
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AppMenu GetByID(int id)
        {
            return db.AppMenus.Find(id);
        }

        /// <summary>
        /// Insert a category
        /// </summary>
        /// <param name="item"></param>
        public void Insert(AppMenu item)
        {
            db.AppMenus.Add(item);
            Save();
        }     

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            AppMenu category = db.AppMenus.Find(id);
            db.AppMenus.Remove(category);
            Save();
        }

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="item"></param>
        public void Update(AppMenu item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Save a category
        /// </summary>
        private void Save()
        {
            db.SaveChanges();
        }
    }
}

