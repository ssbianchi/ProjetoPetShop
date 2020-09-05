using PetShop.IamMicroserver.Admin.Configuration.Identity;
using System.Collections.Generic;

namespace PetShop.IamMicroserver.Admin.Configuration
{
    public class IdentityDataConfiguration
    {
       public List<Role> Roles { get; set; }
       public List<User> Users { get; set; }
    }
}






