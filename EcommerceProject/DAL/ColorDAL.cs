using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class ColorDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();
        public bool Add(Color color, out string message)
        {
            try
            {
                if (color != null)
                {
                    db.Color.Add(color);
                    db.SaveChanges();
                    message = "Color Added Successfully";
                    return true;
                }
                message = "Object is null";
                return false;
            }
            catch(Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public bool Edit(Color color, out string message)
        {
            try
            {
                Color obj = db.Color.Where(z => z.ID == color.ID).FirstOrDefault();
                if (obj!= null)
                {
                    obj.Name = color.Name;
                    obj.Code = color.Code;
                    obj.CreatedBy = color.CreatedBy;
                    obj.CreationDate = color.CreationDate;
                    obj.UpdatedBy = color.UpdatedBy;
                    obj.UpdatedDate = DateTime.Now;
                    db.SaveChanges();
                    message = "Color Edited Successfully";
                    return true;
                }
                message = "Object is null";
                return false;
            }
            catch(Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public bool Delete(long id, out string message)
        {
            try
            {
                Color obj = db.Color.Where(z => z.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    db.Color.Remove(obj);
                    db.SaveChanges();
                    message = "Color Deleted Successfully";
                    return true;
                }
                message = "Object is null";
                return false;
            }
            catch(Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public Color Getone(long id)
        {
            return db.Color.Where(z => z.ID == id).FirstOrDefault();
        }
        public List<Color> GetAll()
        {
            return db.Color.ToList();
        }
    }
}