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
    
    public partial class spSessionUses_Result
    {
        public long Id { get; set; }
        public long SessionId { get; set; }
        public System.DateTime Started { get; set; }
        public string HostAddress { get; set; }
        public string LocationName { get; set; }
        public string AdditionalInfo { get; set; }
        public string BrowserSessionId { get; set; }
    }
}
