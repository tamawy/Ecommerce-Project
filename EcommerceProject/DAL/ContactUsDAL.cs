using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class ContactUsDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();

        public bool Add(ContactUs contactUs, out string message)
        {
            try
            {
                if (contactUs != null)
                {
                    db.ContactUs.Add(contactUs);
                    db.SaveChanges();
                    message = "Added successfully";
                    return true;
                }

                message = "Object is null";
                return false;  }
            
            catch(Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public bool Edit(ContactUs contactUs, out string message)
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
                ContactUs obj = db.ContactUs.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.ContactUs.Remove(obj);
                    db.SaveChanges();
                    message = "Deleted successfully";
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