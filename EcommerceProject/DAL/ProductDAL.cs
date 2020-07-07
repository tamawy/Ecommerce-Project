using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class ProductDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(Product product, out string message)
        {
            try
            {
                if(product != null)
                {
                    db.Product.Add(product);
                    db.SaveChanges();
                    message = "Added Successfuly";
                    return true;
                }
                message = "Product Empty";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
                
            }
        }

        public bool Edit(Product product, out string message)
        {
            try
            {
                Product obj = db.Product.Where(z => z.ID == product.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = product.Name;
                    obj.Price= product.Price;
                    obj.Image = product.Image;
                    obj.BrandFK = product.BrandFK;
                    obj.Decription = product.Decription;
                    obj.CreationDate = product.CreationDate;
                    obj.UpdatedBy = product.UpdatedBy;
                    obj.UpdatedDate = DateTime.Now;
                    obj.CatFK = product.CatFK;
                    obj.SubCatFK = product.SubCatFK;
                    db.SaveChanges();
                    message = "Added successfully";
                    return true;
                }
                message = "product empty";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                Product obj = db.Product.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.Product.Remove(obj);
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

        public Product GetOne(long id)
        {
            return db.Product.Where(z => z.ID == id).FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            return db.Product.OrderByDescending(z => z.ID).ToList();
        }
    }
}