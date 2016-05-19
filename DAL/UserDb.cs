using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDb
    {
        private LinkHubDbEntities db;
        public UserDb()
        {
            db = new LinkHubDbEntities();
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_User GetByID(int id)
        {
            return db.tbl_User.Find(id);
        }

        /// <summary>
        /// Insert a user
        /// </summary>
        /// <param name="user"></param>
        public void Insert(tbl_User user)
        {
            db.tbl_User.Add(user);
            Save();
        }     

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            tbl_User user = db.tbl_User.Find(id);
            db.tbl_User.Remove(user);
            Save();
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user"></param>
        public void Update(tbl_User user)
        {
            db.Entry(user).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Save a user
        /// </summary>
        private void Save()
        {
            db.SaveChanges();
        }
    }
}
