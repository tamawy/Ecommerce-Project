using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class ContactMessageDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(ContactMesaage contactMesaage, out string message)
        {
            try
            {
                if (contactMesaage != null)
                {
                    db.ContactMesaage.Add(contactMesaage);
                    db.SaveChanges();
                    message = "Added Successfully";
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
        //Edit
        public bool Edit(ContactMesaage contactmsg)
        {
            try
            {
                ContactMesaage obj = db.ContactMesaage.Where(z => z.ID == contactmsg.ID).FirstOrDefault();
                if (obj != null)
                {

                    obj.IsAnswer = contactmsg.IsAnswer;
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
        //Delete 
        public bool Delete(long id)
        {
            ContactMesaage obj = db.ContactMesaage.Where(z => z.ID == id).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    db.ContactMesaage.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Details for one item
        public ContactMesaage GetOne(long id)
        {
            return db.ContactMesaage.Where(z => z.ID == id).FirstOrDefault();
        }
        //Get All Data
        public List<ContactMesaage> GetAll()
        {
            return db.ContactMesaage.OrderBy(z => z.IsAnswer).ToList();
        }
    }
}