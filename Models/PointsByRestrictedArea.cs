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
    
    public partial class PointsByRestrictedArea
    {
        public long Id { get; set; }
        public long RestrictedAreaId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    
        public virtual RestrictedArea RestrictedArea { get; set; }
    }
}