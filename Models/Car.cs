using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Text;

namespace Assignment_10._3.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set;  }
        public double Price { get; set; }
    }
}
