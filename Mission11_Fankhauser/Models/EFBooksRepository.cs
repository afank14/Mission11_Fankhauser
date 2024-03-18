using SQLitePCL;

namespace Mission11_Fankhauser.Models;

// The EFBooksRepository will inherit from the interface
public class EFBooksRepository : IBooksRepository
{
    // Make a private instance of the Bookstore context
    private BookstoreContext _context;
    
    // Use the constructor to populate the _context
    public EFBooksRepository(BookstoreContext temp)
    {
        _context = temp;
    }
    
    // Bring in the Books table from the database
    public IQueryable<Book> Books => _context.Books;
}