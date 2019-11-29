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
using log4net;
using AssetManagementSystemWebApi.Models;

namespace AssetManagementSystemWebApi.Controllers
{
    public class VendorController : ApiController
    {
		private static readonly ILog Log = LogManager.GetLogger(typeof(VendorController));
		private assetDBEntities db = new assetDBEntities();

        // GET: api/Vendor
        public List<VendorViewModel> GettblVendorCreations()
        {
			List<tblVendorCreation> vendorList = db.tblVendorCreations.ToList();
			List<VendorViewModel> vList = vendorList.Select(x => new VendorViewModel
			{
				vendorId=Convert.ToInt32(x.vd_id),
				vendorName=x.vd_name,
				vendorType=x.vd_type,
				vAssetType=x.tblAssetType.at_name,
				vFrom=x.vd_from.ToString("yyyy/MM/dd"),
				vTo=x.vd_to.ToString("yyyy/MM/dd"),
				vAddress=x.vd_addr
			}).ToList();
            return vList;
        }

        // GET: api/Vendor/5
        [ResponseType(typeof(tblVendorCreation))]
        public IHttpActionResult GettblVendorCreation(decimal id)
        {
            tblVendorCreation tblVendorCreation = db.tblVendorCreations.Find(id);
            if (tblVendorCreation == null)
            {
                return NotFound();
            }

            return Ok(tblVendorCreation);
        }

        // PUT: api/Vendor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblVendorCreation(decimal id, tblVendorCreation tblVendorCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblVendorCreation.vd_id)
            {
                return BadRequest();
            }

            db.Entry(tblVendorCreation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblVendorCreationExists(id))
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

        // POST: api/Vendor
        [ResponseType(typeof(tblVendorCreation))]
        public IHttpActionResult PosttblVendorCreation(tblVendorCreation tblVendorCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			try
			{
				db.tblVendorCreations.Add(tblVendorCreation);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				Log.Debug(ex.Message);
				throw;
			}

            return CreatedAtRoute("DefaultApi", new { id = tblVendorCreation.vd_id }, tblVendorCreation);
        }

        // DELETE: api/Vendor/5
        [ResponseType(typeof(tblVendorCreation))]
        public IHttpActionResult DeletetblVendorCreation(int id)
        {
            tblVendorCreation tblVendorCreation = db.tblVendorCreations.Find(id);
            if (tblVendorCreation == null)
            {
                return NotFound();
            }

            db.tblVendorCreations.Remove(tblVendorCreation);
            db.SaveChanges();

            return Ok(tblVendorCreation);
        }
		public int Get(string name)
		{
			List<tblVendorCreation> vendorList=db.tblVendorCreations.Where(x => x.vd_name.Contains(name)).ToList();
			int count = vendorList.Count;
			return count;
		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblVendorCreationExists(decimal id)
        {
            return db.tblVendorCreations.Count(e => e.vd_id == id) > 0;
        }
    }
}