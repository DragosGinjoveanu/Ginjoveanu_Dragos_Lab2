using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ginjoveanu_Dragos_Lab2.Data;
using Ginjoveanu_Dragos_Lab2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ginjoveanu_Dragos_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Ginjoveanu_Dragos_Lab2.Data.Ginjoveanu_Dragos_Lab2Context _context;

        public CreateModel(Ginjoveanu_Dragos_Lab2.Data.Ginjoveanu_Dragos_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
                "PublisherName");
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "ID",
                "FirstName");
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
 {
 var newBook = new Book();
 if (selectedCategories != null)
 {
 newBook.BookCategories = new List<BookCategory>();
 foreach (var cat in selectedCategories)
 {
 var catToAdd = new BookCategory
 {
 CategoryID = int.Parse(cat)
 };
newBook.BookCategories.Add(catToAdd);
 }
 }
 Book.BookCategories = newBook.BookCategories;
 _context.Book.Add(Book);
 await _context.SaveChangesAsync();
 return RedirectToPage("./Index");
 }
    }
}
