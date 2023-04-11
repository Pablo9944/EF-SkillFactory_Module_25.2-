using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_SkillFactory_Module_25._2_.DAL_and_BLL.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
