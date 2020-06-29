using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class BrandDAL
    {
        EcommerceProjectEntities2 db = new EcommerceProjectEntities2();
        public bool Add(Brand brand)
        {
            try
            {
                if (brand != null)
                {
                    db.Brand.Add(brand);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Edit(Brand brand)
        {
            try
            {
                Brand obj = db.Brand.Where(z => z.ID == brand.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = brand.Name;
                    obj.Image = brand.Image;
                    obj.CreatedBy = brand.CreatedBy;
                    obj.CreationDate = brand.CreationDate;
                    obj.UpdatedBy = brand.UpdatedBy;
                    obj.UpdatedDate = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
             catch(Exception e)
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                Brand obj = db.Brand.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.Brand.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public Brand Getone(long id)
        {
            return GetAll().Where(z => z.ID == id).FirstOrDefault();
        }

        public List<Brand> GetAll()
        {
            return db.Brand.ToList();
        }
    }
}