using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Delivery //Поставка
    {
        public int ID { get; set; }
        public Provider Provider { get; set; }
        [Required]
        public DateTime Delivery_Date { get; set; }
        [Required]
        public decimal Delivery_Cost { get; set; }
        public Delivery_Content Delivery_Content { get; set; }

    }
}
