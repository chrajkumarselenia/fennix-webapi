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
    
    public partial class Token
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public Nullable<long> SessionId { get; set; }
        public string Code { get; set; }
        public bool LongLife { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime Finish { get; set; }
        public Nullable<System.DateTime> LastUse { get; set; }
    
        public virtual User User { get; set; }
    }
}