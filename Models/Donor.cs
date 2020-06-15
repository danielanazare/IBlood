using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IBlood002.Models
{
    public class Donor
    {
        public int Id { get; set; }
       
        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
       
        [StringLength(255)]
        public string Email { get; set; }
        
        [StringLength(13)]
        public string CNP { get; set; }
        
        
        [StringLength(10)]
        public string Phone { get; set; }
        
        [Display(Name = "Date of Birth")]
        [Min18Years]
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public char Sex { get; set; }
        
        [Display(Name = "Is subscribed to newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }



        //navigation property
        [Display(Name = "Blood Type")]
        public BloodType BloodType { get; set; }
       
        //entity-framework treats this property as a foreign key
        [Required]
        [Display(Name = "Blood Type")]
        public byte BloodTypeId { get; set; }



    }
}