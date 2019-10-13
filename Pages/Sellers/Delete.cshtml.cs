using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Buy_And_Sell_House_Core_Webapp.Business;
using Buy_And_Sell_House_Core_Webapp.Models;

namespace Buy_And_Sell_House_Core_Webapp.Pages.Shared.Sellers
{
    public class DeleteModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public DeleteModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Holds seller model.
        [BindProperty]
        public Seller Seller { get; set; }

        //Gets seller information using  a lamda query.
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller =  _context.Seller
                .Include(s => s.House).FirstOrDefault(m => m.Id == id);

            if (Seller == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes a seller users a linq query to check existance.
        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller = (from seller in _context.Seller where seller.Id == id select seller).FirstOrDefault();

            if (Seller != null)
            {
                _context.Seller.Remove(Seller);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
