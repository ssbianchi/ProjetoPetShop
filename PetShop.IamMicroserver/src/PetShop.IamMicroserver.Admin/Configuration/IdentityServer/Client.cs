using System.Collections.Generic;
using PetShop.IamMicroserver.Admin.Configuration.Identity;

namespace PetShop.IamMicroserver.Admin.Configuration.IdentityServer
{
    public class Client : global::IdentityServer4.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}






