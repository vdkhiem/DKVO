using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MenuDb : GenericRepository<Menu>
    {
        public IEnumerable<Menu> GetByAppID(int appId)
        {
            return context.Menus.Where(x => x.AppID == appId).ToList();
        }

        
    }
}

