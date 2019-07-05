using CUSTOMMODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DAL
{
    public class DBClass
    {
        mvc2Entities db = new mvc2Entities();
        public bool addData(modelreg mr)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<modelreg, dbo_t_Users>();
            });

            IMapper mapper = config.CreateMapper();
            //var source = new Source();
            var dest = mapper.Map<modelreg, dbo_t_Users>(mr);
            dest.IsActive = true;
            dest.CreatedDate = DateTime.Now;
            db.dbo_t_Users.Add(dest);
            db.SaveChanges();
            int? id = (from s in db.dbo_t_Users
                       orderby s.UserId descending
                       select s.UserId).Take(1).SingleOrDefault();
            var config1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<modelreg, dbo_t_User_PersonalDetails>();
            });

            IMapper mapper1 = config1.CreateMapper();

            var d = mapper1.Map<modelreg, dbo_t_User_PersonalDetails>(mr);
            d.UserId = (int)id;
            d.CreatedDate = DateTime.Now;
            db.dbo_t_User_PersonalDetails.Add(d);
            db.SaveChanges();
            return true;
        }
        public bool verifyEmail(string email)
        {
            var e = db.dbo_t_Users.Where(k => k.EMail.Equals(email)).FirstOrDefault();
            if (e == null)
            {
                return false;
            }
            else
                return true;
        }
        public bool verifyUser(modelreg mr)
        {
            var k = db.dbo_t_Users.Where(t => t.EMail.Equals(mr.EMail) && t.Password.Equals(mr.Password)).FirstOrDefault();
            if (k != null)
                return true;
            else
                return false;
        }
        public IEnumerable<modelreg> userDetails()
        {
            List<modelreg> lst = (from t1 in db.dbo_t_Users
                                  join t2 in db.dbo_t_User_PersonalDetails on t1.UserId equals t2.UserId
                                  select new modelreg
                                  {
                                      UserPersonalId =t2.UserPersonalId,
                                     
                                      FName = t2.FName,
                                      LName = t2.LName,
                                      Gender = t2.Gender,
                                      Phone = t2.Phone,
                                      DOB = t2.DOB,
                                      EMail = t1.EMail,
                                  }
            ).ToList();

            return lst.ToList();
        }

    }
}
