using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaScisa.Models
{
    public class Clients
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }    

        public string LastName { get; set; }
    }
}