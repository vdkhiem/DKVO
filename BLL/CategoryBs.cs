using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBs
    {        
        private CategoryDb objDb;
        public CategoryBs()
        {
            objDb = new CategoryDb();
        }

        /// <summary>
        /// Get all Categorys
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tbl_Category> GetAll()
        {
            return objDb.GetAll();
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_Category GetByID(int id)
        {
            return objDb.GetByID(id);
        }

        /// <summary>
        /// Insert a Category
        /// </summary>
        /// <param name="Category"></param>
        public void Insert(tbl_Category category)
        {
            objDb.Insert(category);
        }     

        /// <summary>
        /// Delete a Category
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        /// <summary>
        /// Update a Category
        /// </summary>
        /// <param name="Category"></param>
        public void Update(tbl_Category category)
        {
            objDb.Update(category);
        }
    }
}
