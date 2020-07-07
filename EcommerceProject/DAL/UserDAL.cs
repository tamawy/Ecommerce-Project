using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class UserDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();

        public bool Add(User user, out string message)
        {
            try
            {

                if (user != null)
                {
                    if (getByEmail(user.Email) != null)
                    {
                        message = "Email exists";
                        return false;
                    }
                    db.User.Add(user);
                    db.SaveChanges();
                    message = "Added successfuly";
                    return true;
                }
                message = "User empty";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message ;
                return false;
            }
        }
        public bool Edit(User user, out string message)
        {
            try
            {
                // check if the object equals null
                if (user == null)
                {
                    message = "User empty";
                    return false;
                }
                // check if the object's ID exits
                var obj = GetOne(user.ID);
                if (obj == null)
                {
                    message = "No User Found";
                    return false;
                }

                
                    // check if the object's Email is not used
                    if (getByEmail(user.Email, user.ID) != null)
                    {
                        message = "Email is used";
                        return false;
                    }
                

                obj.Name = user.Name;
                obj.Password = user.Password;
                obj.Email = user.Email;
                obj.Address = user.Address;
                obj.Phone = user.Phone;
                obj.UpdatedBy = user.UpdatedBy;
                obj.UpdatedDate = user.UpdatedDate;
                obj.IsActive = user.IsActive;
                db.SaveChanges();
                message = "Edited Successfuly";
                return true;
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
                User obj = db.User.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.User.Remove(obj);
                    db.SaveChanges();
                    message = "Deleted Successfuly";
                    return true;
                }
                message = "User not found";
                return false;
            }
            catch (Exception e) 
            {
                message = e.Message;
                return false;
            }
        }
        public User getByEmail(string email)
        {
            return db.User.Where(z => z.Email == email).FirstOrDefault();
        }
        public User getByEmail(string email, long id)
        {
            return db.User.Where(z => z.Email == email && z.ID != id).FirstOrDefault();
        }
        public bool Login(ref User user, out string message)
        {
                var obj = getByEmail(user.Email);
                if (obj == null)
                {
                    message = "Wrong Email";
                return false;
                }
                else if (!obj.IsActive)
                {
                    message = "Account not active";
                    return false;
                }
                else
                {
                    if (user.Password != obj.Password)
                    {
                        message = "Wrong Password";
                    return false;
                    }
                    else
                    {
                        message = "Logined Sucessfully";
                        user = obj;
                        return true;
                    }
                }
        }

        public User GetOne(long id)
        {
            return db.User.Where(z => z.ID == id).FirstOrDefault();
        }
    }
}