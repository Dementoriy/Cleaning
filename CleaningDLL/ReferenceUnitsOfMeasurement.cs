using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class ReferenceUnitsOfMeasurement //Справочник единиц измерения
    {
        public int ID { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
