using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITY.Concrete
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaID { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public string Url { get; set; }
    }
}
