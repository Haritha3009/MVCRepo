using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using CUSTOMMODELS;
using AutoMapper;

namespace BAL
{
    public class BALClass
    {
        DBClass bl = new DBClass();
        public bool addDbData(modelreg mr)
        {
            var k = bl.addData(mr);
            if (k)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public bool verifyDbEmail(string e)
        {
            var t = bl.verifyEmail(e);
            if (t)
                return true;
            else
                return false;
        }
        public bool verifyDbUser(modelreg mr)
        {
            var k = bl.verifyUser(mr);
            if (k)
                return true;
            else
                return false;
        }
        public IEnumerable<modelreg> userDbDetails()
        {
            List<modelreg> tuser = bl.userDetails().ToList();
            List<modelreg> list = new List<modelreg>();
            foreach (var item in tuser)
            {

                modelreg Details = new modelreg();
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
                Details.LastUpdatedDate = item.LastUpdatedDate;
                list.Add(Details);
            }
            return list;
        }
    }

}


