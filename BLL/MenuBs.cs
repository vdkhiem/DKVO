using BOL;
using DAL;
using Framework.Shared;
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
        private GenericRepository<AppMenu> objAppMenuDb;

        #region Constructor

        public MenuBs()
        {
            objDb = new MenuDb();
            objAppMenuDb = new GenericRepository<AppMenu>();
        }

        #endregion 

        #region Menu

        /// <summary>
        /// Get all Menus
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Menu> GetAll()
        {    
            try
            {
                return objDb.GetAll();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
            
        }

        public IEnumerable<Menu> GetByAppID(int appId)
        {
            try
            {
                return objDb.GetByAppID(appId);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
        }


        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Menu GetByID(int id)
        {
            try
            {
                return objDb.GetByID(id);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }            
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
            try
            {
                return objAppMenuDb.GetAll();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
        }

        /// <summary>
        /// Get AppMenu by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AppMenu GetAppMenuByID(int id)
        {
            try
            {
                return objAppMenuDb.GetByID(id);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
        }

        /// <summary>
        /// Insert a AppMenu
        /// </summary>
        /// <param name="item"></param>
        public void InsertAppMenu(AppMenu item)
        {
            try
            {
                objAppMenuDb.Insert(item);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
            
        }

        /// <summary>
        /// Delete a AppMenu
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAppMenu(int id)
        {
            try
            {
                objAppMenuDb.Delete(id);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
            
        }

        /// <summary>
        /// Update a AppMenu
        /// </summary>
        /// <param name="User"></param>
        public void UpdateAppMenu(AppMenu item)
        {
            try
            {
                objAppMenuDb.Update(item);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
        }

        #endregion

    }
}
