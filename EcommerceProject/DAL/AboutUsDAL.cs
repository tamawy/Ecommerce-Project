using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class AboutUsDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();

        public bool Add(AboutUs aboutUs, out string message)
        {
            try
            {
                if (aboutUs != null)
                {
                    db.AboutUs.Add(aboutUs);
                    db.SaveChanges();
                    message = "Added successfully";
                    return true;
                }
                message = "Object is null";
                return false;
            }

            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public bool Edit(AboutUs aboutUs, out string message)
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
                    message = "Edited successfully";
                    return true;
                }
                message = "Object is null";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public bool Delete(long id, out string message)
        {
            try
            {
                AboutUs obj = db.AboutUs.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.AboutUs.Remove(obj);
                    db.SaveChanges();
                    message = "Deleted Successfully";
                    return true;
                }
                message = "Object is null";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public AboutUs GetOne(long id)
        {
            return db.AboutUs.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<AboutUs> GetAll()
        {
            return db.AboutUs.ToList();
        }

    }
}