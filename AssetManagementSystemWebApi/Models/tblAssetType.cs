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
    
    public partial class tblAssetType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAssetType()
        {
            this.tblAssetDefs = new HashSet<tblAssetDef>();
            this.tblAssetMasters = new HashSet<tblAssetMaster>();
            this.tblPurchaseOrders = new HashSet<tblPurchaseOrder>();
            this.tblVendorCreations = new HashSet<tblVendorCreation>();
        }
    
        public decimal at_id { get; set; }
        public string at_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAssetDef> tblAssetDefs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAssetMaster> tblAssetMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseOrder> tblPurchaseOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVendorCreation> tblVendorCreations { get; set; }
    }
}
