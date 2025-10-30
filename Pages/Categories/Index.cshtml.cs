using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ginjoveanu_Dragos_Lab2.Data;
using Ginjoveanu_Dragos_Lab2.Models;
using Ginjoveanu_Dragos_Lab2.Models.ViewModels;

namespace Ginjoveanu_Dragos_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Ginjoveanu_Dragos_Lab2.Data.Ginjoveanu_Dragos_Lab2Context _context;

        public IndexModel(Ginjoveanu_Dragos_Lab2.Data.Ginjoveanu_Dragos_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)       // Include(Category -> BookCategory)
                .ThenInclude(bc => bc.Book)       // ThenInclude(BookCategory -> Book)
                .ThenInclude(b => b.Author)   // ThenInclude(Book -> Author)
                .OrderBy(c => c.CategoryName)
                .AsNoTracking()
                .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
    
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
    
                // Corecția este aici:
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}
