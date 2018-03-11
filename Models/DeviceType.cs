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
    using System.Collections.Generic;
    
    public partial class DeviceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeviceType()
        {
            this.Devices = new HashSet<Device>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinSpeed { get; set; }
        public int MaxHdop { get; set; }
        public int MinGpsLevel { get; set; }
        public decimal MinDifferenceTrackPoints { get; set; }
        public int Timeout { get; set; }
        public int StationaryTimeout { get; set; }
        public string Icon { get; set; }
        public string MapIcon { get; set; }
        public string TailColor { get; set; }
        public int TailPoints { get; set; }
        public bool Active { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Device> Devices { get; set; }
    }
}
