using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITY.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Date { get; set; }

        public string? SelectedServices { get; set; }

        public bool Status { get; set; }

    }
}
