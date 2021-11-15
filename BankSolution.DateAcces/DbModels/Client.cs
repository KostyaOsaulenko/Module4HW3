using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSolution.DateAccess.DbModels
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal OrderPrice { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
