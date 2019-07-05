using CustomModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BusinessLogic
    {
        // DALClass dc = new DALClass();
        WCFSERVICE.MyService ms = new WCFSERVICE.MyService();
        public bool AddData(CommonClass custom)
        {
            var k = ms.AddDbData(custom);
            // dc.addData(custom);
            if (k)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public bool verifyUser(CommonClass c)
        {
            var t = ms.verifyDbUser(c);
            if (t)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<CommonClass1> userDetails()
        {
            List<CommonClass1> tuser = ms.userDbDetails().ToList();
            List<CommonClass1> list = new List<CommonClass1>();
            foreach (var item in tuser)
            {
                CommonClass1 Details = new CommonClass1();
                // Details.UserId = item.UserId;
                Details.FName = item.FName;
                Details.LName = item.LName;
                Details.EMail = item.EMail;
                Details.Phone = item.Phone;
                Details.Gender = item.Gender;
                Details.DOB = item.DOB;
                //Details.Adderss = item.Adderss;
                Details.UserPersonalId = item.UserPersonalId;
                // Details.CreatedDate = item.CreatedDate;
                //Details.LastUpdatedDate = item.LastUpdatedDate;
                list.Add(Details);
            }
            return list;
        }
        public bool verifyEmail(string k)
        {
            var e = ms.verifyDbEmail(k);
            if (e)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<CommonClass1> edit(int id)
        {
            return ms.Edit(id).ToList();
        }

        public bool editUser(CommonClass1 cu)
        {

            return ms.editDbUser(cu);
        }


    }


}
