using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class SubCategroyDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(SubCategory subcategory, out string message)
        {
            try
            {
                if (subcategory != null)
                {
                    if (GetByName(subcategory.Name) != null)
                    {
                        message = "SubCategory Exist";
                        return false;
                    }
                    db.SubCategory.Add(subcategory);
                    db.SaveChanges();
                    message = "Added Successfuly";

                    return true;
                }
                message = "SubCategory Empty";

                return false;
            }
            catch (Exception e)
            {
                message = e.Message;

                return false;
            }
        }
        public bool Edit(SubCategory subcategory, out string message)
        {
            try
            {
                SubCategory obj = db.SubCategory.Where(z => z.ID == subcategory.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = subcategory.Name;
                    obj.UpdatedBy = subcategory.UpdatedBy;
                    obj.UpdatedDate = subcategory.UpdatedDate;
                    db.SaveChanges();
                    message = "Edited Successfuly";
                    return true;
                }
                message = "SubCategory Empty";
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
            SubCategory obj = db.SubCategory.Where(z => z.ID == id).FirstOrDefault();

            try
            {

                if (obj != null)
                {
                    db.SubCategory.Remove(obj);
                    db.SaveChanges();
                    message = "Deleted Successfuly";
                    return true;

                }
                message = "SubCategory Empty";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public SubCategory GetOne(long id)
        {
            return db.SubCategory.Where(z => z.ID == id).FirstOrDefault();

        }
        public List<SubCategory> GetAll()
        {
            return db.SubCategory.OrderByDescending(z => z.ID).ToList();
        }
        public SubCategory GetByName(string name)
        {
            return db.SubCategory.Where(z => z.Name == name).FirstOrDefault();
        }


    }
}