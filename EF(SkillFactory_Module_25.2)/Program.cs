
using EF_SkillFactory_Module_25._2_;
using EF_SkillFactory_Module_25._2_.DAL_and_BLL.Models;
using EF_SkillFactory_Module_25._2_.DAL_and_BLL.Repositories;
using static System.Reflection.Metadata.BlobBuilder;
using AppContext = EF_SkillFactory_Module_25._2_.AppContext;


class Program
{
    static void Main(string[] args)
    {

        using (var db = new AppContext())
        {
            BookRepository book = new BookRepository(db);

            var book1 = new Book() { Title = "Book1", ReleaseYear = 2023 };
            var book2 = new Book() { Title = "Book2", ReleaseYear = 2022 };
            var book3 = new Book() { Title = "Book3", ReleaseYear = 2021 };
            var book4 = new Book() { Title = "Book4", ReleaseYear = 2020 };
            var book5 = new Book() { Title = "Book5", ReleaseYear = 2019 };

            var author1 = new Author() { Name = "Author1", Books = new List<Book>() { book1, book2 } };
            var author2 = new Author() { Name = "Author2", Books = new List<Book>() { book3, book4 } };
            var author3 = new Author() { Name = "Author3", Books = new List<Book>() { book5, book1 } };

            var genre1 = new Genre() { Title = "Genre1", Books = new List<Book>() { book1, book2 } };
            var genre2 = new Genre() { Title = "Genre2", Books = new List<Book>() { book2 } };
            var genre3 = new Genre() { Title = "Genre3", Books = new List<Book>() { book3 } };
            var genre4 = new Genre() { Title = "Genre4", Books = new List<Book>() { book4 } };
            var genre5 = new Genre() { Title = "Genre5", Books = new List<Book>() { book5 } };

            var user1 = new User() { Name = "User1", Email = "gmail@gmail.com", Books = new List<Book>() { book1, book2 }, Password = "NULL" };
            var user2 = new User() { Name = "User2", Email = "gmail2@gmail.com", Books = new List<Book> { book3, book4 }, Password = "NULL" };
            var user3 = new User() { Name = "User3", Email = "gmail3@gmail.com", Books = new List<Book> { book5 }, Password = "NULL" };

            db.Authors.AddRange(new[] { author1, author2, author3 });
            db.Books.AddRange(new[] { book1, book2, book3, book4, book5 });
            db.Genres.AddRange(new[] { genre1, genre2, genre3, genre4, genre5 });
            db.Users.AddRange(new[] { user1, user2, user3 });

            db.SaveChanges();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Выводим:");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;

            //1
            Console.WriteLine("Получать список книг определенного жанра и вышедших между определенными годами");
            var bookByYears = book.GetBooksByYears(2019, 2022);
            foreach (var b in bookByYears)
                Console.WriteLine(b.Title);
            Console.WriteLine();
            //2
            Console.WriteLine("Получать количество книг определенного автора в библиотеке.");
            var bookAuthors = book.GetNumberOfAuthorsBooks("Author3");
            Console.WriteLine(bookAuthors);
            Console.WriteLine();
            //3
            Console.WriteLine("Получать количество книг определенного жанра в библиотеке.");
            var bookGenres = book.GetNumberOfGenresBooks("Genre2");
            Console.WriteLine(bookGenres);
            Console.WriteLine();
            //4
            Console.WriteLine("Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.");
            var bookOfExists = book.IfExistsByAuthorAndTitle("Author1", "Book2");
            Console.WriteLine(bookOfExists);
            Console.WriteLine();
            //5
            Console.WriteLine("Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.");
            var bookFromUser = book.IfUserHas(3, "Book5");
            Console.WriteLine(bookFromUser);
            Console.WriteLine();

            //6
            Console.WriteLine("Получать количество книг на руках у пользователя.");
            var userCountBooks = book.GetNumberOfUsersBooks(1);
            Console.WriteLine(userCountBooks);
            Console.WriteLine();
            //7
            Console.WriteLine("Получение последней вышедшей книги.");
            var lastBook = book.GetLastReleasedBook();
            Console.WriteLine(lastBook.Title);
            Console.WriteLine();
            //8
            Console.WriteLine("Получение списка всех книг, отсортированного в алфавитном порядке по названию.");
            var orderBookFoTitle = book.GetAllBooksSortedByTitle();
            foreach (var b in orderBookFoTitle)
                Console.WriteLine(b.Title);
            Console.WriteLine();
            //9
            Console.WriteLine("Получение списка всех книг, отсортированного в порядке убывания года их выхода.");

            var sortBooks = book.GetAllBooksSortedByYear();
            foreach (var b in sortBooks)
                Console.WriteLine(b.Title);
        }

    }

}