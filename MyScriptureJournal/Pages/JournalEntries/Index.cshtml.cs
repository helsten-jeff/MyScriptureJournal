using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.JournalEntries
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<JournalEntry> JournalEntry { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string DateSort { get; set; }
        public string BookSort { get; set; }
        public string TitleSort { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookSearch { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            var journalEntries = from m in _context.JournalEntry
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                journalEntries = journalEntries.Where(s => s.Title.ToLower().Contains(SearchString.ToLower()) || s.Notes.ToLower().Contains(SearchString.ToLower()));
            }

                DateSort = sortOrder == "Date" ? "date_desc" : "Date";
                BookSort = sortOrder == "Book" ? "book_desc" : "Book";
                TitleSort = sortOrder == "Title" ? "title_desc" : "Title";

                IQueryable<JournalEntry> studentsIQ = from s in _context.JournalEntry
                                                 select s;

                switch (sortOrder)
                {
                    case "Date":
                    journalEntries = journalEntries.OrderBy(s => s.EntryDate);
                        break;
                    case "date_desc":
                    journalEntries = journalEntries.OrderByDescending(s => s.EntryDate);
                        break;
                    case "Book":
                        journalEntries = journalEntries.OrderBy(s => s.Book);
                        break;
                    case "book_asc":
                        journalEntries = journalEntries.OrderByDescending(s => s.Book);
                        break;
                    case "Title":
                        journalEntries = journalEntries.OrderBy(s => s.Title);
                        break;
                    case "title_desc":
                        journalEntries = journalEntries.OrderByDescending(s => s.Title);
                        break;
                    default:
                        journalEntries = journalEntries.OrderBy(s => s.Title);
                        break;
                }

                JournalEntry = await journalEntries.ToListAsync();
        }
    }
}
