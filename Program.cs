using System;
using System.Collections.Generic;

//By Mostafa Kahani
//https://github.com/Mostafakahani
class Book
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; }

    public Book(int id, string title, string author, int year, string isbn)
    {
        ID = id;
        Title = title;
        Author = author;
        Year = year;
        ISBN = isbn;
        IsAvailable = true;
    }

    public void BorrowBook()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine($"OK: {Title} book Borrowed.");
        }
        else
        {
            Console.WriteLine($"Error: Sorry! {Title} not Available.");
        }
    }

    public void ReturnBook()
    {
        IsAvailable = true;
        Console.WriteLine($"OK: {Title} book Returned.");
    }
}

class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"OK: {book.Title} book Added to Library.");
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
        Console.WriteLine($"OK: {book.Title} Deleted from Library.");
    }

    public void DisplayBooks()
    {
        Console.WriteLine("Books List in Library:");
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.ID}، Titel: {book.Title}، Author: {book.Author}، Export Year: {book.Year}، ISBN-Licence: {book.ISBN}، Status: {(book.IsAvailable ? "Available" : "Borrowed!")}");
        }
    }

    internal Book GetBookById(int id)
    {
        throw new NotImplementedException();
    }
}

class User
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public User(int id, string firstName, string lastName, string username, string password)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
    }

    public void RequestBook(Book book)
    {
        Console.WriteLine($"{FirstName} {LastName} Borrow Book Request Successfully: Book Titel is {book.Title}.");
        book.BorrowBook();
    }

    public void ReturnBook(Book book)
    {
        Console.WriteLine($"{FirstName} {LastName} Return Successfully: Book Titel is {book.Title}.");
        book.ReturnBook();
    }

    public void DisplayUserInfo()
    {
        Console.WriteLine($"ID: {ID}، Name: {FirstName}، LastName: {LastName}، Username: {Username}");
    }
}

class LibraryManagementSystem
{
    private Library library;
    private List<User> users;

    public LibraryManagementSystem()
    {
        library = new Library();
        users = new List<User>();
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n*************");
            Console.WriteLine("Menu");
            Console.WriteLine("*************");
            Console.WriteLine("1. Add Book To Library");
            Console.WriteLine("2. Remove Book From Library");
            Console.WriteLine("3. Display Library Books");
            Console.WriteLine("4. Register User");
            Console.WriteLine("5. Borrow Book");
            Console.WriteLine("6. Return Book");
            Console.WriteLine("7. Display UserInfo");
            Console.WriteLine("0. Exit");

            Console.Write("\nPlease Select Option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBookToLibrary();
                    break;
                case "2":
                    RemoveBookFromLibrary();
                    break;
                case "3":
                    DisplayLibraryBooks();
                    break;
                case "4":
                    RegisterUser();
                    break;
                case "5":
                    BorrowBook();
                    break;
                case "6":
                    ReturnBook();
                    break;
                case "7":
                    DisplayUserInfo();
                    break;
                case "0":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Wrong! try agane!");
                    break;
            }
        }
    }

    private void AddBookToLibrary()
    {
        Console.WriteLine("\n***************");
        Console.WriteLine("Add Book To Library");
        Console.WriteLine("***************");

        Console.Write("Book ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Book Titel: ");
        string title = Console.ReadLine();

        Console.Write("Author Book: ");
        string author = Console.ReadLine();

        Console.Write("Export Year: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("ISBN Licence: ");
        string isbn = Console.ReadLine();

        Book book = new Book(id, title, author, year, isbn);
        library.AddBook(book);
    }

    private void RemoveBookFromLibrary()
    {
        Console.WriteLine("\n***************");
        Console.WriteLine("Remove Book From Library");
        Console.WriteLine("***************");

        Console.Write("Book ID: ");
        int id = int.Parse(Console.ReadLine());

        Book bookToRemove = library.GetBookById(id);
        if (bookToRemove != null)
        {
            library.RemoveBook(bookToRemove);
        }
        else
        {
            Console.WriteLine("Error: Not Found Book ID.");
        }
    }

    private void DisplayLibraryBooks()
    {
        Console.WriteLine("\n***************");
        Console.WriteLine("Display Library Books");
        Console.WriteLine("***************");
        library.DisplayBooks();
    }

    private void RegisterUser()
    {
        Console.WriteLine("\n***************");
        Console.WriteLine("Register User");
        Console.WriteLine("***************");

        Console.Write("User ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("User Name: ");
        string firstName = Console.ReadLine();

        Console.Write("User Lastname: ");
        string lastName = Console.ReadLine();

        Console.Write("username: ");
        string username = Console.ReadLine();

        Console.Write("password: ");
        string password = Console.ReadLine();

        User user = new User(id, firstName, lastName, username, password);
        users.Add(user);

        Console.WriteLine("Successfully add User in Library.");
    }

    private void BorrowBook()
    {
        Console.WriteLine("\n***************");
        Console.WriteLine("Request Borrow Book");
        Console.WriteLine("***************");

        Console.Write("Book ID: ");
        int bookId = int.Parse(Console.ReadLine());

        Book bookToBorrow = library.GetBookById(bookId);
        if (bookToBorrow != null)
        {
            Console.Write("User ID: ");
            int userId = int.Parse(Console.ReadLine());

            User user = users.Find(u => u.ID == userId);
            if (user != null)
            {
                user.RequestBook(bookToBorrow);
            }
            else
            {
                Console.WriteLine("Error: This user is Not Found.");
            }
        }
        else
        {
            Console.WriteLine("Error: This book is Not Found.");
        }
    }

    private void ReturnBook()
    {
        Console.WriteLine("\n***************");
        Console.WriteLine("Return Book");
        Console.WriteLine("***************");

        Console.Write("Book ID: ");
        int bookId = int.Parse(Console.ReadLine());

        Book bookToReturn = library.GetBookById(bookId);
        if (bookToReturn != null)
        {
            Console.Write("User ID: "); //شناسه کاربر
            int userId = int.Parse(Console.ReadLine());

            User user = users.Find(u => u.ID == userId);
            if (user != null)
            {
                user.ReturnBook(bookToReturn);
            }
            else
            {
                Console.WriteLine("Not found user id or user name");//کاربری با شناسه وارد شده یافت نشد
            }
        }
        else
        {
            Console.WriteLine("not Found Book with this id or Username");//کتابی با شناسه وارد شده یافت نشد.
        }
    }

    private void DisplayUserInfo()
    {
        Console.WriteLine("\n***************");
        Console.WriteLine("User Info");//نمایش اطلاعات کاربر
        Console.WriteLine("***************");

        Console.Write("User ID: ");
        int userId = int.Parse(Console.ReadLine());

        User user = users.Find(u => u.ID == userId);
        if (user != null)
        {
            user.DisplayUserInfo();
        }
        else
        {
            Console.WriteLine("Not Found user with this username or ID!"); //کاربری با شناسه وارد شده یافت نشد
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LibraryManagementSystem libraryManagementSystem = new LibraryManagementSystem();
        libraryManagementSystem.Run();
    }
}