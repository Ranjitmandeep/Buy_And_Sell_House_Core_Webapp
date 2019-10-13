using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Buy_And_Sell_House_Core_Webapp.Business;
using Buy_And_Sell_House_Core_Webapp.Models;

namespace Buy_And_Sell_House_Core_Webapp.Pages.Shared.Buyers
{
    public class DetailsModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public DetailsModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Holds the buyer information.
        public Buyer Buyer { get; set; }

        // Gets the buyer details using a linq query.
        public  IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buyer = (from buyer in _context.Buyer where buyer.Id == id select buyer).FirstOrDefault(); 

            if (Buyer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
