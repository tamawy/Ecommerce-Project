using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class ProductColorDAL
    {
        //creat an object from Entity Data Model to use database easly
        EcommerceProjectEntities db = new EcommerceProjectEntities();

        //Method that used to add in database in this table
        public bool Add(ProductColor productColor, out string message)
        {
            try
            {
                if (productColor != null)
                {
                    db.ProductColor.Add(productColor);
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
        //Method that used to edit in database in this table
        public bool Edit(ProductColor productColor, out string message)
        {
            try
            {
                ProductColor obj = db.ProductColor.Where(z => z.ID == productColor.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Image = productColor.Image;
                    obj.ProductFK = productColor.ProductFK;
                    obj.ColorFk = productColor.ColorFk;
                    obj.UpdatedBy = productColor.UpdatedBy;
                    obj.UpdatedDate = productColor.UpdatedDate;
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
        //Method that used to delete from database in this table
        public bool Delete(long id, out string message)
        {
            try
            {
                ProductColor obj = db.ProductColor.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.ProductColor.Remove(obj);
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
        //Method that used to show all data from database in this table
        public ProductColor GetOne(long id)
        {
            return db.ProductColor.Where(z => z.ID == id).FirstOrDefault();
        }
        //Method that used to return all data from database in this table
        public List<ProductColor> GetAll()
        {
            return db.ProductColor.ToList();
        }


    }
}