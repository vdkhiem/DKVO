using Framework.Shared;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class AdminBs : BaseBs
    {
        public void ApproveOrReject(List<int> ids, string status)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in ids)
                    {
                        var myUrl = urlBs.GetByID(item);
                        myUrl.IsApproved = status;
                        urlBs.Update(myUrl);
                    }

                    trans.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

        }

        /// <summary>
        /// Register (create) a user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool RegisterUser(string userName, string password)
        {
            try
            {
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);

                var user = new IdentityUser() { UserName = userName };
                IdentityResult result = manager.Create(user, password);

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.FirstOrDefault());
                }
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
                     
        }

        public ClaimsIdentity SignIn(string userName, string password)
        {
            try
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = userManager.Find(userName, password);
                ClaimsIdentity userIdentity = null;

                if (user != null)
                {
                    userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                }

                return userIdentity;
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }


        }
    }
}
