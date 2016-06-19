using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MenuBs
    {
        private MenuDb objDb;
        private AppMenuDb objAppMenuDb;
        public MenuBs()
        {
            objDb = new MenuDb();
            objAppMenuDb = new AppMenuDb();
        }

        #region Menu
		
        /// <summary>
        /// Get all Menus
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Menu> GetAll()
        {
            return objDb.GetAll();
        }

        public IEnumerable<Menu> GetByAppID(int appId)
        {
            return objDb.GetByAppID(appId);
        }


        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Menu GetByID(int id)
        {
            return objDb.GetByID(id);
        }

        /// <summary>
        /// Insert a User
        /// </summary>
        /// <param name="User"></param>
        public void Insert(Menu user)
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
        public void Update(Menu user)
        {
            objDb.Update(user);
        }
 
	    #endregion

        #region AppMenu

        /// <summary>
        /// Get all AppMenus
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppMenu> GetAppMenuAll()
        {
            return objAppMenuDb.GetAll();
        }

        /// <summary>
        /// Get AppMenu by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AppMenu GetAppMenuByID(int id)
        {
            return objAppMenuDb.GetByID(id);
        }

        /// <summary>
        /// Insert a AppMenu
        /// </summary>
        /// <param name="item"></param>
        public void InsertAppMenu(AppMenu item)
        {
            objAppMenuDb.Insert(item);
        }

        /// <summary>
        /// Delete a AppMenu
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAppMenu(int id)
        {
            objAppMenuDb.Delete(id);
        }

        /// <summary>
        /// Update a AppMenu
        /// </summary>
        /// <param name="User"></param>
        public void UpdateAppMenu(AppMenu item)
        {
            objAppMenuDb.Update(item);
        }

        #endregion


    }
}
