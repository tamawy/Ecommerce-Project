using EcommerceProject.Models;

namespace EcommerceProject.DAL
{
    public class Authorization
    {
        public bool Admin(User currentUser)
        {

            if (currentUser == null || currentUser.RoleFK != (long)Common.CommonEnum.Role.Admin)
            {
                return false;
            }
            return true;
        }
    }
}