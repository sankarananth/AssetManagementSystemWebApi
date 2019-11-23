using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystemWebApi.Models
{
	public class VendorViewModel
	{
		public int vendorId { get; set; }
		public string vendorName { get; set; }
		public string vendorType { get; set; }
		public string vAssetType { get; set; }
		public string vFrom { get; set; }
		public string vTo { get; set; }
		public string vAddress { get; set; }


	}
}