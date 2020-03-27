using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBooks.Models.Codes
{
    public class CodesViewModel
    {
        public List<Row> Rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Title { get; set; }
            public string Company { get; set; }
            public int? Ordinal { get; set; }
            public DateTime CreatedOn { get; set; }

        }
        public int? CodeId { get; set; }
        public int? CodebookId { get; set; }
        public string Superior { get; set; }
        public int? scid { get; set; }
        public int? scbid { get; set; }
    }
}
