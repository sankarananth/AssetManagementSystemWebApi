//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssetManagementSystemWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPurchaseOrder
    {
        public decimal pd_id { get; set; }
        public string pd_orderno { get; set; }
        public Nullable<decimal> pd_ad_id { get; set; }
        public Nullable<decimal> pd_type_id { get; set; }
        public Nullable<decimal> pd_qty { get; set; }
        public Nullable<decimal> pd_vendor_id { get; set; }
        public Nullable<System.DateTime> pd_odate { get; set; }
        public Nullable<System.DateTime> pd_ddate { get; set; }
        public string pd_status { get; set; }
    
        public virtual tblAssetDef tblAssetDef { get; set; }
        public virtual tblAssetType tblAssetType { get; set; }
        public virtual tblVendorCreation tblVendorCreation { get; set; }
    }
}
