﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class ConsumptionRate //Норма расхода
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(150)] public string Consumption { get; set; }
        [Required]
        public virtual Consumable Consumable { get; set; }
        [Required]
        public virtual ReferenceUnitsOfMeasurement Unit { get; set; }

    }
}