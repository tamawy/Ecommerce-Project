using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class ContactUsDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();

        public bool Add(ContactUs contactUs)
        {
            try
            {
                if (contactUs != null)
                {
                    db.ContactUs.Add(contactUs);
                    db.SaveChanges();
                    return true;
                }

                return false;  }
            
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Edit(ContactUs contactUs)
        {
            try
            {
                ContactUs obj = db.ContactUs.Where(z => z.ID == contactUs.ID).FirstOrDefault();
                if(obj != null)
                {
                    obj.Email = contactUs.Email;
                    obj.facebook = contactUs.facebook;
                    obj.phone = contactUs.phone;
                    obj.address = contactUs.address;
                    obj.UpdatedBy = contactUs.UpdatedBy;
                    obj.UpdatedDate = contactUs.UpdatedDate;
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
                ContactUs obj = db.ContactUs.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.ContactUs.Remove(obj);
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
        public ContactUs Detail(long id)
        {
            return db.ContactUs.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<ContactUs> GetAll()
        {
            return db.ContactUs.ToList();
        }
        public ContactUs GetOne(long id)
        {
            return db.ContactUs.Where(z => z.ID == id).FirstOrDefault();
        }

    }
}