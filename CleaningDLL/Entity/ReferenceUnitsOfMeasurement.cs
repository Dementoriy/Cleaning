using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class ReferenceUnitsOfMeasurement //Справочник единиц измерения
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(30)] public string Unit { get; set; }
        [Required]
        [MaxLength(150)] public string Description { get; set; }

    }
}
