using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace IBlood002.Models
{
    public class Center
    {
        public int Id { get; set; }
        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        [StringLength(2000)]
        public string Address { get; set; }
        
        [StringLength(255)]
        public string Website { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
    // /centers/random



}