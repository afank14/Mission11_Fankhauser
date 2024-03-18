namespace Mission11_Fankhauser.Models.ViewModels;

public class PaginationInfo
{
    // Create features for the PaginationInfo ViewModel
    // These will be used to help us determine the size and number of pages,
    // as well as keep track of the current page and total number of pages
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    
    public int CurrentPage { get; set; }
    
    // Do a bunch of stuff here so that it comes back as a valid integer for number of pages needed
    public int TotalNumPages => (int)(Math.Ceiling((decimal) TotalItems / ItemsPerPage));
}