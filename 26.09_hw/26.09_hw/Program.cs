namespace _26._09_hw
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"The book title cannot be empty or null. {title}");
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException($"The book author cannot be empty or null. {author}");
            }

            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} by {Author}";
        }
    }


    public class BookList
    {
        private Book[] books;
        private int count;
        private int capacity;

        public BookList(int _capacity)
        {
            this.capacity = _capacity;
            books = new Book[this.capacity];
            count = 0;
        }

        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Index out of range.");
                return books[index];
            }
        }

        public int Capacity => capacity;
        private void IncreaseCapacity()
        {
            capacity *= 2;
            Book[] newBooks = new Book[capacity];
            Array.Copy(books, newBooks, books.Length);
            books = newBooks;
        }

        public bool AddBook(Book book)
        {
            if (count >= capacity)
            {
                IncreaseCapacity();
            }

            books[count++] = book;
            return true;
        }

        public bool RemoveBook(string title)
        {
            for (int i = 0; i < count; i++)
            {
                if (books[i].Title.Equals(title))
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        books[j] = books[j + 1];
                    }
                    books[--count] = null;
                    return true;
                }
            }
            return false;
        }

        public bool Contains(string title)
        {
            for (int i = 0; i < count; i++)
            {
                if (books[i].Title.Equals(title))
                    return true;
            }
            return false;
        }

        public void ShowBooks()
        {
            if (count == 0)
            {
                Console.WriteLine("list is empty.");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(books[i]);
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            BookList myBookList = new BookList(5);

            myBookList.AddBook(new Book("1984", "George Orwell"));
            myBookList.AddBook(new Book("War and Peace", "Leo Tolstoy"));
            myBookList.AddBook(new Book("The Sound and the Fury", "William Faulkner"));

            Console.WriteLine("Books in the list:");
            myBookList.ShowBooks();


        }
    }
}
