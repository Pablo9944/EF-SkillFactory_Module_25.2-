using EF_SkillFactory_Module_25._2_.DAL_and_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_SkillFactory_Module_25._2_.DAL_and_BLL.Repositories
{
    public class BookRepository
    {
        AppContext db;

        public BookRepository(AppContext db)
        {
            this.db = db;
        }
        // 1)
        public List<Book> GetBooksByGenre(string genreTitle)
        {
            return db.Genres.FirstOrDefault(g => g.Title == genreTitle).Books;
        }

        public List<Book> GetBooksByYears(int y1, int y2)
        {
            return db.Books.Where(b => b.ReleaseYear >= y1 && b.ReleaseYear <= y2).ToList();
        }

        // 2)
        public int GetNumberOfAuthorsBooks(string authorName)
        {
            return db.Authors.FirstOrDefault(a => a.Name == authorName).Books.Count;
        }

        // 3)
        public int GetNumberOfGenresBooks(string genreTitle)
        {
            return db.Genres.FirstOrDefault(g => g.Title == genreTitle).Books.Count;
        }

        // 4)
        public bool IfExistsByAuthorAndTitle(string authorName, string title)
        {
            return db.Books.Any(b => b.Author.Name == authorName && b.Title == title);
        }

        // 5)
        public bool IfUserHas(int id, string title)
        {
            return db.Users.FirstOrDefault(u=>u.Id == id).Books.Any(u => u.Title == title);
        }

        // 6)
        public int GetNumberOfUsersBooks(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id).Books.Count;
        }

        // 7)
        public Book GetLastReleasedBook()
        {
            return db.Books.OrderByDescending(b => b.ReleaseYear).FirstOrDefault();
        }

        // 8)
        public List<Book> GetAllBooksSortedByTitle()
        {
            return db.Books.OrderBy(b => b.Title).ToList();
        }

        // 9)
        public List<Book> GetAllBooksSortedByYear()
        {
            return db.Books.OrderByDescending(b => b.ReleaseYear).ToList();
        }
    }
}
