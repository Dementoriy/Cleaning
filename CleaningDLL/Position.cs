using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Position //Должность
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)] public string NamePosition { get; set; }
        [Required]
        [MaxLength(150)] public string Description { get; set; }
    }
}
