using AssetManagementSystemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
namespace AssetManagementSystemWebApi.Controllers
{
	
	public class LoginController : ApiController
    {
		private static readonly ILog Log = LogManager.GetLogger(typeof(AssetMasterController));
		private assetDBEntities db = new assetDBEntities();
		public LoginController()
		{
			db.Configuration.ProxyCreationEnabled = false;
		}
		public List<tbllogin> Get(string user, string pass)
		{
			List<tbllogin> loglist = db.tbllogins.Where(x => x.uname == user && x.pass == pass).ToList();

			return loglist;
		}
		public tblAssetDef Get(string name)
		{
			try
			{
				tblAssetDef adef = db.tblAssetDefs.Where(x => x.ad_name == name).FirstOrDefault();
				return adef;
			}
			catch (Exception ex)
			{
				Log.Debug(ex.Message);
				throw;
			}
			
		}
		public List<tblPurchaseOrder> Get(int id)
		{
			List<tblPurchaseOrder> purchaseList = db.tblPurchaseOrders.ToList();
			return purchaseList;
		}
	}
}
