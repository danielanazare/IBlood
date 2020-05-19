using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBlood002.Models;

namespace IBlood002.ViewModels
{
    public class DonorFormViewModel
    {
        public IEnumerable<BloodType> BloodTypes { get; set; }
        public Donor Donor { get; set; }

        public string Title
        {
            get
            {
                if (Donor != null && Donor.Id != 0)
                    return "Edit Donor";

                return "New Donor";
            }
        }

    }
}