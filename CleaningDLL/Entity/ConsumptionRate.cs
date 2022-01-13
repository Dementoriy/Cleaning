﻿using System.ComponentModel.DataAnnotations;

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
        public virtual ReferenceUnitsOfMeasurement ReferenceUnitsOfMeasurement { get; set; }
        public ConsumptionRate()
        {

        }
        public ConsumptionRate(string Consumption, Consumable Consumable, ReferenceUnitsOfMeasurement ReferenceUnitsOfMeasurement)
        {
            this.Consumption = Consumption;
            this.Consumable = Consumable;
            this.ReferenceUnitsOfMeasurement = ReferenceUnitsOfMeasurement;
        }
    }
}
