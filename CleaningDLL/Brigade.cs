﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Brigade //Бригада
    {
        public int ID { get; set; }
        [Required]
        public string Smena_Number { get; set; }
    }
}
