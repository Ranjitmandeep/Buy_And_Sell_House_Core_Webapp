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
    public class DeleteModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public DeleteModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Holds the house model.
        [BindProperty]
        public House House { get; set; }

        //Gets the house details using a linq query
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            House = (from house in _context.House where house.Id == id select house).FirstOrDefault();

            if (House == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes a House.
        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            House = (from house in _context.House where house.Id == id select house).FirstOrDefault();

            if (House != null)
            {
                _context.House.Remove(House);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
