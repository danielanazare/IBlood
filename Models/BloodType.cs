using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IBlood002.Models
{
    public class BloodType
    {
        [Required]
        public byte Id { get; set; }
        public string BloodTypeName { get; set; }
        public bool Rh { get; set; }

    }
}