using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class UserAddressDAL
    {
        //create object from DataBase.
        EcommerceProjectEntities2 db = new EcommerceProjectEntities2();

        //create function to delete object from DataBase selected By Id.
        public bool Delete(long id)
        {
            try
            {
                UserAddress obj = db.UserAddress.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.UserAddress.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }
        //create function to get details of object selected by id from DataBase.
        public UserAddress GetDetails(long id)
        {
            return db.UserAddress.Where(z => z.ID == id).FirstOrDefault();
        }
        //create function to get list of all objects from database.
        public List<UserAddress> GetAll()
        {
            return db.UserAddress.ToList();
        }
    }
}