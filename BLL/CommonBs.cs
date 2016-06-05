using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class CommonBs : BaseBs
    {
        public void InsertQuickURL(QuickURLSubmitModel myQuickURL)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    tbl_User u = myQuickURL.MyUser;
                    u.Password = u.ConfirmPassword = "123456";
                    u.Role = "U";
                    userBs.Insert(u);

                    tbl_Url url = myQuickURL.MyUrl;
                    url.UserId = u.UserId;
                    url.UrlDesc = url.UrlTitle;
                    url.IsApproved = "P";
                    urlBs.Insert(url);
                }
                catch (Exception ex)
                {   
                    throw new Exception(ex.Message);
                }
                
            }
            
        }
    }
}
