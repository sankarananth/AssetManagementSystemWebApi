using AssetManagementSystemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AssetManagementSystemWebApi.Controllers
{
	
	public class LoginController : ApiController
    {
		private assetDBEntities db = new assetDBEntities();
		public List<tbllogin> Get(string user, string pass)
		{
			List<tbllogin> loglist = db.tbllogins.Where(x => x.uname == user && x.pass == pass).ToList();

			return loglist;
		}
	}
}
