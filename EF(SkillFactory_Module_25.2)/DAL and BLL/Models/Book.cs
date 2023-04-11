using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_SkillFactory_Module_25._2_.DAL_and_BLL.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Cost { get; set; }

        public int UserId { get; set; }
        public List<User> Users { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
