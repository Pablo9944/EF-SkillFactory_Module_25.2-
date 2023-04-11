using EF_SkillFactory_Module_25._2_.DAL_and_BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_SkillFactory_Module_25._2_
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; } = 0;

        public List<Book> Books { get; set; } = new List<Book>();
 
    }
}
