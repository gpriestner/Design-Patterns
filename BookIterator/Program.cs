// Step 1: Define an Iterator Interface
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Step 2: Define a Collection Interface
public interface ICollection<T>
{
    IIterator<T> CreateIterator();
}

// Step 3: Implement a Book class
public class Book
{
    public string Title { get; }

    public Book(string title)
    {
        Title = title;
    }
}

// Step 4: Implement the BookCollection class
public class BookCollection : ICollection<Book>
{
    private List<Book> _books = new List<Book>();

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public IIterator<Book> CreateIterator()
    {
        return new BookIterator(this);
    }

    public int Count => _books.Count;

    public Book At(int index) => _books[index];

    // Step 5: Implement the Iterator
    private class BookIterator : IIterator<Book>
    {
        private readonly BookCollection _collection;
        private int _currentIndex = 0;

        public BookIterator(BookCollection collection)
        {
            _collection = collection;
        }

        public bool HasNext()
        {
            return _currentIndex < _collection.Count;
        }

        public Book Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more books in the collection.");
            }
            return _collection.At(_currentIndex++);
        }
    }
}

// Step 6: Example Usage
public class Program
{
    public static void Main(string[] args)
    {
        var bookCollection = new BookCollection();
        bookCollection.AddBook(new Book("1984"));
        bookCollection.AddBook(new Book("Brave New World"));
        bookCollection.AddBook(new Book("Fahrenheit 451"));

        IIterator<Book> iterator = bookCollection.CreateIterator();

        while (iterator.HasNext())
        {
            Book book = iterator.Next();
            Console.WriteLine(book.Title);
        }
    }
}
