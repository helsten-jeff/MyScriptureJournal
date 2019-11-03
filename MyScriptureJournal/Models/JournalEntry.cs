using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class JournalEntry
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Book { get; set; }
        [StringLength(60, MinimumLength = 1)]
        public string Chapters { get; set; }
        [StringLength(60, MinimumLength = 1)]
        public string Verses { get; set; }
        [StringLength(1000, MinimumLength = 1)]
        public string Notes { get; set; }
    }
}