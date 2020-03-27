using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBooks.Models
{
    public class Codebooks
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Programmer { get; set; }
        public bool Cash { get; set; }
        public int? CodebooksId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
