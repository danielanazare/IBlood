using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using IBlood002.Dtos;
using IBlood002.Models;

namespace IBlood002.Controllers.Api
{
    public class DonorsController : ApiController
    {
        private ApplicationDbContext _context;

        public DonorsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/donors
        public IEnumerable<DonorDto> GetDonors()
        {
            return _context.Donors.ToList().Select(Mapper.Map<Donor,DonorDto>);

        }

        //GET /api/donors/1
        public IHttpActionResult GetDonor(int id)
        {
            var donor = _context.Donors.SingleOrDefault(d => d.Id == id);

            if (donor == null)
                return NotFound();

            return Ok(Mapper.Map<Donor, DonorDto>(donor));
        }

        // POST /api/donors
        [HttpPost]
        public IHttpActionResult CreateDonor(DonorDto donorDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var donor = Mapper.Map<DonorDto, Donor>(donorDto);
            _context.Donors.Add(donor);
            _context.SaveChanges();

            donorDto.Id = donor.Id;

            //we return the uri of the new donor
            return Created(new Uri(Request.RequestUri + "/" + donor.Id), donorDto );

        }

        // PUT /api/donors/1
        //id from url, donor from request body
        [HttpPut]
        public IHttpActionResult UpdateDonor(int id, DonorDto donorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var donorInDb = _context.Donors.SingleOrDefault(d => d.Id == id);

            if (donorInDb == null)
                return NotFound();


            Mapper.Map(donorDto, donorInDb);

            _context.SaveChanges();

            return Ok(Mapper.Map(donorDto, donorInDb));
        }

        // DELETE /api/donors/1
        [HttpDelete]
        public IHttpActionResult DeleteDonor(int id)
        {
            var donorInDb = _context.Donors.SingleOrDefault(d => d.Id == id);

            if (donorInDb == null)
                return NotFound();

            _context.Donors.Remove(donorInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
