using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IBlood002.Models;

namespace IBlood002.Dtos
{
    public class DonorDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }


        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(13)]
        public string CNP { get; set; }


        [StringLength(10)]
        public string Phone { get; set; }

        [Display(Name = "Date of Birth")]
       // [Min18Years]
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public char Sex { get; set; }

       
        public bool IsSubscribedToNewsletter { get; set; }



        //entity-framework treats this property as a foreign key
        [Required]
        
        public byte BloodTypeId { get; set; }
        public BloodTypeDto BloodType { get; set; }

    }
}