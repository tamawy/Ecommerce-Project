using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.DAL;
using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class OrderDAL
    {
        EcommerceProjectEntities db = new EcommerceProjectEntities();

        public bool Add(Order order, out string message)
        {
            try
            {
                if (order != null)
                {
                    db.Order.Add(order);
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


        public bool Delete(long id)
        {
            Order obj = db.Order.Where(z => z.ID == id).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    db.Order.Remove(obj);
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
        public Order GetOne(long id)
        {
            return db.Order.Where(z => z.ID == id).FirstOrDefault();

        }
        public List<Order> GetAll()
        {
            return db.Order.ToList();
        }

        public long GetOrderFK(long id) {
            return GetAll().
                    Where(z => z.UserFK == id).
                    Select(z => z.ID).LastOrDefault();
        }

        public long GetNextOrderNumber() {
            return GetAll().Count + 1;
        }
    }
}