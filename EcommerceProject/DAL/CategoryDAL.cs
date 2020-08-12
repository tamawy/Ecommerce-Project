using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class CategoryDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(Category category, out string message)
        {
            try
            {
                if (category != null)
                {
                    db.Category.Add(category);
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
        public bool Edit(Category category, out string message)
        {
            try
            {
                Category obj = db.Category.Where(z => z.ID == category.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = category.Name;
                    obj.UpdatedBy = category.UpdatedBy;
                    obj.UpdatedDate = category.UpdatedDate;
                    db.SaveChanges();
                    message = "Edited Successfully";
                    return true;
                }
                message = "The object passed is null";
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
            Category obj = db.Category.Where(z => z.ID == id).FirstOrDefault();

            try
            {

                if (obj != null)
                {
                    db.Category.Remove(obj);
                    db.SaveChanges();
                    message = "Deleted Successfully";
                    return true;

                }
                message = "The object is null";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public Category GetOne(long id)
        {
            return db.Category.Where(z => z.ID == id).FirstOrDefault();

        }
        public List<Category> GetAll()
        {
            return db.Category.ToList();
        }



    }
}