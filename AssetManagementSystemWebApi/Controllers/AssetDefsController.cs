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
using AssetManagementSystemWebApi.Models;

namespace AssetManagementSystemWebApi.Controllers
{
    public class AssetDefsController : ApiController
    {
        private assetDBEntities db = new assetDBEntities();

		// GET: api/AssetDefs
		public List<AssetDefinitionViewModel> GetAssetDefs()
		{
			List<tblAssetDef> assetList = db.tblAssetDefs.ToList();
			List<AssetDefinitionViewModel> avList = assetList.Select(x => new AssetDefinitionViewModel
			{
				assetId = Convert.ToInt32(x.ad_id),
				assetName = x.ad_name,
				assetType = x.tblAssetType.at_name,
				assetClass = x.ad_class
			}).ToList();
			return avList;
		}
		public int Get(string name)
		{
			List<tblAssetDef> aslist = db.tblAssetDefs.Where(x => x.ad_name.Contains(name)).ToList();
			int count = aslist.Count;
			return count;
		}

		// GET: api/AssetDefs/5
		[ResponseType(typeof(tblAssetDef))]
        public IHttpActionResult GettblAssetDef(decimal id)
        {
            tblAssetDef tblAssetDef = db.tblAssetDefs.Find(id);
            if (tblAssetDef == null)
            {
                return NotFound();
            }

            return Ok(tblAssetDef);
        }

        // PUT: api/AssetDefs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblAssetDef(decimal id, tblAssetDef tblAssetDef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAssetDef.ad_id)
            {
                return BadRequest();
            }

            db.Entry(tblAssetDef).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAssetDefExists(id))
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

        // POST: api/AssetDefs
        [ResponseType(typeof(tblAssetDef))]
        public IHttpActionResult PosttblAssetDef(tblAssetDef tblAssetDef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblAssetDefs.Add(tblAssetDef);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblAssetDef.ad_id }, tblAssetDef);
        }

        // DELETE: api/AssetDefs/5
        [ResponseType(typeof(tblAssetDef))]
        public IHttpActionResult DeletetblAssetDef(decimal id)
        {
            tblAssetDef tblAssetDef = db.tblAssetDefs.Find(id);
            if (tblAssetDef == null)
            {
                return NotFound();
            }

            db.tblAssetDefs.Remove(tblAssetDef);
            db.SaveChanges();

            return Ok(tblAssetDef);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAssetDefExists(decimal id)
        {
            return db.tblAssetDefs.Count(e => e.ad_id == id) > 0;
        }
    }
}