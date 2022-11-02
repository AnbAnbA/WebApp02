using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp02.Models;

namespace WebApp02.Controllers
{
    public class MedicinesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Medicines
        [ResponseType(typeof(List<MedModel>))]
        public IHttpActionResult GetMedicine()
        {
            return Ok(db.Medicine.ToList().ConvertAll(x=> new MedModel(x)));
        }

        // GET: api/Medicines/5
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult GetMedicine(int id)
        {
            Medicine medicine = db.Medicine.Find(id);
            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }

        // PUT: api/Medicines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicine(int id, Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicine.IDMed)
            {
                return BadRequest();
            }

            db.Entry(medicine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Medicines
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult PostMedicine(Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicine.Add(medicine);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MedicineExists(medicine.IDMed))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = medicine.IDMed }, medicine);
        }

        // DELETE: api/Medicines/5
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult DeleteMedicine(int id)
        {
            Medicine medicine = db.Medicine.Find(id);
            if (medicine == null)
            {
                return NotFound();
            }

            db.Medicine.Remove(medicine);
            db.SaveChanges();

            return Ok(medicine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicineExists(int id)
        {
            return db.Medicine.Count(e => e.IDMed == id) > 0;
        }
    }
}