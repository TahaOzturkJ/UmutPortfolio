using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITY.Concrete
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        public string Title { get; set; }

    }
}
