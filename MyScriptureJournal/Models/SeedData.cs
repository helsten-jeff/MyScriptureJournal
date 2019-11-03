using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.JournalEntry.Any())
                {
                    return;   // DB has been seeded
                }

                context.JournalEntry.AddRange(
                    new JournalEntry
                    {
                        Title = "Faith",
                        EntryDate = DateTime.Parse("2019-2-12"),
                        Book = "Alma",
                        Chapters = "13",
                        Verses = "7",
                        Notes = "This is a great book"
                    },

                    new JournalEntry
                    {
                        Title = "Hope",
                        EntryDate = DateTime.Parse("2019-3-13"),
                        Book = "1 Nephi",
                        Chapters = "13",
                        Verses = "7",
                        Notes = "This is a great book"
                    },

                    new JournalEntry
                    {
                        Title = "Charity",
                        EntryDate = DateTime.Parse("2019-2-23"),
                        Book = "2 Nephi",
                        Chapters = "13",
                        Verses = "7",
                        Notes = "This is a great book"
                    },

                    new JournalEntry
                    {
                        Title = "Love",
                        EntryDate = DateTime.Parse("2019-4-15"),
                        Book = "Moroni",
                        Chapters = "13",
                        Verses = "7",
                        Notes = "This is a great book"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}