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
    
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Connections = new HashSet<Connection>();
            this.Devices = new HashSet<Device>();
            this.DeviceUses = new HashSet<DeviceUs>();
            this.Locations = new HashSet<Location>();
            this.PersonsByGroups = new HashSet<PersonsByGroup>();
            this.RestrictedAreas = new HashSet<RestrictedArea>();
            this.RestrictedPersons = new HashSet<RestrictedPerson>();
            this.RestrictedPersons1 = new HashSet<RestrictedPerson>();
            this.Tickets = new HashSet<Ticket>();
        }
    
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public int CenterId { get; set; }
        public int CountryId { get; set; }
        public int LanguageId { get; set; }
        public int PersonTypeId { get; set; }
        public Nullable<long> DeviceId { get; set; }
        public Nullable<long> OwnerUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte GenreId { get; set; }
        public System.DateTime Birthdate { get; set; }
        public string DocumentId { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string EyesColor { get; set; }
        public string HairColor { get; set; }
        public byte EthnyId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string FamilyPhones { get; set; }
        public string PostalCode { get; set; }
        public string ScarsMarksTattoos { get; set; }
        public byte CrimeId { get; set; }
        public string Nicknames { get; set; }
        public byte RiskId { get; set; }
        public int TimeZone { get; set; }
        public bool AutoDST { get; set; }
        public string Picture { get; set; }
        public Nullable<long> LocationId { get; set; }
        public Nullable<long> ConnectionId { get; set; }
        public bool HasHouseArrest { get; set; }
        public string Comments { get; set; }
        public bool Active { get; set; }
        public bool ViewOnMap { get; set; }
        public bool Online { get; set; }
        public string AccessCode { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
    
        public virtual Center Center { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Connection> Connections { get; set; }
        public virtual Connection Connection { get; set; }
        public virtual Country Country { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Device> Devices { get; set; }
        public virtual Device Device { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeviceUs> DeviceUses { get; set; }
        public virtual Language Language { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location> Locations { get; set; }
        public virtual Location Location { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonsByGroup> PersonsByGroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestrictedArea> RestrictedAreas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestrictedPerson> RestrictedPersons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestrictedPerson> RestrictedPersons1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
