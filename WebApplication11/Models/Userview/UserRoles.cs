using System.Collections.Generic;

namespace WebApplication11.Models.Userview
{
    public class UserRoles
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<Roleview> Roles { get; set; }
    }
}
