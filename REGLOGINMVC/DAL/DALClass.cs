using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
   public class DALClass
    {
        mvcEntities db = new mvcEntities();
        public bool addData(CommonClass custom)
        {
            t_Users tu = new t_Users();
            tu.EMail = custom.EMail;
            tu.Password = custom.Password;
            tu.IsActive = true;
            tu.CreatedDate = DateTime.Now;
            db.t_Users.Add(tu);
            db.SaveChanges();
            int? id = (from s in db.t_Users
                      orderby s.UserId descending
                      select s.UserId).Take(1).SingleOrDefault();

            t_User_PersonalDetails tp = new t_User_PersonalDetails();
            tp.Address = custom.Address;
            tp.DOB = custom.DOB;
            tp.FName = custom.FName;
            tp.LName = custom.LName;
            tp.Phone = custom.Phone;
            tp.UserId = (int) id;
            tp.CreatedDate = DateTime.Now;
            db.t_User_PersonalDetails.Add(tp);
            db.SaveChanges();
            return true;
        }
        public bool verifyUser(CommonClass c)
        {
            var isValid = db.t_Users.Where(x => x.EMail.Equals(c.EMail) && x.Password.Equals(c.Password)).FirstOrDefault();
            if (isValid != null)
            {
                return true;
            }
            else
                return false;
        }
        public IEnumerable<CommonClass1> userDetails()
        {
            List<CommonClass1> lt = new List<CommonClass1>();
            var joindata = (from t1 in db.t_User_PersonalDetails
                           join t2 in db.t_Users on t1.UserId equals t2.UserId
                           select new
                           {
                               UserPersonalId = t1.UserPersonalId__UserPersonalId__UserPersonalId,
                               FName = t1.FName,
                               LName = t1.LName,
                               Gender = t1.Gender,
                               Phone = t1.Phone,
                               DOB = t1.DOB,
                               EMail = t2.EMail,
                           }
            ).ToList();
           
            
            foreach (var k in joindata)
            {
                CommonClass1 c = new CommonClass1();
                c.UserPersonalId = k.UserPersonalId;
                c.FName = k.FName;
                c.EMail = k.EMail;
                c.Phone = k.Phone;
                c.LName = k.LName;
                c.Gender = k.Gender;
               // c.Password = k.Password;
                c.DOB = k.DOB;
                //c.Age = age;
               //  c.Address = k.Address;
                lt.Add(c);
            }

            return lt.ToList();
        }
        public bool verifyEmail(string email)
        {
            var e = db.t_Users.Where(k => k.EMail.Equals(email)).FirstOrDefault();
            if (e == null)
            {
                return false;
            }
            else
            return true;
        }
        public IEnumerable<CommonClass1> Edit(int id)
        {
            t_User_PersonalDetails t = db.t_User_PersonalDetails.Find(id);
            List<CommonClass1> Listr = new List<CommonClass1>();
            int uid = t.UserId;
            t_Users k = db.t_Users.Find(uid);
            int uid1 = k.UserId;

            var JoinResult = (from p in db.t_Users
                              join s in db.t_User_PersonalDetails
                              on p.UserId equals t.UserId
                              where p.UserId == uid1
                              select new
                              {
                                  UserPersonalId = t.UserPersonalId__UserPersonalId__UserPersonalId,
                                  FName = t.FName,
                                  LName = t.LName,
                                  Gender = t.Gender,
                                  Phone = t.Phone,
                                  DOB = t.DOB,
                                  EMail = p.EMail,
                              }
                              ).ToList();

            foreach (var item in JoinResult)
            {
                CommonClass1 c = new CommonClass1();
                c.UserPersonalId = item.UserPersonalId;
                c.EMail = item.EMail;
                c.Gender = item.Gender;
                c.FName = item.FName;
                c.LName = item.LName;
                c.Phone = item.Phone;
                c.DOB = item.DOB;
                Listr.Add(c);
            }
            return Listr;
            //db.t_User_PersonalDetails.ToList();
        }
        public bool EditUser(CommonClass1 c)
        {

            var eml = c.EMail.ToString();
            var UserId = db.t_Users
            .FirstOrDefault(u => u.EMail == eml).UserId;

            var CreatedDt = db.t_User_PersonalDetails
            .FirstOrDefault(u => u.UserPersonalId__UserPersonalId__UserPersonalId == c.UserPersonalId).CreatedDate;

            //t_User_PersonalDetails ts = new t_User_PersonalDetails();
            //ts.UserPersonalId__UserPersonalId__UserPersonalId = c.UserPersonalId;
            //ts.UserId = Convert.ToInt32(UserId);
            
            t_User_PersonalDetails ts = db.t_User_PersonalDetails.FirstOrDefault(s => s.UserPersonalId__UserPersonalId__UserPersonalId == UserId);
            ts.FName = c.FName;
            ts.LName = c.LName;
            ts.Phone = c.Phone;
            ts.Gender = c.Gender;
            ts.DOB = Convert.ToDateTime(c.DOB);
            ts.CreatedDate = CreatedDt;
            db.Entry(ts).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }

}
