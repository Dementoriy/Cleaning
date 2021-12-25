using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class BrigadeInventory //Инвентарь бригады
    {
        public int ID { get; set; }
        [Required]
        public virtual Brigade Brigade { get; set; }
        [Required]
        public virtual Inventory Inventory { get; set; }
    }
}
