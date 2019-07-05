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
        DALClass dc = new DALClass();
       public bool AddDbData(CommonClass custom)
        {
            var k=
            dc.addData(custom);
            if (k) {
                return true;
            }
           
            else
            {
                return false;
            }
        }
        public bool verifyDbUser(CommonClass c)
        {
            var t = dc.verifyUser(c);
            if (t)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<CommonClass1> userDbDetails()
        {
            List<CommonClass1> tuser = dc.userDetails().ToList();
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
        public bool verifyDbEmail(string k)
        {
            var e = dc.verifyEmail(k);
            if (e)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<CommonClass1> Edit(int id)
        {
            return dc.Edit(id).ToList();
        }

        public bool editDbUser(CommonClass1 cu)
        {
           
            return dc.EditUser(cu);
        }


    }






}
