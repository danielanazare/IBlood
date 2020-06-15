using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IBlood002.Models;

namespace IBlood002.ViewModels
{
    public class DonorFormViewModel
    {
        public IEnumerable<BloodType> BloodTypes { get; set; }
        public int? Id { get; set; }

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

        [Required]
        [Display(Name = "Date of Birth")]
        [Min18Years]
        public DateTime? BirthDate { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public char? Sex { get; set; }

        [Display(Name = "Is subscribed to newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

      

        //entity-framework treats this property as a foreign key
        [Required]
        [Display(Name = "Blood Type")]
        public byte? BloodTypeId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0
                    ? "Edit Donor"
                    : "New Donor";

            }
        }

        public DonorFormViewModel()
        {
            Id = 0;
        }
        public DonorFormViewModel(Donor donor)
        {
            Id = donor.Id;
            FirstName = donor.FirstName;
            LastName = donor.LastName;
            BloodTypeId = donor.BloodTypeId;
            BirthDate = donor.BirthDate;
        }

    }
}