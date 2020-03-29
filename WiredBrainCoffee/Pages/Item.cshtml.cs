using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WiredBrainCoffee.Pages
{
    public class ItemModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet(int id)
        {
            Message = "The id is " + id;
        }
    }
}