using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationApi.AuthService
{
    public class RoleGenerator
    {
        private List<string> admin = new List<string> { "mihaiboboc852@gmail.com","city.inventory.a@gmail.com" };
        private List<string> emplyee = new List<string> { "city.inventory.e@gmail.com"};

        public string AssignRole(string userId)
        {
            if (admin.Contains(userId))
            {
                return "Admin";
            }

            if (emplyee.Contains(userId))
            {
                return "Employee";
            }

            return "Visitor";
        }
    }
}
