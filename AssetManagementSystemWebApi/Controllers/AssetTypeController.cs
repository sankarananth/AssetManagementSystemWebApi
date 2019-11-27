using AssetManagementSystemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AssetManagementSystemWebApi.Controllers
{
    public class AssetTypeController : ApiController
    {
		private assetDBEntities db = new assetDBEntities();

		public AssetTypeController()
		{
			db.Configuration.ProxyCreationEnabled = false;
		}
		// GET: api/Assettypes
		public IQueryable<tblAssetType> GetAssettypes()
		{
			return db.tblAssetTypes;
		}
	}
}
