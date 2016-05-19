using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UrlBs
    {
        private UrlDb objDb;
        public UrlBs()
        {
            objDb = new UrlDb();
        }

        /// <summary>
        /// Get all urls
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tbl_Url> GetAll()
        {
            return objDb.GetAll();
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_Url GetByID(int id)
        {
            return objDb.GetByID(id);
        }

        /// <summary>
        /// Insert a url
        /// </summary>
        /// <param name="url"></param>
        public void Insert(tbl_Url url)
        {
            objDb.Insert(url);
        }     

        /// <summary>
        /// Delete a url
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        /// <summary>
        /// Update a url
        /// </summary>
        /// <param name="url"></param>
        public void Update(tbl_Url url)
        {
            objDb.Update(url);
        }
    }
}
