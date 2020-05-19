using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBlood002.Models;


namespace IBlood002.Controllers
{
    public class CentersController : Controller
    {
        private ApplicationDbContext _context;

        public CentersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {

            var centers = _context.Centers.ToList();

            return View(centers);
        }

        public ActionResult Details(int Id)
        {
            var center = _context.Centers.SingleOrDefault(c => c.Id == Id);

            if (center == null)
                return HttpNotFound();

            return View(center);
        }

        //public IEnumerable<Center> GetCenters()
        //{
        //    return new List<Center>
        //    {
        //        new Center{ Id = 1, Name = "Center 1"},
        //        new Center { Id = 2, Name = "Center 2"}
        //    };
        //}


        //Examples
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrEmpty(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}


        [Route("center/date/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByYear(int year, int month)
        {
            return Content(year + "/" + month);
        }


        [HttpPost]
        public ActionResult Save(Center center) //model binding
        {
            if (center.Id == 0) //new center
                _context.Centers.Add(center); //it's just in the memory =? we need to save them in the db
            else //existing center
            {
                var centerInDb = _context.Centers.Single(c => c.Id == center.Id); //Single throws an exception if donor is not found. Not the case, bcs the action is called when posting center form


                centerInDb.Name = center.Name;
                centerInDb.PhoneNumber = center.PhoneNumber;
                centerInDb.Website = center.Website;
                centerInDb.Address = center.Address;


            }

           
            _context.SaveChanges(); //wraps the changes in a transaction.


            return RedirectToAction("Index", "Centers");
        }

        public ActionResult New()
        {
            
            return View("CenterForm");
        }


    }
}