using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBooks.Models.Codes
{
    public class Codes
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ovo je obavezno polja !")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Ovo je obavezno polja !")]
        public string Title { get; set; }
        public string Company { get; set; }
        public int? Integer { get; set; }
        public string String { get; set; }
        public decimal? Decimal { get; set; }
        public int? Ordinal { get; set; }
        public Codes code { get; set; }
        public int? CodeId { get; set; }
        public Codebooks Codebook { get; set; }
        public int? CodebookId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
