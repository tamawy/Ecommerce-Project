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
        EcommerceProjectEntities db = new EcommerceProjectEntities();

        public bool Add(UserAddress userAddress, out string message) {
            try 
            {
                if (userAddress != null)
                {
                    db.UserAddress.Add(userAddress);
                    db.SaveChanges();
                    message = "Added Successfully";
                    return true;
                }
                message = "Object is null";
                return false;
            }
            catch(Exception e)
            {
                message = e.Message;
                return true;
            }
        }
        //create function to delete object from DataBase selected By Id.
        public bool Delete(long id, out string message)
        {
            try
            {
                UserAddress obj = db.UserAddress.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.UserAddress.Remove(obj);
                    db.SaveChanges();
                    message = "Edited Successfully";
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


        public long GetUserAddressFK(long id)
        {
            return GetAll().
                Where(z => z.UserFK == id).Select(z => z.ID).LastOrDefault();
        }

        public UserAddress LastAddress(long id)
        {
            return GetAll().Where(z => z.UserFK == id).LastOrDefault();
        }
    }
}