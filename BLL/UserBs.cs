using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBs
    {
        private UserDb objDb;
        public UserBs()
        {
            objDb = new UserDb();
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tbl_User> GetAll()
        {
            return objDb.GetAll();
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_User GetByID(int id)
        {
            return objDb.GetByID(id);
        }

        /// <summary>
        /// Insert a User
        /// </summary>
        /// <param name="User"></param>
        public void Insert(tbl_User user)
        {
            objDb.Insert(user);
        }     

        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="User"></param>
        public void Update(tbl_User user)
        {
            objDb.Update(user);
        }
    }
}
