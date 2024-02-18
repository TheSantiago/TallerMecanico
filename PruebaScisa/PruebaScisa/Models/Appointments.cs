using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaScisa.Models
{
    public class Appointments
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int VehicleId { get; set; }
        public string Comments { get; set; }
        public bool Approved { get; set; }
        public int CreatedById { get; set; }

    }
}