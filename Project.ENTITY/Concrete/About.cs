﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITY.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
