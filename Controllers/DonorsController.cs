using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using IBlood002.Controllers;
using IBlood002.Models;
using IBlood002.ViewModels;

namespace IBlood001.Controllers
{
    public class DonorsController : Controller
    {
        private ApplicationDbContext _context;

        public DonorsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var donors = _context.Donors.Include(d => d.BloodType).ToList();
            return View(donors);
        }

        public ActionResult Details(int Id)
        {
            var donor = _context.Donors.Include(d => d.BloodType).SingleOrDefault(c => c.Id == Id);

            if (donor == null)
                return HttpNotFound();

            return View(donor);
        }

        public ActionResult New()
        {
            var bloodTypes = _context.BloodTypes.ToList();
            var viewModel= new DonorFormViewModel
            {
                BloodTypes = bloodTypes
            };
            return View("DonorForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Donor donor) //model binding
        {
            if(donor.Id == 0) //new donor
                _context.Donors.Add(donor); //it's just in the memory =? we need to save them in the db
            else //existing donor
            {
                var donorInDb = _context.Donors.Single(d => d.Id == donor.Id); //Single throws an exception if donor is not found. Not the case, bcs the action is called when posting donor form

                //TryUpdateModel(donorInDb);//updates all properties on donor (security bridges)
                //TryUpdateModel(donorInDb, "", new [] {"FirstName", "LastName"})

                donorInDb.FirstName = donor.FirstName;
                donorInDb.LastName = donor.LastName;
                donorInDb.BirthDate = donor.BirthDate;
                donorInDb.BloodTypeId = donor.BloodTypeId;
                donorInDb.IsSubscribedToNewsletter = donor.IsSubscribedToNewsletter;
                
                //AutoMapper -> Maper.Map(donor, donorInDB)
                //UpdateDonorDto (data transform object) - another class only with attributes that can be updated


            }

            try
            {
                _context.SaveChanges(); //wraps the changes in a transaction.

            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }


            return RedirectToAction("Index", "Donors");
        }

        public ActionResult Edit(int id)
        {
            var donor = _context.Donors.SingleOrDefault(d => d.Id == id);

            if (donor == null)
                return HttpNotFound();

            var viewModel = new DonorFormViewModel
            {
                Donor = donor,
                BloodTypes = _context.BloodTypes.ToList()
            };
            return View("DonorForm", viewModel);
        }
    }
}