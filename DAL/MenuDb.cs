using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MenuDb
    {
        private LinkHubDbEntities db;
        public MenuDb()
        {
            db = new LinkHubDbEntities();
        }

        /// <summary>
        /// Get all categorys
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Menu> GetAll()
        {
            return db.Menus.ToList();
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Menu GetByID(int id)
        {
            return db.Menus.Find(id);
        }

        public IEnumerable<Menu> GetByAppID(int appId)
        {
            return db.Menus.Where(x => x.AppID == appId).ToList();
        }

        /// <summary>
        /// Insert a category
        /// </summary>
        /// <param name="item"></param>
        public void Insert(Menu item)
        {
            db.Menus.Add(item);
            Save();
        }

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Menu category = db.Menus.Find(id);
            db.Menus.Remove(category);
            Save();
        }

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="item"></param>
        public void Update(Menu item)
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

