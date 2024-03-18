namespace Mission11_Fankhauser.Models;

// Create an interface called IBooksRepository
public interface IBooksRepository
{
    // It will have an IQueryable of type Book called Books
    public IQueryable<Book> Books { get; }
}