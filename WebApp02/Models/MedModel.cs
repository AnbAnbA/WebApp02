using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp02.Models
{
    public class MedModel
    {
        public int ID { get; set; }
        public string NameMed { get; set; }
        public string Manufacturers { get; set; }
        public string Manufacturer_country { get; set; }
        public double PriceMed { get; set; }
        public string Image { get; set; }


        public MedModel(Medicine medicine)
        {
            ID = medicine.IDMed;
            NameMed = medicine.NameMed;
            Manufacturers = medicine.Manufacturers;
            Manufacturer_country = medicine.Manufacturer_country;
            PriceMed = medicine.PriceMed;
            Image = medicine.Image;
        }

    }
}