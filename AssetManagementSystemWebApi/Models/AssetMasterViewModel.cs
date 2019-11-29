using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystemWebApi.Models
{
	public class AssetMasterViewModel
	{
		public int assetId { get; set; }
		public string assetType { get; set; }
		public string vendorName { get; set; }
		public string assetName { get; set; }
		public string modelNo { get; set; }
		public string serialNo { get; set; }
		public string manuYear { get; set; }
		public string purDate { get; set; }
		public string warranty { get; set; }
		public string wFrom { get; set; }
		public string wTo { get; set; }


	}
}