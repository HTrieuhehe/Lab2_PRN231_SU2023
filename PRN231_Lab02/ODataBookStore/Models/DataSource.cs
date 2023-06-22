using ODataBookStore.Models;
using System.Collections.Generic;

namespace ODataBookStore.Data
{
    public static class DataSource
    {
        private static IList<Book> listBooks { get; set; }
        public static IList<Book> GetBooks()
        {
            if(listBooks != null)
            {
                return listBooks;
            }

            listBooks = new List<Book>();
            Book book = new Book()
            {
                Id = 1,
                ISBN = "978-654-61524-1",
                Title= "Essential C# 6.0",
                Author = "Quan ML",
                Price = 59.99m,
                Location = new Address()
                {
                    City = "HCM City",
                    Street = "Khong co"
                },
                Press = new Press() 
                {
                    Id = 1,
                    Name = "Quan ML",
                    Category = Category.Book,
                }
            };

            listBooks.Add(book);
            book = new Book()
            {
                Id = 2,
                ISBN = "346-159-45618-1",
                Title = "Essential C# 6.0",
                Author = "Tai ML",
                Price = 59.99m,
                Location = new Address()
                {
                    City = "HCM City",
                    Street = "Khong co"
                },
                Press = new Press()
                {
                    Id = 1,
                    Name = "Tai ML",
                    Category = Category.Book,
                }
            };

            listBooks.Add(book);
            return listBooks;
        }
    }
}
