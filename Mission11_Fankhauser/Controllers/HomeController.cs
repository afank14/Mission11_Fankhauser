using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission11_Fankhauser.Models;
using Mission11_Fankhauser.Models.ViewModels;

namespace Mission11_Fankhauser.Controllers;

public class HomeController : Controller
{
    // Create a private instance of IBooksRepository interface
    private IBooksRepository _repo;

    // in the control, instantiate the _repo
    public HomeController(IBooksRepository temp)
    {
        _repo = temp;
    }

    // Get action for Index page that receives parameter pageNum
    public IActionResult Index(int pageNum)
    {
        // Set pageSize = 10 so there are 10 books per page
        int pageSize = 10;

        // Create a variable called booksList that is an instance of the BooksListViewModel
        var booksList = new BooksListViewModel
        {
            // Set the Books feature in the model equal to the list of books
            Books = _repo.Books
                .OrderBy(x => x.Title)
                // Use skip so on page 2, it skips the first 10 and so forth
                .Skip((pageNum - 1) * pageSize)
                // Only take 10 books for each page
                .Take(pageSize),
            
            // Set the PaginationInfo feature of the model
            PaginationInfo = new PaginationInfo
            {
                // Assign the pageNum, pageSize, and total books appropriately
                CurrentPage = pageNum,
                ItemsPerPage = pageSize,
                TotalItems = _repo.Books.Count()
            }
        };
        
        // Return the view with the booksList
        return View(booksList);
    }
    
}