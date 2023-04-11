using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_SkillFactory_Module_25._2_.DAL_and_BLL.Repositories
{
    public class UserRepository
    {
        AppContext db;

        public UserRepository()
        {
            db = new AppContext();
        }

        public User GetByUserid(int id)
        {
            return db.Users.FirstOrDefault(u=>u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public void DeleteUser(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void UpdateById(string newName,int id)
        {
            db.Users.FirstOrDefault(u => u.Id == id).Name = newName;
        }
    }
 }
