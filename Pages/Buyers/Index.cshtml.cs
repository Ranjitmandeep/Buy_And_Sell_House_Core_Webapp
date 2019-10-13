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
    public class IndexModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public IndexModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Holds the buyer information.
        public IList<Buyer> Buyer { get;set; }

        //Gets all the buyer using a linq query.
        public void OnGet()
        {
            Buyer = (from buyer in _context.Buyer select buyer).ToList();
        }
    }
}
