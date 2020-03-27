using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBooks.Models
{
    public class CodebooksViewModel
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [Display(Name = "Oznaka šifrarnika *")]
        [Required(ErrorMessage = "Ovo je obavezno polje !")]
        public string Code { get; set; }
        [Display(Name = "Naziv šifrarnika *")]
        [Required(ErrorMessage = "Ovo je obavezno polje !")]
        public string Title { get; set; }
        [Display(Name = "Opis šifrarnika *")]
        public string Description { get; set; }
        [Display(Name = "Programerski šifrarnik ?")]
        public bool Programmer { get; set; }
        [Display(Name = "Dozvoli keširanje ?")]
        public bool Cash { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Nadređeni šifrarnik")]
        public int? CodebookId { get; set; }
        public List<Codebooks> codebooks { get; set; }
        
    }
}
