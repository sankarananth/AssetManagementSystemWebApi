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
    public class AssetMasterController : ApiController
    {
		private static readonly ILog Log = LogManager.GetLogger(typeof(AssetMasterController));
		private assetDBEntities db = new assetDBEntities();

        // GET: api/AssetMaster
        public List<AssetMasterViewModel> GettblAssetMasters()
        {
			List<tblAssetMaster> amList = db.tblAssetMasters.ToList();
			List<AssetMasterViewModel> avmList = amList.Select(x => new AssetMasterViewModel
			{
				assetId = x.am_id,
				assetName = x.tblAssetDef.ad_name,
				assetType = x.tblAssetType.at_name,
				vendorName = x.tblVendorCreation.vd_name,
				modelNo = x.am_model,
				serialNo = x.am_snumber,
				manuYear = x.am_myyear.ToString(),
				purDate=x.am_pdate.ToString(),
				warranty=x.am_warranty,
				wFrom=x.am_from.ToString(),
				wTo=x.am_to.ToString()
			}).ToList();
            return avmList;
        }
		public List<PurchaseViewModel> Get(string orderno)
		{
				List<tblPurchaseOrder> pList = db.tblPurchaseOrders.Where(x => x.pd_orderno == orderno).ToList();
				List<PurchaseViewModel> pvList = pList.Select(x => new PurchaseViewModel
				{
					purchaseOrderNo = x.pd_orderno,
					assetName = x.tblAssetDef.ad_name,
					vendorName = x.tblVendorCreation.vd_name,
					purchaseQuantity = Convert.ToInt32(x.pd_qty),
					assetType = x.tblAssetType.at_name,
					purchaseStatus = x.pd_status
				}).ToList();
				return pvList;
		
			
		}
		
        // GET: api/AssetMaster/5
        [ResponseType(typeof(tblAssetMaster))]
        public IHttpActionResult GettblAssetMaster(int id)
        {
            tblAssetMaster tblAssetMaster = db.tblAssetMasters.Find(id);
            if (tblAssetMaster == null)
            {
                return NotFound();
            }

            return Ok(tblAssetMaster);
        }

        // PUT: api/AssetMaster/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblAssetMaster(int id, tblAssetMaster tblAssetMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAssetMaster.am_id)
            {
                return BadRequest();
            }

            db.Entry(tblAssetMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAssetMasterExists(id))
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

        // POST: api/AssetMaster
        [ResponseType(typeof(tblAssetMaster))]
        public IHttpActionResult PosttblAssetMaster(string orderno,string assetname,string vendorname,string assettype,string quantity,tblAssetMaster tblAssetMaster)
        {
			try
			{
				var asDef = db.tblAssetDefs.Where(x => x.ad_name == assetname).FirstOrDefault();
				var type = db.tblAssetTypes.Where(x => x.at_name == assettype).FirstOrDefault();
				var vendor = db.tblVendorCreations.Where(x => x.vd_name == vendorname).FirstOrDefault();
				tblAssetMaster.am_ad_id = asDef.ad_id;
				tblAssetMaster.am_atype_id = type.at_id;
				tblAssetMaster.am_make_id = vendor.vd_id;
				var purchase = db.tblPurchaseOrders.Where(x => x.pd_orderno == orderno).FirstOrDefault();
				purchase.pd_status = "Assets Added";
				db.Entry(purchase).Property("pd_status").IsModified = true;
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				Log.Debug(ex.Message);
			}
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			int count = Convert.ToInt32(quantity);
			Random r = new Random();
			for(int i=0;i<count;i++)
			{
				tblAssetMaster.am_snumber = "S" + r.Next(0,10000);
				db.tblAssetMasters.Add(tblAssetMaster);
				db.SaveChanges();
			}
				

            return CreatedAtRoute("DefaultApi", new { id = tblAssetMaster.am_id }, tblAssetMaster);
        }

        // DELETE: api/AssetMaster/5
        [ResponseType(typeof(tblAssetMaster))]
        public IHttpActionResult DeletetblAssetMaster(int id)
        {
            tblAssetMaster tblAssetMaster = db.tblAssetMasters.Find(id);
            if (tblAssetMaster == null)
            {
                return NotFound();
            }

            db.tblAssetMasters.Remove(tblAssetMaster);
            db.SaveChanges();

            return Ok(tblAssetMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAssetMasterExists(int id)
        {
            return db.tblAssetMasters.Count(e => e.am_id == id) > 0;
        }
    }
}