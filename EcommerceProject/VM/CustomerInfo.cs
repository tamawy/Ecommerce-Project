using System.Collections.Generic;
using EcommerceProject.Models;
namespace EcommerceProject.VM
{
    public class CustomerInfo
    {
        public List<OrderDetails>  orderDetails { get; set; }
        public User user { get; set; }
        public UserAddress userAddress{ get; set; }
        public Order order{ get; set; }


        public long GetTotalPrice()
        {
            long total = 0;
            foreach (var item in orderDetails)
            {
                total += item.TotalPrice;
            }

            return total;
        }
        
    }
}