using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITY.Concrete
{
    public class Feature
    {
        [Key]
        public int FeatureID { get; set; }

        public string Header { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string GetInTouch { get; set; }

    }
}
