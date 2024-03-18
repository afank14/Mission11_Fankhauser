namespace Mission11_Fankhauser.Models.ViewModels;

// The BookslistViewModel helps us pass more than one thing to the index page
public class BooksListViewModel
{
    // First, there will be an IQueryable of books
    public IQueryable<Book> Books { get; set; }
    // Second, there will be an instance of the PaginationInfo model for pagination purposes
    public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
}