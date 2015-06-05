using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Models
{
   public class Member
    {
        public int id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string account { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return "Course: Id = " + id + ", Name = " + name + ".";
        }
    }
}
