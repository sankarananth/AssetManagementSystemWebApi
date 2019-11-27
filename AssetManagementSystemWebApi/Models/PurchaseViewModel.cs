using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystemWebApi.Models
{
	public class PurchaseViewModel
	{
		public int purchaseId { get; set; }
		public string assetName { get; set; }
		public string assetType { get; set; }
		public string vendorName { get; set; }
		public string purchaseOrderNo { get; set; }
		public int purchaseQuantity { get; set; }
		public string orderDate { get; set; }
		public string deliveryDate { get; set; }
		public string purchaseStatus { get; set; }
	}
}