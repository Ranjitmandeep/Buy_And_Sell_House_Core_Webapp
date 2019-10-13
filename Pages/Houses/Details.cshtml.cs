using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Buy_And_Sell_House_Core_Webapp.Business;
using Buy_And_Sell_House_Core_Webapp.Models;

namespace Buy_And_Sell_House_Core_Webapp.Pages.Shared.Houses
{
    public class DetailsModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public DetailsModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Holds the house model.
        public House House { get; set; }

        //Gets the details using a lamda query.
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            House =  _context.House.Include(h=>h.Seller).FirstOrDefault(m => m.Id == id);

            if (House == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
