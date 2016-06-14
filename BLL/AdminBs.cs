using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
