using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class AboutAsDAL
    {
        EcommerceProjectEntities2 db = new EcommerceProjectEntities2();

        public bool Add(AboutUs aboutUs)
        {
            try
            {
                if (aboutUs != null)
                {
                    db.AboutUs.Add(aboutUs);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

            catch (Exception e)
            {
                return false;
            }
        }
        public bool Edit(AboutUs aboutUs)
        {
            try
            {
                AboutUs obj = db.AboutUs.Where(z => z.ID == aboutUs.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Vision = aboutUs.Vision;
                    obj.Mission = aboutUs.Mission;
                    obj.WhoAreWe = aboutUs.WhoAreWe;     
                    obj.UpdatedBy = aboutUs.UpdatedBy;
                    obj.UpdatedDate = aboutUs.UpdatedDate;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                AboutUs obj = db.AboutUs.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.AboutUs.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public AboutUs Detail(long id)
        {
            return db.AboutUs.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<AboutUs> GetAll()
        {
            return db.AboutUs.ToList();
        }

    }
}