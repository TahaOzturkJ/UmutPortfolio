using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITY.Concrete
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }

        public string? Name { get; set; }

        public string? ImageUrl { get; set; }

        public string? ProjectUrl { get; set; }

        public string? Price { get; set; }

        public bool Status { get; set; }

        public int? Condition { get; set; }

        public string? Description { get; set; }
    }
}
