using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBlood002.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public Center Center { get; set; }
        public int CenterId { get; set; }
        public Donor Donor { get; set; }
        public int DonorId { get; set; }

        public DateTime Date { get; set; }
    }
}