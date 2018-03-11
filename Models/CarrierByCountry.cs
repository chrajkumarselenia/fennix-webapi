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
    
    public partial class CarrierByCountry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarrierByCountry()
        {
            this.SimCards = new HashSet<SimCard>();
        }
    
        public int Id { get; set; }
        public int CarrierId { get; set; }
        public int CountryId { get; set; }
        public string APN { get; set; }
    
        public virtual Carrier Carrier { get; set; }
        public virtual Country Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SimCard> SimCards { get; set; }
    }
}
