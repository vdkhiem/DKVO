using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBs
    {
        public CategoryBs categoryBs { get; set; }
        public UserBs userBs { get; set; }
        public UrlBs urlBs { get; set; }
        public MenuBs menuBs { get; set; }
        public BaseBs ()
        {
            categoryBs = new CategoryBs();
            userBs = new UserBs();
            urlBs = new UrlBs();
            menuBs = new MenuBs();
        }
    }
}
