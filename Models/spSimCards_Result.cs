//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fenn.Models
{
    using System;
    
    public partial class spSimCards_Result
    {
        public long Id { get; set; }
        public int CenterId { get; set; }
        public Nullable<long> DeviceId { get; set; }
        public int CarrierByCountryId { get; set; }
        public int SimCardTypeId { get; set; }
        public string Phone { get; set; }
        public string Serial { get; set; }
        public bool Active { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public string NameCenterId { get; set; }
        public string IMEIDeviceId { get; set; }
        public string APNCarrierByCountryId { get; set; }
    }
}
