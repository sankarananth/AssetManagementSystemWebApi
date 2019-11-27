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
    public class PurchaseController : ApiController
    {
        private assetDBEntities db = new assetDBEntities();

        // GET: api/Purchase
        public List<PurchaseViewModel> GettblPurchaseOrders()
        {
			List<tblPurchaseOrder> purchaseList = db.tblPurchaseOrders.ToList();
			List<PurchaseViewModel> pvmList = purchaseList.Select(x => new PurchaseViewModel
			{
				purchaseId = Convert.ToInt32(x.pd_id),
				assetName = x.tblAssetDef.ad_name,
				assetType = x.tblAssetType.at_name,
				purchaseOrderNo = x.pd_orderno,
				vendorName = x.tblVendorCreation.vd_name,
				orderDate = x.pd_odate.ToString("dd/MM/yyyy"),
				deliveryDate=x.pd_ddate.ToString("dd/MM/yyyy"),
				purchaseQuantity=Convert.ToInt32(x.pd_qty),
				purchaseStatus=x.pd_status
			}).ToList();
            return pvmList;
        }
		public void Get(string name)
		{
			
		}

        // GET: api/Purchase/5
        [ResponseType(typeof(tblPurchaseOrder))]
        public IHttpActionResult GettblPurchaseOrder(decimal id)
        {
            tblPurchaseOrder tblPurchaseOrder = db.tblPurchaseOrders.Find(id);
            if (tblPurchaseOrder == null)
            {
                return NotFound();
            }

            return Ok(tblPurchaseOrder);
        }

        // PUT: api/Purchase/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblPurchaseOrder(decimal id, tblPurchaseOrder tblPurchaseOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPurchaseOrder.pd_id)
            {
                return BadRequest();
            }

            db.Entry(tblPurchaseOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPurchaseOrderExists(id))
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

        // POST: api/Purchase
        [ResponseType(typeof(tblPurchaseOrder))]
        public IHttpActionResult PosttblPurchaseOrder(tblPurchaseOrder tblPurchaseOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblPurchaseOrders.Add(tblPurchaseOrder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblPurchaseOrder.pd_id }, tblPurchaseOrder);
        }

        // DELETE: api/Purchase/5
        [ResponseType(typeof(tblPurchaseOrder))]
        public IHttpActionResult DeletetblPurchaseOrder(decimal id)
        {
            tblPurchaseOrder tblPurchaseOrder = db.tblPurchaseOrders.Find(id);
            if (tblPurchaseOrder == null)
            {
                return NotFound();
            }

            db.tblPurchaseOrders.Remove(tblPurchaseOrder);
            db.SaveChanges();

            return Ok(tblPurchaseOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblPurchaseOrderExists(decimal id)
        {
            return db.tblPurchaseOrders.Count(e => e.pd_id == id) > 0;
        }
    }
}