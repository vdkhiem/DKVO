using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDb
    {
        private LinkHubDbEntities db;
        public CategoryDb()
        {
            db = new LinkHubDbEntities();
        }

        /// <summary>
        /// Get all categorys
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tbl_Category> GetAll()
        {
            return db.tbl_Category.ToList();
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_Category GetByID(int id)
        {
            return db.tbl_Category.Find(id);
        }

        /// <summary>
        /// Insert a category
        /// </summary>
        /// <param name="category"></param>
        public void Insert(tbl_Category category)
        {
            db.tbl_Category.Add(category);
            Save();
        }     

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            tbl_Category category = db.tbl_Category.Find(id);
            db.tbl_Category.Remove(category);
            Save();
        }

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="category"></param>
        public void Update(tbl_Category category)
        {
            db.Entry(category).State = EntityState.Modified;
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
