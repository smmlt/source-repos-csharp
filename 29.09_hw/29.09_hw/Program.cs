using _29._09_hw;

namespace _29._09_hw
{
    class Book
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    title = value;
                }
                else
                {
                    throw new ArgumentException("The book title cannot be empty.");
                }
            }
        }

        private string author;
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    author = value;
                }
                else
                {
                    throw new ArgumentException("The author's name cannot be empty.");
                }
            }
        }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public Book() : this("Unknown", "Unknown Author") { }

        public static bool operator ==(Book book1, Book book2)
        {
            return book1.Title == book2.Title && book1.Author == book2.Author;
        }
        public static bool operator !=(Book book1, Book book2)
        {
            return book1.Title != book2.Title || book1.Author != book2.Author;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Title} by {Author}";
        }
    }

    class BookList
    {
        public Book[] books;

        public BookList()
        {
            books = new Book[0];
        }

        public Book[] AddBook(Book book)
        {
            Book[] newBooks = new Book[books.Length + 1];

            for (int i = 0; i < books.Length; i++)
            {
                newBooks[i] = books[i];
            }

            newBooks[newBooks.Length - 1] = book;
            books = newBooks;
            return books;
        }

        public Book[] RemoveBook(Book book)
        {
            if (!Contains(book))
            {
                Console.WriteLine($"Book {book.Title} not found"); 
                return books;
            }

            Book[] newBooks = new Book[books.Length - 1];
            int j = 0;

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != book)
                {
                    newBooks[j] = books[i];
                    j++;
                }
            }

            books = newBooks;
            return books;
        }

        public bool Contains(Book book)
        {
            foreach (var bok in books)
            {
                if (bok == book)
                    return true;
            }
            return false;
        }

        public void PrintAllBooks()
        {
            if (books.Length == 0)
            {
                Console.WriteLine("List book is empty.");
                return;
            }

            Console.WriteLine("List book: ");
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }

}

internal class Program
{
    static void Main(string[] args)
    {
        BookList myBooks = new BookList();

        myBooks.AddBook(new Book("1984", "George Orwell"));
        myBooks.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));
        myBooks.AddBook(new Book("Brave New World", "Aldous Huxley"));

        myBooks.PrintAllBooks();

        BookList myBooks1 = new BookList();

        myBooks1.PrintAllBooks();
    }
}

