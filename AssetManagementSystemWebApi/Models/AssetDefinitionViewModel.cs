using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystemWebApi.Models
{
	public class AssetDefinitionViewModel
	{
		public string assetName { get; set; }
		public int assetId { get; set; }
		public string assetType { get; set; }
		public string assetClass { get; set; }
	}
}