using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Buy_And_Sell_House_Core_Webapp.Business;
using Buy_And_Sell_House_Core_Webapp.Models;

namespace Buy_And_Sell_House_Core_Webapp.Pages.Shared.Buyers
{
    //Creates a buyer.
    public class CreateModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public CreateModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Returns the buyer create form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Holds the buyer model
        [BindProperty]
        public Buyer Buyer { get; set; }

        //Adds a buyer to database.
        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Buyer.Add(Buyer);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}